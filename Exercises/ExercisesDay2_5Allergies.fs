namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay2_5Allergies =
    // Given a person's allergy score, determine whether or not they're allergic to a given item, and their full list of allergies.

    // An allergy test produces a single numeric score which contains the
    // information about all the allergies the person has (that they were
    // tested for).

    // The list of items (and their value) that were tested are:

    // * eggs (1)
    // * peanuts (2)
    // * shellfish (4)
    // * strawberries (8)
    // * tomatoes (16)
    // * chocolate (32)
    // * pollen (64)
    // * cats (128)

    // So if Tom is allergic to peanuts and chocolate, he gets a score of 34.

    // Now, given just that score of 34, your program should be able to say:

    // * Whether Tom is allergic to any one of those allergens listed above.
    // * All the allergens Tom is allergic to.

    // Note: a given score may include allergens **not** listed above (i.e.
    // allergens that score 256, 512, 1024, etc.).  Your program should
    // ignore those components of the score.  For example, if the allergy
    // score is 257, your program should only report the eggs (1) allergy.

    type Allergen =
    | Eggs = 1
    | Peanuts = 2
    | Shellfish = 4
    | Strawberries = 8
    | Tomatoes = 16
    | Chocolate =32
    | Pollen = 64
    | Cats = 128

    let allergicTo codedAllergies allergen =
        (codedAllergies &&& (int allergen)) <> 0

    let list codedAllergies =
        [for allergen in [Allergen.Eggs; Allergen.Peanuts; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats] do
             if(codedAllergies &&& (int allergen)) <> 0 then
             yield allergen]

    [<Test>]
    let ``Allergies - Testing for eggs allergy - not allergic to anything`` () =
        allergicTo 0 Allergen.Eggs |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for eggs allergy - allergic only to eggs`` () =
        allergicTo 1 Allergen.Eggs |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for eggs allergy - allergic to eggs and something else`` () =
        allergicTo 3 Allergen.Eggs |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for eggs allergy - allergic to something, but not eggs`` () =
        allergicTo 2 Allergen.Eggs |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for eggs allergy - allergic to everything`` () =
        allergicTo 255 Allergen.Eggs |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for peanuts allergy - not allergic to anything`` () =
        allergicTo 0 Allergen.Peanuts |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for peanuts allergy - allergic only to peanuts`` () =
        allergicTo 2 Allergen.Peanuts |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for peanuts allergy - allergic to peanuts and something else`` () =
        allergicTo 7 Allergen.Peanuts |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for peanuts allergy - allergic to something, but not peanuts`` () =
        allergicTo 5 Allergen.Peanuts |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for peanuts allergy - allergic to everything`` () =
        allergicTo 255 Allergen.Peanuts |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for shellfish allergy - not allergic to anything`` () =
        allergicTo 0 Allergen.Shellfish |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for shellfish allergy - allergic only to shellfish`` () =
        allergicTo 4 Allergen.Shellfish |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for shellfish allergy - allergic to shellfish and something else`` () =
        allergicTo 14 Allergen.Shellfish |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for shellfish allergy - allergic to something, but not shellfish`` () =
        allergicTo 10 Allergen.Shellfish |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for shellfish allergy - allergic to everything`` () =
        allergicTo 255 Allergen.Shellfish |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for strawberries allergy - not allergic to anything`` () =
        allergicTo 0 Allergen.Strawberries |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for strawberries allergy - allergic only to strawberries`` () =
        allergicTo 8 Allergen.Strawberries |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for strawberries allergy - allergic to strawberries and something else`` () =
        allergicTo 28 Allergen.Strawberries |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for strawberries allergy - allergic to something, but not strawberries`` () =
        allergicTo 20 Allergen.Strawberries |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for strawberries allergy - allergic to everything`` () =
        allergicTo 255 Allergen.Strawberries |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for tomatoes allergy - not allergic to anything`` () =
        allergicTo 0 Allergen.Tomatoes |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for tomatoes allergy - allergic only to tomatoes`` () =
        allergicTo 16 Allergen.Tomatoes |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for tomatoes allergy - allergic to tomatoes and something else`` () =
        allergicTo 56 Allergen.Tomatoes |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for tomatoes allergy - allergic to something, but not tomatoes`` () =
        allergicTo 40 Allergen.Tomatoes |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for tomatoes allergy - allergic to everything`` () =
        allergicTo 255 Allergen.Tomatoes |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for chocolate allergy - not allergic to anything`` () =
        allergicTo 0 Allergen.Chocolate |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for chocolate allergy - allergic only to chocolate`` () =
        allergicTo 32 Allergen.Chocolate |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for chocolate allergy - allergic to chocolate and something else`` () =
        allergicTo 112 Allergen.Chocolate |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for chocolate allergy - allergic to something, but not chocolate`` () =
        allergicTo 80 Allergen.Chocolate |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for chocolate allergy - allergic to everything`` () =
        allergicTo 255 Allergen.Chocolate |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for pollen allergy - not allergic to anything`` () =
        allergicTo 0 Allergen.Pollen |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for pollen allergy - allergic only to pollen`` () =
        allergicTo 64 Allergen.Pollen |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for pollen allergy - allergic to pollen and something else`` () =
        allergicTo 224 Allergen.Pollen |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for pollen allergy - allergic to something, but not pollen`` () =
        allergicTo 160 Allergen.Pollen |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for pollen allergy - allergic to everything`` () =
        allergicTo 255 Allergen.Pollen |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for cats allergy - not allergic to anything`` () =
        allergicTo 0 Allergen.Cats |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for cats allergy - allergic only to cats`` () =
        allergicTo 128 Allergen.Cats |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for cats allergy - allergic to cats and something else`` () =
        allergicTo 192 Allergen.Cats |> AssertEquality true

    [<Test>]
    let ``Allergies - Testing for cats allergy - allergic to something, but not cats`` () =
        allergicTo 64 Allergen.Cats |> AssertEquality false

    [<Test>]
    let ``Allergies - Testing for cats allergy - allergic to everything`` () =
        allergicTo 255 Allergen.Cats |> AssertEquality true

    [<Test>]
    let ``Allergies - List - no allergies`` () =
        list 0 |> AssertEquality []

    [<Test>]
    let ``Allergies - List - just eggs`` () =
        list 1 |> AssertEquality [Allergen.Eggs]

    [<Test>]
    let ``Allergies - List - just peanuts`` () =
        list 2 |> AssertEquality [Allergen.Peanuts]

    [<Test>]
    let ``Allergies - List - just strawberries`` () =
        list 8 |> AssertEquality [Allergen.Strawberries]

    [<Test>]
    let ``Allergies - List - eggs and peanuts`` () =
        list 3 |> AssertEquality [Allergen.Eggs; Allergen.Peanuts]

    [<Test>]
    let ``Allergies - List - more than eggs but not peanuts`` () =
        list 5 |> AssertEquality [Allergen.Eggs; Allergen.Shellfish]

    [<Test>]
    let ``Allergies - List - lots of stuff`` () =
        list 248 |> AssertEquality [Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

    [<Test>]
    let ``Allergies - List - everything`` () =
        list 255 |> AssertEquality [Allergen.Eggs; Allergen.Peanuts; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

    [<Test>]
    let ``Allergies - List - no allergen score parts`` () =
        list 509 |> AssertEquality [Allergen.Eggs; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

    [<Test>]
    let ``Allergies - List - no allergen score parts without highest valid score`` () =
        list 257 |> AssertEquality [Allergen.Eggs]

