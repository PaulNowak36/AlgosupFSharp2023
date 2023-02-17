namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

module Question03 =
    // Given a year, report if it is a leap year.

    // The tricky thing here is that a leap year in the Gregorian calendar occurs:

    // on every year that is evenly divisible by 4
    //   except every year that is evenly divisible by 100
    //     unless the year is also evenly divisible by 400

    // For example, 1997 is not a leap year, but 1996 is.  1900 is not a leap
    // year, but 2000 is.

    // Fill in the 'leapYear' to calculate whether the given integer represents a
    // leap year

    let leapYear (year: int)  =  __

    [<Test>]
    let ``Question 03 - Test Case 01``() =
        let actualValue = leapYear 2015
        let expectedValue = false

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 03 - Test Case 02``() =
        let actualValue = leapYear 1960
        let expectedValue = true

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 03 - Test Case 03``() =
        let actualValue = leapYear 2100
        let expectedValue = false

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 03 - Test Case 04``() =
        let actualValue = leapYear 2000
        let expectedValue = true

        AssertEquality expectedValue actualValue


