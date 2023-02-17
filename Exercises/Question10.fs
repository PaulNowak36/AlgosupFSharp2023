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

    type EvaluationResult =
        | EvaluationResult of int

    let evalRPN (expression: string) =
     

        let evaluateExpression (stack: int list) (expression: Expression): int list =
            match expression, stack with
            | OperandExpression(Integer operand), _ -> operand :: stack
            | OperatorExpression Add, x :: y :: xs -> y + x :: xs
            | OperatorExpression Sub, x :: y :: xs -> y - x :: xs
            | OperatorExpression Mul, x :: y :: xs -> y * x :: xs
            | OperatorExpression Div, x :: y :: xs -> y / x :: xs
            | _, _ -> failwith "Invalid expression"

        let evaluateEquation (Equation expressions): EvaluationResult =
            expressions
            |> List.fold evaluateExpression []
            |> List.head
            |> EvaluationResult

        let evaluate (str: string): Result<EvaluationResult, EquationError> =
            parse str |> Result.map evaluateEquation
        



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
