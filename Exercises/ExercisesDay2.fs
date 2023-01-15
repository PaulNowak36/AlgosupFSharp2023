namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

module ExercisesUnit3 =

    [<Ignore("Not implemented");Test>]
    let LetInfersTheTypesOfValuesWherePossible() =
        let x = 50
        let typeOfX = x.GetType()

        let y = "a string"
        let typeOfY = y.GetType()

        AssertEquality typeOfX typeof<FILL_ME_IN>
        AssertEquality typeOfY typeof<FILL_ME_IN>

    [<Ignore("Not implemented");Test>]
    let YouCanMakeTypesExplicit() =
        // the only difference from the previous test is the type annotations
        // which can sometimes be useful
        let (x:int) = 42
        let typeOfX = x.GetType()

        let y:string = "forty two"
        let typeOfY = y.GetType()

        AssertEquality typeOfX typeof<FILL_ME_IN>
        AssertEquality typeOfY typeof<FILL_ME_IN>

    [<Ignore("Not implemented");Test>]
    let FloatsAndInts() =
        let x = 20
        let typeOfX = x.GetType()

        let y = 20.0
        let typeOfY = y.GetType()

        AssertEquality typeOfX typeof<FILL_ME_IN>
        AssertEquality typeOfY typeof<FILL_ME_IN>

    type MyTypeAlias = FILL_ME_IN

    [<Ignore("Not implemented");Test>]
    let TypeAliasInAction() =
        let t = typeof<MyTypeAlias>

        //you don't need to modify these
        AssertEquality t typeof<obj>

    [<Ignore("Not implemented");Test>]
    let CreatingTuples() =
        let actualValue = (__, 2)

        AssertEquality ("one", 2) actualValue

    [<Ignore("Not implemented");Test>]
    let CreatingTuplesMoreTuples() =
        let actualValue = (__, 2, __, __)

        AssertEquality ("one", 2, 3., 4) actualValue

    [<Ignore("Not implemented");Test>]
    let AccessingTupleElements() =
        let items = ("apple", "dog")

        // fst and snd are definited in the F# standard library, can you guess what they mean?

        let fruit = fst items
        let animal = snd items

        AssertEquality fruit __
        AssertEquality animal __

    [<Ignore("Not implemented");Test>]
    let AccessingTupleElementsWithPatternMatching() =

        let items = ("apple", "dog", "Mustang")

        let fruit, animal, car = items

        AssertEquality fruit __
        AssertEquality animal __
        AssertEquality car __


    [<Ignore("Not implemented");Test>]
    let ReturningMultipleValuesFromAFunction() =
        let squareAndCube x =
            (x ** 2.0, x ** 3.0)

        let squared, cubed = squareAndCube 3.0


        AssertEquality squared __
        AssertEquality cubed __

    [<Ignore("Not implemented");Test>]
    let SwappingTuples() =
        let swap tuple = __

        AssertEquality ('b', 'a') (swap ('a', 'b'))
        AssertEquality (2, 1) (swap (1, 2))
        AssertEquality (2., 1.) (swap (1., 2.))
        AssertEquality ("two", "one") (swap ("one", "two"))

    [<Ignore("Not implemented");Test>]
    let PrettyPrintingTuples() =
        let input = (__, __, __)

        let actualValue = __

        AssertEquality "(6, seven, 8)" actualValue

    type Person =
        { FirstName: string;
          LastName: string; }

    [<Ignore("Not implemented");Test>]
    let AccessingMembers() =
        let input =
            { FirstName = "Robert";
              LastName = "Pickering" }

        let actualValue1 = __
        let actualValue2 = __

        AssertEquality "Pickering" actualValue1
        AssertEquality "Robert" actualValue2

    [<Ignore("Not implemented");Test>]
    let UpdatingRecords() =
        let input =
            { FirstName = "Robert";
              LastName = "Pickering" }

        let actualValue1 = __
        let actualValue2 = __
        let actualValue3 = __

        AssertEquality { FirstName = "Fred"; LastName = "Pickering" } actualValue1
        AssertEquality { FirstName = "Fran"; LastName = "Pickering" } actualValue2
        AssertEquality { FirstName = "Robert"; LastName = "Zimmerman" } actualValue3

    [<Ignore("Not implemented");Test>]
    let SomeSimplePatternMatching() =

        let numberConverter x =
            match x with
            // add other cases here!
            | _ -> "unintresting"

        AssertEquality "the first number" (numberConverter 1)
        AssertEquality "lucky" (numberConverter 7)
        AssertEquality "baker's dozen" (numberConverter 13)

    type Condiment =
        | Mustard
        | Ketchup
        | Relish
        | Vinegar

    [<Ignore("Not implemented");Test>]
    let DiscriminatedUnionsCaptureASetOfOptions() =

        let toColor condiment =
            match condiment with
            | Mustard -> "yellow"
            | Ketchup -> "red"
            | Relish -> "green"
            | Vinegar -> "brownish?"

        let choice = Mustard

        AssertEquality (toColor choice) __

    [<Ignore("Not implemented");Test>]
    let OptionTypesMightContainAValue() =
        let someValue = Some 10

        AssertEquality someValue.IsSome __
        AssertEquality someValue.IsNone __
        AssertEquality someValue.Value __

    [<Ignore("Not implemented");Test>]
    let OrTheyMightNot() =
        let noValue = None

        AssertEquality noValue.IsSome __
        AssertEquality noValue.IsNone __
        AssertThrows<FILL_IN_THE_EXCEPTION> (fun () -> noValue.Value)

    type Game =
        { Name: string
          Platform: string
          Score: int option }

    [<Ignore("Not implemented");Test>]
    let UsingOptionTypesWithPatternMatching() =
        let chronoTrigger = { Name = "Chrono Trigger"; Platform = "SNES"; Score = Some 5 }
        let halo = { Name = "Halo"; Platform = "Xbox"; Score = None }

        let translate score =
            match score with
            | 5 -> "Great"
            | 4 -> "Good"
            | 3 -> "Decent"
            | 2 -> "Bad"
            | 1 -> "Awful"
            | _ -> "Unknown"

        let getScore game =
            match game.Score with
            | Some score -> translate score
            | None -> "Unknown"

        AssertEquality (getScore chronoTrigger) __
        AssertEquality (getScore halo) __

    [<Ignore("Not implemented");Test>]
    let FindingJustOneOrZeroItem() =
        let names = [ "Alice"; "Bob"; "Eve"; ]

        // tryFind returns an option so you can handle 0 rows returned
        let eve =
            names
            |> List.tryFind (fun name -> name = "Eve" )
        let zelda =
            names
            |> List.tryFind (fun name -> name = "Zelda" )

        AssertEquality eve __
        AssertEquality zelda __

    [<Ignore("Not implemented");Test>]
    let CreatingListsWithComprehensions() =
        let list = [for i in 0..4 do yield i ]

        AssertEquality list __

    [<Ignore("Not implemented");Test>]
    let ComprehensionsWithConditions() =
        let list = [for i in 0..10 do
                        if i % 2 = 0 then yield i ]

        AssertEquality list __

    [<Ignore("Not implemented");Test>]
    let TransformingListsWithMap() =
        let square x =
            x * x

        let original = [0..5]
        let result = List.map square original

        AssertEquality original __
        AssertEquality result __

    [<Ignore("Not implemented");Test>]
    let FilteringListsWithFilter() =
        let isEven x =
            x % 2 = 0

        let original = [0..5]
        let result = List.filter isEven original

        AssertEquality original __
        AssertEquality result __

    [<Ignore("Not implemented");Test>]
    let DividingListsWithPartition() =
        let isOdd x =
            x % 2 <> 0

        let original = [0..5]
        let result1, result2 = List.partition isOdd original

        AssertEquality result1 __
        AssertEquality result2 __

    [<Ignore("Not implemented");Test>]
    let CreatingArrays() =
        let fruits = [| "apple"; "pear"; "peach"|]

        AssertEquality fruits.[0] __
        AssertEquality fruits.[1] __
        AssertEquality fruits.[2] __

    [<Ignore("Not implemented");Test>]
    let ArraysAreMutable() =
        let fruits = [| "apple"; "pear" |]
        fruits.[1] <- "peach"

        AssertEquality fruits __

    [<Ignore("Not implemented");Test>]
    let YouCanCreateArraysWithComprehensions() =
        let numbers =
            [| for i in 0..10 do
                   if i % 2 = 0 then yield i |]

        AssertEquality numbers __

    [<Ignore("Not implemented");Test>]
    let ThereAreAlsoSomeOperationsYouCanPerformOnArrays() =
        let cube x =
            x * x * x

        let original = [| 0..5 |]
        let result = Array.map cube original

        AssertEquality original __
        AssertEquality result __

    [<Ignore("Not implemented");Test>]
    let SkippingElements() =
        let original = [0..5]
        let result = Seq.skip 2 original

        AssertEquality result __

    [<Ignore("Not implemented");Test>]
    let FindingTheMax() =
        let values = new ResizeArray<int>()

        values.Add(11)
        values.Add(20)
        values.Add(4)
        values.Add(2)
        values.Add(3)

        let result = Seq.max values

        AssertEquality result __

    [<Ignore("Not implemented");Test>]
    let FindingTheMaxUsingACondition() =
        let getNameLength (name:string) =
            name.Length

        let names = [| "Harry"; "Lloyd"; "Nicholas"; "Mary"; "Joe"; |]
        let result = Seq.maxBy getNameLength names

        AssertEquality result __

    [<Ignore("Not implemented");Test>]
    let MaxMinSum() =
        // Given five positive integers, find the minimum and maximum values that can be calculated by
        // summing exactly four of the five integers. Then print the respective minimum and maximum
        // values as a single line of two space-separated long integers.

        let calculateMaxMin centimes =
            __

        AssertEquality (16, 24) (calculateMaxMin [1;3;5;7;9])
        AssertEquality (10, 14) (calculateMaxMin [1;2;3;4;5])

    [<Ignore("Not implemented");Test>]
    let FizzBuzzCodingTest() =
        // The FizzBuzz problem is a classic test given in coding interviews. The task
        // is simple: Print integers 1 to N, but print “Fizz” if an integer is divisible
        // by 3, “Buzz” if an integer is divisible by 5, and “FizzBuzz” if an integer
        // is divisible by both 3 and 5. In this case the results should be in the form
        // of an F# list.

        let fizzBuzzList n =
            __

        let result = ["1"; "2"; "Fizz"; "4"; "Buzz"; "Fizz"; "7"; "8"; "Fizz"; "Buzz"; "11"; "Fizz"; "13"; "14"; "FizzBuzz"; "16"; "17"; "Fizz"; "19"; "Buzz"]

        AssertEquality result (fizzBuzzList 20)