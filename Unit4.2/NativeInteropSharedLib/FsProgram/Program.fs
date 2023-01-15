namespace InteropWithNative
open System
open System.Runtime.InteropServices

module Native =
    [<DllImport("hello_library")>]
    extern void print_text()

    [<DllImport("hello_library")>]
    extern IntPtr make_char_buffer(int number)

    [<DllImport("hello_library")>]
    extern void free_char_buffer(IntPtr buffer)


module Program =

    [<EntryPoint>]
    let main(args) =

        Native.print_text()

        let buffer = Native.make_char_buffer(42);

        let stringCopiedFromNative = Marshal.PtrToStringAnsi(buffer);

        Native.free_char_buffer(buffer)

        Console.WriteLine(stringCopiedFromNative)

        0