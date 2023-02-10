
let input = 
          [ "   ";
            " * ";
            "   " ]

let yolo = "fijqhqg"

let yolohiha = "f*qhqg"

let star (field: string) =
   field.Contains "*"

let minePresent (field: string list) =
   field |> List.map (fun s -> star s) |> List.exists (fun s -> s = true) 

let test = minePresent input

let mines =
  input |> List.sumBy (fun mine -> mine |> Seq.filter (fun c -> c ='*') |> Seq.length)

//let yolo = minePresent input

let changeInput = input |> List.map (fun x -> x.Replace(" ", string mines))




printfn "%A" input
printfn "%A" test
printfn "%A" mines
printfn "%A" changeInput
// let matrix =
