open System

let isPalindrome (s:string) = 
        let str =
            s.ToLower()
            |> Seq.filter (System.Char.IsLetterOrDigit)
            |> Seq.toList

        str = (str |> List.rev)

let result = isPalindrome "racecar"

printfn "%A" result

type Employee = { ID: string; Name: string; Salary: float; HireDate: System.DateTime }

let employee1() = { ID = "E001"; Name = "John Smith"; Salary = 50000.0; HireDate = new DateTime(2020, 1, 1) }
let employee2() = { ID = "E002"; Name = "Jane Doe"; Salary = 60000.0; HireDate = new DateTime(2020, 6, 1) }
let employee3() = { ID = "E003"; Name = "Bob Johnson"; Salary = 55000.0; HireDate = new DateTime(2020, 5, 1) }
let employee4() = { ID = "E004"; Name = "Emily Thompson"; Salary = 62000.0; HireDate = new DateTime(2020, 3, 1) }

let getEmployees() = [ employee1(); employee2(); employee3(); employee4(); ]

 let getStudent (ddz: string) =
    typEmployee with {ID: ddz};


let res = employee1().ID

printfn "%A" res