#r "paket:
nuget Fake.Build.CMake
nuget Fake.DotNet.Cli
nuget Fake.Core.Process
nuget Fake.Core.Target
nuget Fake.IO.FileSystem //"
// include Fake modules, see Fake modules section

open System
open System.IO
open Fake.Core
open Fake.Build
open Fake.IO
open Fake.DotNet

// *** Define Targets ***
Target.create "BuildSharedLib" (fun _ ->
    Directory.create @"CSharedLibrary/build"
    CMake.Generate (fun x -> { x with BinaryDirectory = @"CSharedLibrary/build"; SourceDirectory = ".." })
    CMake.Build (fun x -> { x with BinaryDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"CSharedLibrary/build") })
)

Target.create "BuildDotnet" (fun _ ->
    CreateProcess.fromRawCommand "dotnet"  [ "build" ]
    |> CreateProcess.withWorkingDirectory "FsProgram"
    |> Proc.run
    |> ignore
)

Target.create "CopySharedLip" (fun _ ->
    if Environment.isWindows then
        File.Copy("CSharedLibrary/build/Debug/hello_library.dll", "FsProgram/bin/Debug/net7.0/hello_library.dll", true)
    elif Environment.isLinux then
        File.Copy("CSharedLibrary/build/libhello_library.so", "FsProgram/bin/Debug/net7.0/libhello_library.so", true)
    elif Environment.isMacOS then
        failwith "todo"
    else
        failwith "unknow platform"
)

Target.create "RunDotnet" (fun _ ->
    CreateProcess.fromRawCommand "dotnet"  [ "run"; "--nobuild" ]
    |> CreateProcess.withWorkingDirectory "FsProgram"
    |> Proc.run
    |> ignore
)

open Fake.Core.TargetOperators

"BuildSharedLib"
  ==> "BuildDotnet"
  ==> "CopySharedLip"
  ==> "RunDotnet"

// *** Start Build ***
Target.runOrDefault "RunDotnet"
