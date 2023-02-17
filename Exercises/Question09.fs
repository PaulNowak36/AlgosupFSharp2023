namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

module Question09 =

    type Expression =
        | Number of float
        | Add of Expression * Expression
        | Subtract of Expression * Expression
        | Multiply of Expression * Expression
        | Divide of Expression * Expression

    let num x = Number x
    let (<+>) x y = Add(x, y)
    let (<->) x y = Subtract(x, y)
    let (<*>) x y = Multiply(x, y)
    let (</>) x y = Divide(x, y)

    // A model to create a simple arithmetic expression tree has been provided
    // Write a function 'evaluate' that calculates the value of the expression

    let rec evaluate expr =
        __

    [<Test>]
    let ``Question 09 - Test Case 01``() =
        let expr = (num 1.) <+> (num 2.)
        let actualValue = evaluate expr
        let expectedValue = 3.

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 09 - Test Case 02``() =
        let expr = ((num 6.) <+> (num 4.)) </> (num 2.)
        let actualValue = evaluate expr
        let expectedValue = 5.

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 09 - Test Case 03``() =
        let expr = ((num 7.) <*> (num 4.)) <-> (num 3.)
        let actualValue = evaluate expr
        let expectedValue = 25.

        AssertEquality expectedValue actualValue


