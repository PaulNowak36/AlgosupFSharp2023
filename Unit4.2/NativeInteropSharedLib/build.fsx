#r "paket:
nuget Fake.Build.CMake
nuget Fake.DotNet.Cli
nuget Fake.Core.Process
nuget Fake.Core.Target
nuget Fake.IO.FileSystem //"
// include Fake modules, see Fake modules section

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
    File.Copy("CSharedLibrary/build/Debug/hello_library.dll", "FsProgram/bin/Debug/net7.0/hello_library.dll", true)
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
