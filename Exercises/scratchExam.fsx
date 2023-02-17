// let rec words word text =
//   [ match text with
//     | [] -> yield word
//     | c :: tail ->
//         match c with
//         | ' ' -> yield word
//                  yield! words "" tail
//         | _ -> yield! words (sprintf "%s%c" word c) tail ]


// printfn "%A" ("hello my friend"
//               |> Seq.toList
//               |> words "" |> List.rev)

// ["hello"; "my"; "friend"]

// /// Join a sequence of strings using a delimiter.
// let join (delim : string) (items : seq<'items>) =
//     System.String.Join(delim, items)


// // Example calls
// // Join string array by spaces
// printfn "%s" (join " " ["This"; "is"; "some"; "text"])

// // Join int list on "-" and call from a pipeline
// [1..10]
// |> join "-"
// |> printfn "%s"

// let str = "The quick brown fox jumps over the lazy dog"

// str
// |> Seq.toList
// |> words "" 
// |> List.rev
// |> join " "
// |> printfn "%s"

let leapYear (year: int) :bool =  
  let result =
      if year % 4 = 0 && year % 100 = 0 && year % 400 = 0 then 
          true
      elif year % 4 = 0 && year % 100 = 0 && year % 400 <> 0 then 
          false
      elif year % 4 = 0 && year % 100 <> 0 && year % 400 <> 0 then 
          true
      else
          false
  result


leapYear 2020