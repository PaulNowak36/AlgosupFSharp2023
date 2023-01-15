namespace InteropWithNative
open System.Runtime.InteropServices

module Windows =
    [<DllImport("Kernel32.dll")>]
    extern int GetCurrentProcessId()

module Unix =
    [<DllImport("libc")>]
    extern int getpid()

module Program =

    [<EntryPoint>]
    let main(args) =

        let isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)

        let pid =
                if isWindows then Windows.GetCurrentProcessId()
                else Unix.getpid()

        let platform = if isWindows then "" else "not "

        printfn $"My platform is {platform}Windows"
        printfn $"My pid is {pid}"

        0