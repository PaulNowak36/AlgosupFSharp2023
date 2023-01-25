namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay2_4RobotSimulator =
    // Write a robot simulator.

    // A robot factory's test facility needs a program to verify robot movements.

    // The robots have three possible movements:

    // - turn right
    // - turn left
    // - advance

    // Robots are placed on a hypothetical infinite grid, facing a particular
    // direction (north, east, south, or west) at a set of {x,y} coordinates,
    // e.g., {3,8}, with coordinates increasing to the north and east.

    // The robot then receives a number of instructions, at which point the
    // testing facility verifies the robot's new position, and in which
    // direction it is pointing.

    // - The letter-string "RAALAL" means:
    //   - Turn right
    //   - Advance twice
    //   - Turn left
    //   - Advance once
    //   - Turn left yet again
    // - Say a robot starts at {7, 3} facing north. Then running this stream
    //   of instructions should leave it at {9, 4} facing west.

    type Direction = North | East | South | West
    type Position = int * int
    type Robot = { direction: Direction; position: Position }

    let create direction position = 
        let newRobot = {direction = direction; position = position}
        newRobot

    let move instructions robot =
        let robotDirection = robot.direction
        let robotRight robot =
            match robotDirection with
            |Direction.West -> Direction.North
            |Direction.North -> Direction.East
            |Direction.East -> Direction.South
            |Direction.South -> Direction.West
             
            {robot with direction = robotDirection}
            

        if instructions = "R" then robotRight robot
        else robot 


    [<Test>]
    let ``RobotSimulator - RobotSimulator - At origin facing north`` () =
        let expected = create Direction.North (0, 0)
        create Direction.North (0, 0) |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - At negative position facing south`` () =
        let expected = create Direction.South (-1, -1)
        create Direction.South (-1, -1) |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Changes north to east`` () =
        let robot = create Direction.North (0, 0)
        let expected = create Direction.East (0, 0)
        move "R" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Changes east to south`` () =
        let robot = create Direction.East (0, 0)
        let expected = create Direction.South (0, 0)
        move "R" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Changes south to west`` () =
        let robot = create Direction.South (0, 0)
        let expected = create Direction.West (0, 0)
        move "R" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Changes west to north`` () =
        let robot = create Direction.West (0, 0)
        let expected = create Direction.North (0, 0)
        move "R" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Changes north to west`` () =
        let robot = create Direction.North (0, 0)
        let expected = create Direction.West (0, 0)
        move "L" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Changes west to south`` () =
        let robot = create Direction.West (0, 0)
        let expected = create Direction.South (0, 0)
        move "L" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Changes south to east`` () =
        let robot = create Direction.South (0, 0)
        let expected = create Direction.East (0, 0)
        move "L" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Changes east to north`` () =
        let robot = create Direction.East (0, 0)
        let expected = create Direction.North (0, 0)
        move "L" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Facing north increments Y`` () =
        let robot = create Direction.North (0, 0)
        let expected = create Direction.North (0, 1)
        move "A" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Facing south decrements Y`` () =
        let robot = create Direction.South (0, 0)
        let expected = create Direction.South (0, -1)
        move "A" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Facing east increments X`` () =
        let robot = create Direction.East (0, 0)
        let expected = create Direction.East (1, 0)
        move "A" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Facing west decrements X`` () =
        let robot = create Direction.West (0, 0)
        let expected = create Direction.West (-1, 0)
        move "A" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Moving east and north from README`` () =
        let robot = create Direction.North (7, 3)
        let expected = create Direction.West (9, 4)
        move "RAALAL" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Moving west and north`` () =
        let robot = create Direction.North (0, 0)
        let expected = create Direction.West (-4, 1)
        move "LAAARALA" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Moving west and south`` () =
        let robot = create Direction.East (2, -7)
        let expected = create Direction.South (-3, -8)
        move "RRAAAAALA" robot |> AssertEquality expected

    [<Test>]
    let ``RobotSimulator - Moving east and north`` () =
        let robot = create Direction.South (8, 4)
        let expected = create Direction.North (11, 5)
        move "LAAARRRALLLL" robot |> AssertEquality expected