
let line = "...!..;.."

let countDotsInLine line =
    line |> Seq.filter (fun c -> c ='.') |> Seq.length 

let maze =
    [|  "##/------------7/------------7##"
        "##|............|!............|##"
        "##|./__7./7./______7./7./__7.|##"
        "_______7./7 |      ! /7./_______"
        "##|./____JL__7.|!./__JL____7.|##"
        "##|.L--------J.LJ.L--------J.|##"
        "##|..........................|##"
        "##L--------------------------J##" |]

let res = 
    maze |> Array.sumBy (fun line -> countDotsInLine line)

printfn "%A" res
// let matrix =
