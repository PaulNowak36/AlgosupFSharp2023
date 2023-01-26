namespace InteropWithNative
open System
open System.Runtime.InteropServices
open FSharp.NativeInterop

[<Struct>]
type Point =
    { X: int32
      Y: int32 }

module Native =

    [<DllImport("hello_library")>]
    extern void int_pointer_demo(IntPtr i)

    [<DllImport("hello_library")>]
    extern void char_buffer_demo(IntPtr buffer, IntPtr length)

    [<DllImport("hello_library")>]
    extern void struct_demo(IntPtr pointPtr)

    [<DllImport("hello_library")>]
    extern void struct_buffer_demo(IntPtr buffer, IntPtr length)

module Program =

    let IntPtrDemo() =
        Console.WriteLine("IntPtrDemo")

        // target value
        let mutable i = 0

        // prepare the pointer
        let iPtr = &&i
        let nint = NativePtr.toNativeInt iPtr

        // call the native method
        Native.int_pointer_demo(nint)

        // print the result
        Console.WriteLine(i)

    let CharBufferDemo() =
        Console.WriteLine("CharBufferDemo")

        // buffer to hold the string
        let buffer = Marshal.AllocHGlobal(512)

        // target value to hold the length
        let mutable length = 0

        // prepare the pointer
        let lengthPtr = &&length
        let nint = NativePtr.toNativeInt lengthPtr


        // call the native method
        Native.char_buffer_demo(buffer, nint)

        // convert the unmanaged data
        let stringCopiedFromNative =
            Marshal.PtrToStringAnsi(buffer, length);

        // free the memory we allocated
        Marshal.FreeHGlobal(buffer)

        // print the result
        Console.WriteLine(stringCopiedFromNative)

    let StructDemo() =
        Console.WriteLine("StructDemo")

        // target struct
        let mutable p = { X = 0; Y = 0 }

        // prepare the pointer
        let pPtr = &&p
        let nint = NativePtr.toNativeInt pPtr

        // call the native method
        Native.struct_demo(nint)

        // print the result
        Console.WriteLine(p)

    let StructBufferDemo() =
        Console.WriteLine("StructBufferDemo")

        // find the size of our struct
        let size = Marshal.SizeOf(typeof<Point>)

        // allocate a buffer large enough to hold the results
        let buffer = Marshal.AllocHGlobal(size * 25)

        // target value to hold the length
        let mutable length = 0

        // prepare the pointer
        let lengthPtr = &&length
        let nint = NativePtr.toNativeInt lengthPtr

        // call the native method
        Native.struct_buffer_demo(buffer, nint)


        // create a .NET array to hold the results
        let (result: Point[]) = Array.zeroCreate length

        // loop over the structs converting them to .NET
        for i in 0 .. length - 1 do
            let structIndex: nativeint = buffer + (nativeint i * nativeint size)
            result.[i] <- Marshal.PtrToStructure<Point>(structIndex)

        // free the memory we allocated
        Marshal.FreeHGlobal(buffer)

        // print the result
        Console.WriteLine(sprintf "%A" result)


    [<EntryPoint>]
    let Main(args) =

        IntPtrDemo()
        CharBufferDemo()
        StructDemo()
        StructBufferDemo()

        0