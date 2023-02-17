let arr = [|3|]
let arr2 = [|1; 2; 4; 6; 3; 7; 8|]
let arr3 = [|1; 2; 3; 4; 6; 3; 7; 8|]


let num = arr3 |>Array.except newArray

printfn "%A" num