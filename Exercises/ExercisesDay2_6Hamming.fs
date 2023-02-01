namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay2_6Hamming =

    // Calculate the Hamming Distance between two DNA strands.

    // Your body is made up of cells that contain DNA. Those cells regularly wear out and need replacing, which they achieve by dividing into daughter cells. In fact, the average human body experiences about 10 quadrillion cell divisions in a lifetime!

    // When cells divide, their DNA replicates too. Sometimes during this process mistakes happen and single pieces of DNA get encoded with the incorrect information. If we compare two strands of DNA and count the differences between them we can see how many mistakes occurred. This is known as the "Hamming Distance".

    // We read DNA using the letters C,A,G and T. Two strands might look like this:

    //     GAGCCTACTAACGGGAT
    //     CATCGTAATGACGGCCT
    //     ^ ^ ^  ^ ^    ^^

    // They have 7 differences, and therefore the Hamming Distance is 7.

    // The Hamming Distance is useful for lots of things in science, not just biology, so it's a nice phrase to be familiar with :)

    // ## Implementation notes

    // The Hamming distance is only defined for sequences of equal length, so
    // an attempt to calculate it between sequences of different lengths should
    // not work.

    let distance (strand1: string) (strand2: string): int option = 
        let seq1 = Seq.toList strand1
        let seq2 = Seq.toList strand2

        let checkEquality =   
            (seq1, seq2) ||> List.forall2 (=)
        
        if checkEquality = true then Some 0
        else None

    [<Test>]
    let ``Hamming - Empty strands`` () =
        distance "" "" |> AssertEquality (Some 0)

    [<Test>]
    let ``Hamming - Single letter identical strands`` () =
        distance "A" "A" |> AssertEquality (Some 0)

    [<Test>]
    let ``Hamming - Single letter different strands`` () =
        distance "G" "T" |> AssertEquality (Some 1)

    [<Test>]
    let ``Hamming - Long identical strands`` () =
        distance "GGACTGAAATCTG" "GGACTGAAATCTG" |> AssertEquality (Some 0)

    [<Test>]
    let ``Hamming - Long different strands`` () =
        distance "GGACGGATTCTG" "AGGACGGATTCT" |> AssertEquality (Some 9)

    [<Test>]
    let ``Hamming - Disallow first strand longer`` () =
        distance "AATG" "AAA" |> AssertEquality None

    [<Test>]
    let ``Hamming - Disallow second strand longer`` () =
        distance "ATA" "AGTG" |> AssertEquality None

    [<Test>]
    let ``Hamming - Disallow empty first strand`` () =
        distance "" "G" |> AssertEquality None

    [<Test>]
    let ``Hamming - Disallow empty second strand`` () =
        distance "G" "" |> AssertEquality None
