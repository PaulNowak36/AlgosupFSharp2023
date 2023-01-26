namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay3_6PascalsTriangle =

    // Compute Pascal's triangle up to a given number of rows.

    // In Pascal's Triangle each number is computed by adding the numbers to
    // the right and left of the current position in the previous row.

    // ```text
    //     1
    //    1 1
    //   1 2 1
    //  1 3 3 1
    // 1 4 6 4 1
    // # ... etc
    // ```

    let rows numberOfRows : int list list = __

    [<Ignore("Not implemented");Test>]
    let ``PascalsTriangle - PascalsTriangle -Zero rows`` () =
        let expected: int list list = []
        rows 0 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``PascalsTriangle - PascalsTriangle -Single row`` () =
        let expected = [[1]]
        rows 1 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``PascalsTriangle - PascalsTriangle -Two rows`` () =
        let expected =
            [ [1];
            [1; 1] ]
        rows 2 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``PascalsTriangle - PascalsTriangle -Three rows`` () =
        let expected =
            [ [1];
            [1; 1];
            [1; 2; 1] ]
        rows 3 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``PascalsTriangle - PascalsTriangle -Four rows`` () =
        let expected =
            [ [1];
            [1; 1];
            [1; 2; 1];
            [1; 3; 3; 1] ]
        rows 4 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``PascalsTriangle - PascalsTriangle -Five rows`` () =
        let expected =
            [ [1];
            [1; 1];
            [1; 2; 1];
            [1; 3; 3; 1];
            [1; 4; 6; 4; 1] ]
        rows 5 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``PascalsTriangle - PascalsTriangle -Six rows`` () =
        let expected =
            [ [1];
            [1; 1];
            [1; 2; 1];
            [1; 3; 3; 1];
            [1; 4; 6; 4; 1];
            [1; 5; 10; 10; 5; 1] ]
        rows 6 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``PascalsTriangle - PascalsTriangle -Ten rows`` () =
        let expected =
            [ [1];
            [1; 1];
            [1; 2; 1];
            [1; 3; 3; 1];
            [1; 4; 6; 4; 1];
            [1; 5; 10; 10; 5; 1];
            [1; 6; 15; 20; 15; 6; 1];
            [1; 7; 21; 35; 35; 21; 7; 1];
            [1; 8; 28; 56; 70; 56; 28; 8; 1];
            [1; 9; 36; 84; 126; 126; 84; 36; 9; 1] ]
        rows 10 |> AssertEquality expected
