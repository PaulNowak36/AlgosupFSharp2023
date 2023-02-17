namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

module Question01 =
    // The function 'compute' receives a list of numbers as a parameter.
    // It should compute a new list, where every number has been doubled.

    let compute (numbers: list<int>) = __

    [<Test>]
    let ``Question 01 - Test Case 01``() =
        let actualValue = compute [ 1 .. 3 ]
        let expectedValue = [ 2; 4; 6 ]

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 01 - Test Case 02``() =
        let actualValue = compute [ 4 .. 6 ]
        let expectedValue = [ 8; 10; 12 ]

        AssertEquality expectedValue actualValue