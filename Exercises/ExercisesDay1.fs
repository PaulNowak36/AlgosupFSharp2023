namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

module ExercisesDay1 =

    [<Test>]
    let AssertExpectation() =
        let expectedValue = 1 + 1
        let actualValue = 2
        AssertEquality expectedValue actualValue

    //Easy, right? Now try one more
    [<Test>]
    let FillInValues() =
        AssertEquality (1 + 1) 2

    [<Test>]
    let HexadecimalsLiterals() =
        let actualValue = 0x56 + 0x0F

        AssertEquality 101 actualValue

    [<Test>]
    let BinaryLiterals() =
        let actualValue = 0b00100101 + 0b00001010

        AssertEquality 47 actualValue

    [<Test>]
    let NestedScopes() =
        let actualValue =
            let x = 71 + 12
            x

        AssertEquality 83 actualValue

    [<Test>]
    let StringConcatValue() =
        let message = "hello, " + "world!"

        AssertEquality message "hello, world!"

    [<Test>]
    let FormatStringLiterals() =
        let num = 0x7D
        let actualValue = $"An interesting number: '{num}'"

        AssertEquality "An interesting number: '125'" actualValue

    [<Test>]
    let AppendingToAList() =
        let initialValue = [2; 3]

        let result = 1 :: initialValue

        AssertEquality [1; 2; 3] result

    [<Test>]
    let FirstFunction() =
        let compute x = x * 7

        let result1 = compute 2
        let result2 = compute 5
        let result3 = compute 7
        let result4 = compute 9

        AssertEquality 14 result1
        AssertEquality 35 result2
        AssertEquality 49 result3
        AssertEquality 63 result4

    [<Test>]
    let NestingFunctions() =
        let quadruple x =
            let double x =
                x * 2

            double(double(x))

        let result = quadruple 7
        AssertEquality result 28

    [<Test>]
    let VariablesInTheParentScopeCanBeAccessed() =
        let suffix = "!!!!"

        let caffeinated (text:string) =
            let exclaimed = text.Trim() + suffix
            let yelled = exclaimed.ToUpper()
            yelled

        let caffeinatedReply = caffeinated "welcome here"

        AssertEquality caffeinatedReply "WELCOME HERE!!!!"

    [<Test>]
    let FirstPartialFunction() =
        let sub x y = x - y

        let subFrom49 = sub 49

        let result1 = subFrom49 10
        let result2 = subFrom49 20
        let result3 = subFrom49 30
        let result4 = subFrom49 40

        AssertEquality 39 result1
        AssertEquality 29 result2
        AssertEquality 19 result3
        AssertEquality 09 result4

    [<Test>]
    let SometimesYouNeedParenthesisToGroupThings() =
        let add x y =
            x + y

        // TRY IT: What happens if you remove the parenthesis?
        let result = add (add 5 7) (add 2 2)

        AssertEquality result 16

    [<Test>]
    let StringFormattingRevisited() =
        // It's time to apply what you've learned so far. Fill in the function below to
        // make the asserts pass
        let getFunFacts x =
            $"{x} doubled is {x*2}, and {x} tripled is {x*3}!"

        let funFactsAboutThree = getFunFacts 2
        let funFactsAboutSix = getFunFacts 7

        AssertEquality "2 doubled is 4, and 2 tripled is 6!" funFactsAboutThree
        AssertEquality "7 doubled is 14, and 7 tripled is 21!" funFactsAboutSix

    [<Test>]
    let CreatingLists() =
        let list = ["pear"; "apple"; "grape"; "peach"]

        //Note: The list data type in F# is a singly linked list,
        //      so indexing elements is O(n).

        AssertEquality list.Head "pear"
        AssertEquality list.Tail ["apple"; "grape"; "peach"]
        AssertEquality list.Length 4

    [<Test>]
    let CreatingListsWithARange() =
        let list = [0..3]

        AssertEquality list.Head 0
        AssertEquality list.Tail [1; 2; 3]

    [<Test>]
    let ReversingAList() =
        let initialValue = [2; 3; 4]

        let result = List.rev initialValue

        AssertEquality [4; 3; 2] result

    [<Test>]
    let SortingAList() =
        let initialValue = [9; 8; 9; 5; 4]

        let result = List.sort initialValue

        AssertEquality [4; 5; 8; 9; 9] result

    [<Test>]
    let SortingAWordListByLength() =
        let initialValue = ["April"; "is"; "the"; "cruelest"; "month"; ]

        let result = initialValue |> List.sortBy()

        AssertEquality ["is"; "the"; "April"; "month"; "cruelest"] result

    [<Ignore("Not implemented");Test>]
    let SquareNumberList() =
        let initialValue = [1 .. 6]

        let result = initialValue |> __

        AssertEquality [1; 4; 9; 16; 25; 36] result

    [<Ignore("Not implemented");Test>]
    let ConvertNumbersToString() =
        let initialValue = [2 .. 6]

        let result = initialValue |> __

        AssertEquality ["2"; "3"; "4"; "5"; "6"] result

    [<Ignore("Not implemented");Test>]
    let MultiplyAllElementsBy10() =
        let initialValue = [0 .. 4]

        let result = initialValue |> __

        AssertEquality [0; 10; 20; 30; 40;] result

    [<Ignore("Not implemented");Test>]
    let CountNumberOfUniqueWords() =
        let initialValue =
            ["water"; "water"; "every"; "where";
             "nor"; "any"; "drop"; "to"; "drink" ]

        let result = initialValue |> __

        AssertEquality 8 result

    [<Ignore("Not implemented");Test>]
    let FindLargestNumberInAList() =
        let initialValue = [22; 6; 72; 33; 45; 10; 21; 67]

        let result = initialValue |> __

        AssertEquality 72 result

    [<Ignore("Not implemented");Test>]
    let SumAList() =
        let initialValue = [1 .. 6]

        let result = __

        AssertEquality 21 result

    [<Ignore("Not implemented");Test>]
    let FilterOutOddNumberFromAList() =
        let initialValue = [3 .. 12]

        let result = initialValue |> __

        AssertEquality [4; 6; 8; 10; 12] result

    [<Ignore("Not implemented");Test>]
    let SumTheIntegersContainedInTheStrings() =
        let initialValue = [ "22"; "10"; "3"; "20" ]

        let result = initialValue |> __

        AssertEquality result 55

    [<Ignore("Not implemented");Test>]
    let ComputerTheAverageNumberOfLetters() =
        let initialValue =
            ["It"; "is"; "an"; "ancient"; "Mariner";
             "And"; "he"; "stoppeth"; "one"; "of"; "three";
             "By"; "thy"; "long"; "grey"; "beard"; "and"; "glittering"; "eye";
             "Now"; "wherefore"; "stoppst"; "thou"; "me"]

        let result = __

        AssertEquality
            4.25
            result

    [<Ignore("Not implemented");Test>]
    let TestIfEverWordContainsTheLetterA() =
        let test (l: list<string>) =
            __

        AssertEquality
            true
            (test ["day"; "after"; "day"; "day"; "after"; "day"])

        AssertEquality
            false
            (test ["we"; "stuck"; "nor"; "breath"; "nor"; "motion"])


    [<Ignore("Not implemented");Test>]
    let CaesarCipher() =
        let initialValue = "Encode me!" |> List.ofSeq

        let encoder (l: list<char>) =
            __

        let encoded = encoder initialValue
        let decoded = encoder encoded

        AssertEquality
            ['R'; 'a'; 'p'; 'b'; 'q'; 'r'; ' '; 'z'; 'r'; '!']
            encoded

        AssertEquality
            ['E'; 'n'; 'c'; 'o'; 'd'; 'e'; ' '; 'm'; 'e'; '!']
            decoded

    [<Ignore("Not implemented");Test>]
    let TestIfAWordHasNoRepeatingLetter() =
        let test (s: string) =
            __

        AssertEquality
            true
            (test "cornflakes")

        AssertEquality
            false
            (test "cheerios")

    [<Ignore("Not implemented");Test>]
    let SumSquareDifference() =
        // The sum of the squares of the first ten natural numbers is (1^2 + 1^2 + 3^2 .. 10^2)
        // The square of the sum of the first ten natural numbers is (1 + 1 + 3 .. 10) ^2
        let sumOfSquares = [ 1 .. 10 ] |> __
        let squareOfTheSum = [ 1 .. 10 ] |> __

        AssertEquality (sumOfSquares - squareOfTheSum) 2640

    [<Ignore("Not implemented");Test>]
    let FindTheSumOfAllTheMultiples() =
        // Find the sum of all the multiples of 3 or 5 below 1000.

        let result = __

        AssertEquality result 233168