// ================================================================
// F# Simple Examples
// Let's build some intuition about how F# works
// ================================================================


open System





// These are examples of different types of numbers
let value = 1

let sampleInteger = 176

let sampleDouble = 4.1










// Of course arithmetic operations on numbers are possible

let newInt = sampleInteger + 3

let newDouble = sampleDouble + 8.4














// to add two numbers of different types you need to make an
// explicit conversion

let anotherFloat = float newInt + newDouble

let anotherInt = newInt + int newDouble










// Examples of booleans

let initBool = true

let nextBool = initBool || false

let anotherBool = initBool && false














// Strings are very common too

let name = "Robert"

let numberOfCharacters = name.Length

let containsO = name.Contains("o")

let blockCaps = name.ToUpper()
















// strings are made up of characters

let character = 'c'

let reversed = Seq.rev name |> Seq.toList



let reversedAsArray = reversed |> Seq.toArray

let reversedAsString = new string(reversedAsArray)













// Let's a defining - to make reuse easy

let operation x =
    (x * x) + x

operation 1
operation 2
operation 3












// working with list

let numbers = [ 1 .. 10 ]

numbers |> List.map operation
















// Creating objects

let rnd = new Random()

let diceRoll = rnd.Next(1, 7)













// Checking conditions

let aBoolean = 3 > 4

let commentNumber x=
    let successCondition = x > 18
    if successCondition then
        "Good"
    else
        "Bad"

commentNumber 17
commentNumber 19

let scores = [ 16 .. 20 ]

List.map commentNumber scores
