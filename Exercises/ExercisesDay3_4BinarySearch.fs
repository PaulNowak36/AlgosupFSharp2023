namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay3_4BinarySearch =

    // Implement a binary search algorithm.

    // Searching a sorted collection is a common task. A dictionary is a sorted
    // list of word definitions. Given a word, one can find its definition. A
    // telephone book is a sorted list of people's names, addresses, and
    // telephone numbers. Knowing someone's name allows one to quickly find
    // their telephone number and address.

    // If the list to be searched contains more than a few items (a dozen, say)
    // a binary search will require far fewer comparisons than a linear search,
    // but it imposes the requirement that the list be sorted.

    // In computer science, a binary search or half-interval search algorithm
    // finds the position of a specified input value (the search "key") within
    // an array sorted by key value.

    // In each step, the algorithm compares the search key value with the key
    // value of the middle element of the array.

    // If the keys match, then a matching element has been found and its index,
    // or position, is returned.

    // Otherwise, if the search key is less than the middle element's key, then
    // the algorithm repeats its action on the sub-array to the left of the
    // middle element or, if the search key is greater, on the sub-array to the
    // right.

    // If the remaining array to be searched is empty, then the key cannot be
    // found in the array and a special "not found" indication is returned.

    // A binary search halves the number of items to check with each iteration,
    // so locating an item (or determining its absence) takes logarithmic time.
    // A binary search is a dichotomic divide and conquer search algorithm.

    let find input value = __

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - Finds a value in an array with one element`` () =
        let array = [|6|]
        let value = 6
        let expected = Some 0
        find array value |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - Finds a value in the middle of an array`` () =
        let array = [|1; 3; 4; 6; 8; 9; 11|]
        let value = 6
        let expected = Some 3
        find array value |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - Finds a value at the beginning of an array`` () =
        let array = [|1; 3; 4; 6; 8; 9; 11|]
        let value = 1
        let expected = Some 0
        find array value |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - Finds a value at the end of an array`` () =
        let array = [|1; 3; 4; 6; 8; 9; 11|]
        let value = 11
        let expected = Some 6
        find array value |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - Finds a value in an array of odd length`` () =
        let array = [|1; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377; 634|]
        let value = 144
        let expected = Some 9
        find array value |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - Finds a value in an array of even length`` () =
        let array = [|1; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377|]
        let value = 21
        let expected = Some 5
        find array value |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - Identifies that a value is not included in the array`` () =
        let array = [|1; 3; 4; 6; 8; 9; 11|]
        let value = 7
        let expected = None
        find array value |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - A value smaller than the array's smallest value is not found`` () =
        let array = [|1; 3; 4; 6; 8; 9; 11|]
        let value = 0
        let expected = None
        find array value |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - A value larger than the array's largest value is not found`` () =
        let array = [|1; 3; 4; 6; 8; 9; 11|]
        let value = 13
        let expected = None
        find array value |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - Nothing is found in an empty array`` () =
        let array = [||]
        let value = 1
        let expected = None
        find array value |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``BinarySearch - Nothing is found when the left and right bounds cross`` () =
        let array = [|1; 2|]
        let value = 0
        let expected = None
        find array value |> AssertEquality expected

