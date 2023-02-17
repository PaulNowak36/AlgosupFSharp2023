namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

type Employee = { ID: string; Name: string; Salary: float; HireDate: System.DateTime }

module Database =
    open System

    let employee1() = { ID = "E001"; Name = "John Smith"; Salary = 50000.0; HireDate = new DateTime(2020, 1, 1) }
    let employee2() = { ID = "E002"; Name = "Jane Doe"; Salary = 60000.0; HireDate = new DateTime(2020, 6, 1) }
    let employee3() = { ID = "E003"; Name = "Bob Johnson"; Salary = 55000.0; HireDate = new DateTime(2020, 5, 1) }
    let employee4() = { ID = "E004"; Name = "Emily Thompson"; Salary = 62000.0; HireDate = new DateTime(2020, 3, 1) }

    let getEmployees() = [ employee1(); employee2(); employee3(); employee4(); ]


module Question05 =

    // "Employee Management System":

    // You are working with an Employee Management System that keeps track of a company's employees.

    // Each employee should have the following information:

    //     ID (string)
    //     Name (string)
    //     Salary (float)
    //     Hire Date (DateTime)

    // A function getEmployees has been provided to retrieve all employees.

    // Implementing the following features:

    // * Retrieve an employee's information, this should called getEmployeeById and
    //   take a parameter employeeID. It should return the type option<Employee>
    // * Retrieve a list of all employees sorted by hire date;  this should called
    //   getAllEmployeesSortedByHireDate, it should have no parameters and return the
    //   type list<Employee>

    let getEmployeeById (employeeID: string) =  __

    let getAllEmployeesSortedByHireDate () = __

    [<Test>]
    let ``Question 05 - Test Case 01``() =
        let actualValue = getEmployeeById "E001"  // getEmployeeById "E001"
        let expectedValue = Some (Database.employee1())

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 05 - Test Case 02``() =
        let actualValue = getEmployeeById "E005"
        let expectedValue = None

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 05 - Test Case 03``() =
        let actualValue = getAllEmployeesSortedByHireDate ()
        let expectedValue = [ Database.employee1(); Database.employee4(); Database.employee3(); Database.employee2() ]

        AssertEquality expectedValue actualValue


