namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay3_1ArmstrongNumbers =

    // An [Armstrong number](https://en.wikipedia.org/wiki/Narcissistic_number) is a number that is the sum of its own digits each raised to the power of the number of digits.

    // For example:

    // - 9 is an Armstrong number, because `9 = 9^1 = 9`
    // - 10 is *not* an Armstrong number, because `10 != 1^2 + 0^2 = 1`
    // - 153 is an Armstrong number, because: `153 = 1^3 + 5^3 + 3^3 = 1 + 125 + 27 = 153`
    // - 154 is *not* an Armstrong number, because: `154 != 1^3 + 5^3 + 4^3 = 1 + 125 + 64 = 190`

    // Write some code to determine whether a number is an Armstrong number.


    let isArmstrongNumber (number: int): bool = __

    [<Test>]
    let ``ArmstrongNumbers - Zero is an Armstrong number`` () =
        isArmstrongNumber 0 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``ArmstrongNumbers - Single-digit numbers are Armstrong numbers`` () =
        isArmstrongNumber 5 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``ArmstrongNumbers - There are no two-digit Armstrong numbers`` () =
        isArmstrongNumber 10 |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``ArmstrongNumbers - Three-digit number that is an Armstrong number`` () =
        isArmstrongNumber 153 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``ArmstrongNumbers - Three-digit number that is not an Armstrong number`` () =
        isArmstrongNumber 100 |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``ArmstrongNumbers - Four-digit number that is an Armstrong number`` () =
        isArmstrongNumber 9474 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``ArmstrongNumbers - Four-digit number that is not an Armstrong number`` () =
        isArmstrongNumber 9475 |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``ArmstrongNumbers - Seven-digit number that is an Armstrong number`` () =
        isArmstrongNumber 9926315 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``ArmstrongNumbers - Seven-digit number that is not an Armstrong number`` () =
        isArmstrongNumber 9926314 |> AssertEquality false
