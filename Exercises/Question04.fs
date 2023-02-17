﻿namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

module Question04 =

    // "Reverse words in a sentence":

    // Given a sentence, reverse the order of the words in the sentence. Do not reverse the
    // order of the characters within the words.

    // Example:

    //     Input: "The quick brown fox jumps over the lazy dog"
    //     Output: "dog lazy the over jumps fox brown quick The"

    let reverseWords (sentence:string) = __

    [<Test>]
    let ``Question 04 - Test Case 01``() =
        let sentence = "The quick brown fox jumps over the lazy dog"
        let actualValue = reverseWords sentence
        let expectedValue = "dog lazy the over jumps fox brown quick The"

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 04 - Test Case 02``() =
        let sentence = "This is a test"
        let actualValue = reverseWords sentence
        let expectedValue = "test a is This"

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 04 - Test Case 03``() =
        let sentence = "One two three four five"
        let actualValue = reverseWords sentence
        let expectedValue = "five four three two One"

        AssertEquality expectedValue actualValue

