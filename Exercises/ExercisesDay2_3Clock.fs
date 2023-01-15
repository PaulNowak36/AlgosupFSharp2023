namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay2_3Clock =
    // Implement a clock that handles times without dates.

    // You should be able to add and subtract minutes to it.

    // Two clocks that represent the same time should be equal to each other.



    // TODO: define the clock time
    type Clock = FILL_ME_IN

    let create (hours: int) (minutes: int) : Clock = __

    let add (minutes: int) (clock: Clock) = __

    let subtract (minutes: int) (clock: Clock) = __

    let display (clock: Clock) = __

    [<Ignore("Not implemented");Test>]
    let ``Clocks - On the hour`` () =
        let clock = create 8 0
        display clock |> AssertEquality "08:00"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Past the hour`` () =
        let clock = create 11 9
        display clock |> AssertEquality "11:09"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Midnight is zero hours`` () =
        let clock = create 24 0
        display clock |> AssertEquality "00:00"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Hour rolls over`` () =
        let clock = create 25 0
        display clock |> AssertEquality "01:00"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Hour rolls over continuously`` () =
        let clock = create 100 0
        display clock |> AssertEquality "04:00"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Sixty minutes is next hour`` () =
        let clock = create 1 60
        display clock |> AssertEquality "02:00"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Minutes roll over`` () =
        let clock = create 0 160
        display clock |> AssertEquality "02:40"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Minutes roll over continuously`` () =
        let clock = create 0 1723
        display clock |> AssertEquality "04:43"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Hour and minutes roll over`` () =
        let clock = create 25 160
        display clock |> AssertEquality "03:40"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Hour and minutes roll over continuously`` () =
        let clock = create 201 3001
        display clock |> AssertEquality "11:01"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Hour and minutes roll over to exactly midnight`` () =
        let clock = create 72 8640
        display clock |> AssertEquality "00:00"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Negative hour`` () =
        let clock = create -1 15
        display clock |> AssertEquality "23:15"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Negative hour rolls over`` () =
        let clock = create -25 0
        display clock |> AssertEquality "23:00"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Negative hour rolls over continuously`` () =
        let clock = create -91 0
        display clock |> AssertEquality "05:00"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Negative minutes`` () =
        let clock = create 1 -40
        display clock |> AssertEquality "00:20"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Negative minutes roll over`` () =
        let clock = create 1 -160
        display clock |> AssertEquality "22:20"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Negative minutes roll over continuously`` () =
        let clock = create 1 -4820
        display clock |> AssertEquality "16:40"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Negative sixty minutes is previous hour`` () =
        let clock = create 2 -60
        display clock |> AssertEquality "01:00"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Negative hour and minutes both roll over`` () =
        let clock = create -25 -160
        display clock |> AssertEquality "20:20"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Negative hour and minutes both roll over continuously`` () =
        let clock = create -121 -5810
        display clock |> AssertEquality "22:10"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Add minutes`` () =
        let clock = create 10 0
        add 3 clock |> display |> AssertEquality "10:03"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Add no minutes`` () =
        let clock = create 6 41
        add 0 clock |> display |> AssertEquality "06:41"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Add to next hour`` () =
        let clock = create 0 45
        add 40 clock |> display |> AssertEquality "01:25"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Add more than one hour`` () =
        let clock = create 10 0
        add 61 clock |> display |> AssertEquality "11:01"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Add more than two hours with carry`` () =
        let clock = create 0 45
        add 160 clock |> display |> AssertEquality "03:25"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Add across midnight`` () =
        let clock = create 23 59
        add 2 clock |> display |> AssertEquality "00:01"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Add more than one day (1500 min = 25 hrs)`` () =
        let clock = create 5 32
        add 1500 clock |> display |> AssertEquality "06:32"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Add more than two days`` () =
        let clock = create 1 1
        add 3500 clock |> display |> AssertEquality "11:21"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Subtract minutes`` () =
        let clock = create 10 3
        subtract 3 clock |> display |> AssertEquality "10:00"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Subtract to previous hour`` () =
        let clock = create 10 3
        subtract 30 clock |> display |> AssertEquality "09:33"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Subtract more than an hour`` () =
        let clock = create 10 3
        subtract 70 clock |> display |> AssertEquality "08:53"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Subtract across midnight`` () =
        let clock = create 0 3
        subtract 4 clock |> display |> AssertEquality "23:59"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Subtract more than two hours`` () =
        let clock = create 0 0
        subtract 160 clock |> display |> AssertEquality "21:20"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Subtract more than two hours with borrow`` () =
        let clock = create 6 15
        subtract 160 clock |> display |> AssertEquality "03:35"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Subtract more than one day (1500 min = 25 hrs)`` () =
        let clock = create 5 32
        subtract 1500 clock |> display |> AssertEquality "04:32"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Subtract more than two days`` () =
        let clock = create 2 20
        subtract 3000 clock |> display |> AssertEquality "00:20"

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with same time`` () =
        let clock1 = create 15 37
        let clock2 = create 15 37
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks a minute apart`` () =
        let clock1 = create 15 36
        let clock2 = create 15 37
        clock1 = clock2 |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks an hour apart`` () =
        let clock1 = create 14 37
        let clock2 = create 15 37
        clock1 = clock2 |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with hour overflow`` () =
        let clock1 = create 10 37
        let clock2 = create 34 37
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with hour overflow by several days`` () =
        let clock1 = create 3 11
        let clock2 = create 99 11
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with negative hour`` () =
        let clock1 = create 22 40
        let clock2 = create -2 40
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with negative hour that wraps`` () =
        let clock1 = create 17 3
        let clock2 = create -31 3
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with negative hour that wraps multiple times`` () =
        let clock1 = create 13 49
        let clock2 = create -83 49
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with minute overflow`` () =
        let clock1 = create 0 1
        let clock2 = create 0 1441
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with minute overflow by several days`` () =
        let clock1 = create 2 2
        let clock2 = create 2 4322
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with negative minute`` () =
        let clock1 = create 2 40
        let clock2 = create 3 -20
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with negative minute that wraps`` () =
        let clock1 = create 4 10
        let clock2 = create 5 -1490
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with negative minute that wraps multiple times`` () =
        let clock1 = create 6 15
        let clock2 = create 6 -4305
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with negative hours and minutes`` () =
        let clock1 = create 7 32
        let clock2 = create -12 -268
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Clocks with negative hours and minutes that wrap`` () =
        let clock1 = create 18 7
        let clock2 = create -54 -11513
        clock1 = clock2 |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``Clocks - Full clock and zeroed clock`` () =
        let clock1 = create 24 0
        let clock2 = create 0 0
        clock1 = clock2 |> AssertEquality true

