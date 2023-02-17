namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

module Question10 =
    open System.Collections.Generic

    // "Reverse Polish Notation Calculator":

    // Create a program that takes an input of a mathematical expression in "reverse Polish notation" (RPN)
    // and returns the result of the calculation. RPN is a way of writing mathematical expressions where the
    // operator comes after the operands, for example, "2 3 +" would represent the expression "2 + 3". The
    // program should handle the basic mathematical operators (+, -, *, /) and handle any number of digits.

    // Examples:

    //     Input: "2 3 +" Output: "5"
    //     Input: "2 3 4 * +" Output: "14"
    //     Input: "2 3 4 * 5 + *" Output: "26"

    let evalRPN (expression: string) =
         __



    [<Test>]
    let ``Question 10 - Test Case 01``() =
        let actualValue = evalRPN "2 3 +"

        AssertEquality 5 actualValue

    [<Test>]
    let ``Question 10 - Test Case 02``() =
        let actualValue = evalRPN "2 3 4 * +"

        AssertEquality 14 actualValue

    [<Test>]
    let ``Question 10 - Test Case 03``() =
        let actualValue = evalRPN "2 3 4 * 5 + *"

        AssertEquality 34 actualValue
