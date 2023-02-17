
let input = 
          [ "   ";
            " * ";
            "   " ]

let input2 = [" * * "]

let input3 =
            [ " ";
            "*";
            " ";
            "*";
            " " ]

let fieldState (field: string list) = 

  let listLength =
    field |> List.length
  
  let stringLength = 
    field |> List.map (fun s -> float s.Length) |> List.average

  let isHorizontal : bool = 
    if listLength = 1 && stringLength > 1 then true
    else false

  let isVertical : bool = 
    if listLength > 1 && stringLength = 1 then true
    else false

  let isLarge : bool = 
    if listLength > 1 && stringLength > 1 then true
    else false

  printfn "Is it horizontal ? %b. Is it vertical ? %b Is it large ? %b" isHorizontal isVertical isLarge
  
//let test1 = fieldState input
//let test2 = fieldState input2
//let test3 = fieldState input3


let name = "abababa"

let replace (s: string) =
  s.Replace("b", "c")

let test4 = replace name

let name2 = [|'h'; 'e'; 'l'; 'l'; 'o'|]

let allChar =
  name2 |> Array.iter(fun i -> printfn "%c" i)

let array = name.ToCharArray()

let ggg = name.[1]

let inline replace1 list a b = list |> Seq.map (fun x -> if x = a then b else x)

let inline replace2 list func = list |> Seq.map func

let updateName = replace1 name 'b' 'c'

let toString : char seq -> string = Seq.map string >> String.concat ""

let newUpdate =  replace2 name (fun x -> if name.[1] = 'b' then 'd' else x) 

let updateTwice = toString newUpdate


let newchangeFunct (array: char array) : char array=
  let NewArray =
    for i in 0 .. array.Length-1 do
      newArray|>Array.append array[i]
    // if array.[0] = ' ' && array[1] = '*' then
    //   newArray.[0] = '1'
    // else 
    //   newArray.[0] = ' '
  newArray


let changeFunct (array: char array) : char array=
  if array.[0] = ' ' && array[1] = '*' then
    array.[0] = '1'
  else 
  
  for i in 1..array.Length-2 do
    if array[i] = ' ' then
      if array[i+1] = '*' && array.[i-1] = '*' then
        array[i] = '2'
      elif array[i+1] = '*' || array.[i-1] = '*' then
        array[i] = '1'
      else  
        array[i] = ' '
  
  if array.[array.Length-1] = ' ' && array[array.Length-2] = '*' then
    array[array.Length-1] = '1'
  





printfn "%A" name
printfn "%A" newUpdate
printfn "%A" updateTwice




// let matrix =
