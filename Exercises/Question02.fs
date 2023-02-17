namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

module Question02 =

    // The function 'averageNumberLetter' receives a list of words,
    // you should provide an implementation that calculates the average (mean)
    // number of letters per word

    let averageNumberLetter (wordList: list<string>) =  __

    [<Test>]
    let ``Question 02 - Test Case 01``() =
        let inputText = [ "I"; "have"; "a"; "dream" ]
        let actualValue = averageNumberLetter inputText
        let expectedValue = 2.75

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 02 - Test Case 02``() =
        let inputText = [ "Fondly"; "do"; "we"; "hope"; "fervently"; "do"; "we"; "pray";  ]
        let actualValue = averageNumberLetter inputText
        let expectedValue = 3.875

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 02 - Test Case 03``() =
        let inputText = [ "The"; "world"; "must"; "be"; "made"; "safe"; "for"; "democracy"; ]
        let actualValue = averageNumberLetter inputText
        let expectedValue = 4.25

        AssertEquality expectedValue actualValue


