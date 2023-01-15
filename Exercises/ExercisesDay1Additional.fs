namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay1Additional =

    [<Test>]
    let AssertExpectation() =

        // You are given the following information, but you may prefer to do some research for yourself.

        //     1 Jan 1900 was a Monday.
        //     Thirty days has September,
        //     April, June and November.
        //     All the rest have thirty-one,
        //     Saving February alone,
        //     Which has twenty-eight, rain or shine.
        //     And on leap years, twenty-nine.
        //     A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

        // How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?


        let startDate = new DateTime(1901, 1, 1)
        let endDate = new DateTime(2000, 12, 31)

        let firstSundays =
            seq {
                for i in 1..(endDate - startDate).Days do
                    let d = startDate.AddDays(float i)
                    if d.DayOfWeek = DayOfWeek.Sunday && d.Day = 1 then
                        1
                    else
                        0
            } |> Seq.sum


        AssertEquality firstSundays 171

    [<Test>]
    let TestForPangram() =
        // A pangram or holoalphabetic sentence is a sentence using every letter of a given alphabet at least once.
        // From: https://en.wikipedia.org/wiki/Pangram
        //

        let isPanagram (input: string) =
            let s = input.ToLower()
            let alphabet = ['a'..'z']
            alphabet |> List.forall (fun x -> s.Contains(x))

        AssertEquality true (isPanagram "The quick brown fox jumps over the lazy dog")
        AssertEquality false (isPanagram "Friends, Romans, Countrymen, lend me your ears")
        AssertEquality true (isPanagram "Pack my box with five dozen liquor jugs")
        AssertEquality false (isPanagram "More honoured in the breach than in the observance")
