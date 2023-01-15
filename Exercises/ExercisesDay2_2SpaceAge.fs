namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay2_1SpaceAge =

    // Given an age in seconds, calculate how old someone would be on:

    // - Mercury: orbital period 0.2408467 Earth years
    // - Venus: orbital period 0.61519726 Earth years
    // - Earth: orbital period 1.0 Earth years, 365.25 Earth days, or 31557600 seconds
    // - Mars: orbital period 1.8808158 Earth years
    // - Jupiter: orbital period 11.862615 Earth years
    // - Saturn: orbital period 29.447498 Earth years
    // - Uranus: orbital period 84.016846 Earth years
    // - Neptune: orbital period 164.79132 Earth years

    // So if you were told someone were 1,000,000,000 seconds old, you should
    // be able to say that they're 31.69 Earth-years old.

    type Planet =
        | Mercury
        | Venus
        | Earth
        | Mars
        | Jupiter
        | Saturn
        | Neptune
        | Uranus

    let age (planet: Planet) (seconds: int64): float = __

    [<Ignore("Not implemented");Test>]
    let ``SpaceAge - Age on Earth`` () =
        age Earth 1000000000L |> AssertEquality2dp 31.69

    [<Ignore("Not implemented");Test>]
    let ``SpaceAge - Age on Mercury`` () =
        age Mercury 2134835688L |> AssertEquality2dp 280.88

    [<Ignore("Not implemented");Test>]
    let ``SpaceAge - Age on Venus`` () =
        age Venus 189839836L |> AssertEquality2dp 9.78

    [<Ignore("Not implemented");Test>]
    let ``SpaceAge - Age on Mars`` () =
        age Mars 2129871239L |> AssertEquality2dp 35.88

    [<Ignore("Not implemented");Test>]
    let ``SpaceAge - Age on Jupiter`` () =
        age Jupiter 901876382L |> AssertEquality2dp 2.41

    [<Ignore("Not implemented");Test>]
    let ``SpaceAge - Age on Saturn`` () =
        age Saturn 2000000000L |> AssertEquality2dp 2.15

    [<Ignore("Not implemented");Test>]
    let ``SpaceAge - Age on Uranus`` () =
        age Uranus 1210123456L |> AssertEquality2dp 0.46

    [<Ignore("Not implemented");Test>]
    let ``SpaceAge - Age on Neptune`` () =
        age Neptune 1821023456L |> AssertEquality2dp 0.35
