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
    extern void struct_pointer_buffer_demo(IntPtr i, IntPtr x)

    [<DllImport("hello_library")>]
    extern void input_struct_buffer_demo(IntPtr i, int x)

    [<DllImport("hello_library")>]
    extern void struct_buffer_demo(IntPtr buffer, IntPtr length)

    [<DllImport("hello_library")>]
    extern void free_points_buffer(IntPtr i)

    [<DllImport("hello_library")>]
    extern IntPtr new_animal(IntPtr sound, int legs)

    [<DllImport("hello_library")>]
    extern void delete_animal(IntPtr i)

    [<DllImport("hello_library")>]
    extern void animal_do_sound(IntPtr i)

    [<DllImport("hello_library")>]
    extern void animal_show_legs(IntPtr i)

module Program =
    let InputStructBufferDemo() =
        Console.WriteLine("Example 1. - Input Struct Buffer Demo")

        let structArray = [| { X = 1; Y = 1}; { X = 2; Y = 2}; { X = 3; Y = 3}; |]

        let gch = GCHandle.Alloc(structArray)

        // pin & convert the array
        let bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(structArray, 0)

        // call the native method
        Native.input_struct_buffer_demo(bufferPtr, structArray.Length)

        gch.Free()

    let StructBufferDemo() =
        Console.WriteLine("Example 2. - Struct Buffer Demo")

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

    let StructPointerBufferDemo() =
        Console.WriteLine("Example 3. - Struct Pointer Buffer Demo")

        // pointer to the buffer
        let mutable buffer = IntPtr.Zero
        let bufferPtr = &&buffer
        let bnint = NativePtr.toNativeInt bufferPtr

        // target value to hold the length
        let mutable length = 0

        // prepare the pointer
        let lengthPtr = &&length
        let lnint = NativePtr.toNativeInt lengthPtr

        // call the native method
        Native.struct_pointer_buffer_demo(bnint, lnint)

        // create a .NET array to hold the results
        let (result: Point[]) = Array.zeroCreate length

        // loop over the structs converting them to .NET
        for i in 0 .. length - 1 do
            let structIndex: nativeint = buffer + (nativeint i * nativeint IntPtr.Size)
            result.[i] <- Marshal.PtrToStructure<Point>(structIndex)

        // free the memory we allocated
        Native.free_points_buffer(bnint)

        // print the result
        Console.WriteLine(sprintf "%A" result)

    let AnimalDemo() =
        Console.WriteLine("Example 4. - Animal Object Demo")

        let sound = "woof!"

        let pSound = Marshal.StringToHGlobalAnsi(sound)

        // call the native method
        let dog = Native.new_animal(pSound, 4)

        Native.animal_do_sound(dog)
        Native.animal_show_legs(dog)
        Native.delete_animal(dog)

    [<EntryPoint>]
    let Main(args) =
        InputStructBufferDemo()
        StructBufferDemo()
        StructPointerBufferDemo()
        AnimalDemo()

        0