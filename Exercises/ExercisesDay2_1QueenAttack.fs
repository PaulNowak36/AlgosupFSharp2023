namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay2_1QueenAttack =

    // Given the position of two queens on a chess board, indicate whether or not they are positioned so that they can attack each other.

    // In the game of chess, a queen can attack pieces which are on the same row, column, or diagonal.

    // A chessboard can be represented by an 8 by 8 array.

    // So if you are told the white queen is at `c5` (zero-indexed at column 2, row 3) and the black queen at `f2` (zero-indexed at column 5, row 6), then you know that the set-up is like so:

    // ```text
    //   a b c d e f g h
    // 8 _ _ _ _ _ _ _ _ 8
    // 7 _ _ _ _ _ _ _ _ 7
    // 6 _ _ _ _ _ _ _ _ 6
    // 5 _ _ W _ _ _ _ _ 5
    // 4 _ _ _ _ _ _ _ _ 4
    // 3 _ _ _ _ _ _ _ _ 3
    // 2 _ _ _ _ _ B _ _ 2
    // 1 _ _ _ _ _ _ _ _ 1
    //   a b c d e f g h
    // ```

    // You are also be able to answer whether the queens can attack each other.
    // In this case, that answer would be yes, they can, because both pieces share a diagonal.

    let canAttack (queen1: int * int) (queen2: int * int) =
        __

    [<Ignore("Not implemented");Test>]
    let ``QueenAttack - Cannot attack`` () =
        let whiteQueen = (2, 4)
        let blackQueen = (6, 6)
        canAttack blackQueen whiteQueen |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``QueenAttack - Can attack on same row`` () =
        let whiteQueen = (2, 4)
        let blackQueen = (2, 6)
        canAttack blackQueen whiteQueen |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``QueenAttack - Can attack on same column`` () =
        let whiteQueen = (4, 5)
        let blackQueen = (2, 5)
        canAttack blackQueen whiteQueen |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``QueenAttack - Can attack on first diagonal`` () =
        let whiteQueen = (2, 2)
        let blackQueen = (0, 4)
        canAttack blackQueen whiteQueen |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``QueenAttack - Can attack on second diagonal`` () =
        let whiteQueen = (2, 2)
        let blackQueen = (3, 1)
        canAttack blackQueen whiteQueen |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``QueenAttack - Can attack on third diagonal`` () =
        let whiteQueen = (2, 2)
        let blackQueen = (1, 1)
        canAttack blackQueen whiteQueen |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``QueenAttack - Can attack on fourth diagonal`` () =
        let whiteQueen = (1, 7)
        let blackQueen = (0, 6)
        canAttack blackQueen whiteQueen |> AssertEquality true
