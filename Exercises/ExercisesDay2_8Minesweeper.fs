namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay2_8Minesweeper =

    // Add the mine counts to a completed Minesweeper board.

    // Minesweeper is a popular game where the user has to find the mines using
    // numeric hints that indicate how many mines are directly adjacent
    // (horizontally, vertically, diagonally) to a square.

    // In this exercise you have to create some code that counts the number of
    // mines adjacent to a given empty square and replaces that square with the
    // count.

    // The board is a rectangle composed of blank space (' ') characters. A mine
    // is represented by an asterisk ('\*') character.

    // If a given space has no adjacent mines at all, leave that square blank.

    // ## Examples

    // For example you may receive a 5 x 4 board like this (empty spaces are
    // represented here with the '·' character for display on screen):

    // ```text
    // ·*·*·
    // ··*··
    // ··*··
    // ·····
    // ```

    // And your code will transform it into this:

    // ```text
    // 1*3*1
    // 13*31
    // ·2*2·
    // ·111·
    // ```

    let annotate input =  __

    [<Test>]
    let ``Minesweeper - No rows`` () =
        let minefield: string list = []
        let expected: string list = []
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - No columns`` () =
        let minefield = [""]
        let expected = [""]
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - No mines`` () =
        let minefield =
            [ "   ";
            "   ";
            "   " ]
        let expected =
            [ "   ";
            "   ";
            "   " ]
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - Minefield with only mines`` () =
        let minefield =
            [ "***";
            "***";
            "***" ]
        let expected =
            [ "***";
            "***";
            "***" ]
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - Mine surrounded by spaces`` () =
        let minefield =
            [ "   ";
            " * ";
            "   " ]
        let expected =
            [ "111";
            "1*1";
            "111" ]
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - Space surrounded by mines`` () =
        let minefield =
            [ "***";
            "* *";
            "***" ]
        let expected =
            [ "***";
            "*8*";
            "***" ]
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - Horizontal line`` () =
        let minefield = [" * * "]
        let expected = ["1*2*1"]
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - Horizontal line, mines at edges`` () =
        let minefield = ["*   *"]
        let expected = ["*1 1*"]
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - Vertical line`` () =
        let minefield =
            [ " ";
            "*";
            " ";
            "*";
            " " ]
        let expected =
            [ "1";
            "*";
            "2";
            "*";
            "1" ]
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - Vertical line, mines at edges`` () =
        let minefield =
            [ "*";
            " ";
            " ";
            " ";
            "*" ]
        let expected =
            [ "*";
            "1";
            " ";
            "1";
            "*" ]
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - Cross`` () =
        let minefield =
            [ "  *  ";
            "  *  ";
            "*****";
            "  *  ";
            "  *  " ]
        let expected =
            [ " 2*2 ";
            "25*52";
            "*****";
            "25*52";
            " 2*2 " ]
        annotate minefield |> AssertEquality expected

    [<Test>]
    let ``Minesweeper - Large minefield`` () =
        let minefield =
            [ " *  * ";
            "  *   ";
            "    * ";
            "   * *";
            " *  * ";
            "      " ]
        let expected =
            [ "1*22*1";
            "12*322";
            " 123*2";
            "112*4*";
            "1*22*2";
            "111111" ]
        annotate minefield |> AssertEquality expected

