namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework


module Question08 =

    // "Find the missing number":

    // You are given an array of n-1 integers and these integers are in the range of 1 to n. There are no duplicates
    // in the array. One of the integers is missing in the array. Write a function to find the missing integer.

    let findMissing (arr:int[]) =
        let max = 
            arr |> Array.max
        
        let min = 
            arr |> Array.min
        
        let newArray = [|min..max|]

        newArray |> Array.except arr |> Array.item 0

    [<Test>]
    let ``Question 08 - Test Case 01``() =
        let arr = [|1; 2; 4; 6; 3; 7; 8|]
        let actualValue = findMissing arr
        let expectedValue = 5

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 08 - Test Case 02``() =
        let arr = [|2; 3; 5; 1; 7; 8; 4|]
        let actualValue = findMissing arr
        let expectedValue = 6

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 08 - Test Case 03``() =
        let arr = [|4; 3; 1; 6; 8; 7; 9; 5; 10|]
        let actualValue = findMissing arr
        let expectedValue = 2

        AssertEquality expectedValue actualValue


