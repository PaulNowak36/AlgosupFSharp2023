namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

module Question07 =
    open System

    // "Palindrome Checker":

    // Write a program that takes a string as input and returns whether the string is a palindrome or
    // not. A palindrome is a word, phrase, number, or other sequence of characters which reads the
    // same backward or forward. Ignore spaces, punctuation and capitalization when checking for palindromes.

    // Examples:

    //     Input: "racecar" Output: "true"
    //     Input: "A man, a plan, a canal: Panama" Output: "true"
    //     Input: "hello" Output: "false"

    let isPalindrome (s:string) = __
        //  let rec fn(a,b)=a>b||str.[a]=str.[b]&&fn(a+1,b-1)
        //     fn(0,str.Length-1)

    [<Test>]
    let ``Question 07 - Test Case 01``() =
        let actualValue = isPalindrome "racecar"
        let expectedValue = true

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 07 - Test Case 02``() =
        let actualValue = isPalindrome "A man, a plan, a canal: Panama"
        let expectedValue = true

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 07 - Test Case 03``() =
        let actualValue = isPalindrome "hello"
        let expectedValue = false

        AssertEquality expectedValue actualValue


