let array1 = 
    [|[|'h'; 'e'; 'l'; 'l'; 'o'|];
    [|'h'; 'a'; 'l'; 'l'; 'o'|];
    [|'h'; 'e'; 'l'; 'i'; 'o'|]|]

let getAr =
    array1.[1]

let toString : char seq -> string = Seq.map string >> String.concat ""

let yey = toString getAr

// let nope (array: char[][]) =
//     for i in 0..array.Length - 1 do
//         for j in 0..array[i].Length - 1 do 
//             printfn "%A" array[i].[j]
//Display each char for each column and row


let case (array: char[][]) =
    array |> Array.item 1 |>Array.item 2

let jaaj = case array1

let gut = array1.[0].[0]

let gut2 = array1.[0].[7]


//printfn "%A" array1
//printfn "%A" getAr

printfn "%A" gut
printfn "%A" gut2
           

