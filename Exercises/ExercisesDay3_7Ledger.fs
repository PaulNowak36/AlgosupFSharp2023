namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay3_7Ledger =

    // Refactor a ledger printer.

    // The ledger exercise is a refactoring exercise. There is code that prints a
    // nicely formatted ledger, given a locale (American or Dutch) and a currency (US
    // dollar or euro). The code however is rather badly written, though (somewhat
    // surprisingly) it consistently passes the test suite.

    // Rewrite this code. Remember that in refactoring the trick is to make small steps
    // that keep the tests passing. That way you can always quickly go back to a
    // working version.  Version control tools like git can help here as well.

    // Please keep a log of what changes you've made and make a comment on the exercise
    // containing that log, this will help reviewers.

    open System
    open System.Globalization

    type Entry = { dat: DateTime; des: string; chg: int }

    let mkEntry (date: string) description change = { dat = DateTime.Parse(date, CultureInfo.InvariantCulture); des = description; chg = change }

    let formatLedger currency locale entries =

        let mutable res = ""

        if locale = "en-US" then res <- res + "Date       | Description               | Change       "
        if locale = "nl-NL" then res <- res + "Datum      | Omschrijving              | Verandering  "

        for x in List.sortBy (fun x -> x.dat, x.des, x.chg) entries do

            res <- res + System.Environment.NewLine

            if locale = "nl-NL" then
                res <- res + x.dat.ToString("dd-MM-yyyy")

            if locale = "en-US" then
                res <- res + x.dat.ToString("MM\/dd\/yyyy")

            res <- res + " | "

            if x.des.Length <= 25 then
                res <- res + x.des.PadRight(25)
            elif x.des.Length = 25 then
                res <- res + x.des
            else
                res <- res + x.des.[0..21] + "..."

            res <- res + " | "
            let c = float x.chg / 100.0

            if c < 0.0 then
                if locale = "nl-NL" then
                    if currency = "USD" then
                        res <- res + ("$ " + c.ToString("#,#0.00", new CultureInfo("nl-NL"))).PadLeft(13)
                    if currency = "EUR" then
                        res <- res + ("€ " + c.ToString("#,#0.00", new CultureInfo("nl-NL"))).PadLeft(13)
                if locale = "en-US" then
                    if currency = "USD" then
                        res <- res + ("($" + c.ToString("#,#0.00", new CultureInfo("en-US")).Substring(1) + ")").PadLeft(13)
                    if currency = "EUR" then
                        res <- res + ("(€" + c.ToString("#,#0.00", new CultureInfo("en-US")).Substring(1) + ")").PadLeft(13)
            else
                if locale = "nl-NL" then
                    if currency = "USD" then
                        res <- res + ("$ " + c.ToString("#,#0.00", new CultureInfo("nl-NL")) + " ").PadLeft(13)
                    if currency = "EUR" then
                        res <- res + ("€ " + c.ToString("#,#0.00", new CultureInfo("nl-NL")) + " ").PadLeft(13)
                if locale = "en-US" then
                    if currency = "USD" then
                        res <- res + ("$" + c.ToString("#,#0.00", new CultureInfo("en-US")) + " ").PadLeft(13)
                    if currency = "EUR" then
                        res <- res + ("€" + c.ToString("#,#0.00", new CultureInfo("en-US")) + " ").PadLeft(13)
        res

    [<Test>]
    let ``Ledger - Empty ledger`` () =
        let currency = "USD"
        let locale = "en-US"
        let entries = []
        let expected =
            "Date       | Description               | Change       "

        formatLedger currency locale entries |> AssertEquality expected

    [<Test>]
    let ``Ledger - One entry`` () =
        let currency = "USD"
        let locale = "en-US"
        let entries =
            [
                mkEntry "2015-01-01" "Buy present" -1000
            ]
        let expected =
            "Date       | Description               | Change       " + System.Environment.NewLine +
            "01/01/2015 | Buy present               |      ($10.00)"

        formatLedger currency locale entries |> AssertEquality expected

    [<Test>]
    let ``Ledger - Credit and debit`` () =
        let currency = "USD"
        let locale = "en-US"
        let entries =
            [
                mkEntry "2015-01-02" "Get present"  1000;
                mkEntry "2015-01-01" "Buy present" -1000
            ]
        let expected =
            "Date       | Description               | Change       " + System.Environment.NewLine +
            "01/01/2015 | Buy present               |      ($10.00)" + System.Environment.NewLine +
            "01/02/2015 | Get present               |       $10.00 "

        formatLedger currency locale entries |> AssertEquality expected

    [<Test>]
    let ``Ledger - Multiple entries on same date ordered by description`` () =
        let currency = "USD"
        let locale = "en-US"
        let entries =
            [
                mkEntry "2015-01-01" "Buy present" -1000;
                mkEntry "2015-01-01" "Get present"  1000
            ]
        let expected =
            "Date       | Description               | Change       " + System.Environment.NewLine +
            "01/01/2015 | Buy present               |      ($10.00)" + System.Environment.NewLine +
            "01/01/2015 | Get present               |       $10.00 "

        formatLedger currency locale entries |> AssertEquality expected

    [<Test>]
    let ``Ledger - Final order tie breaker is change`` () =
        let currency = "USD"
        let locale = "en-US"
        let entries =
            [
                mkEntry "2015-01-01" "Something" 0;
                mkEntry "2015-01-01" "Something" -1;
                mkEntry "2015-01-01" "Something" 1
            ]
        let expected =
            "Date       | Description               | Change       " + System.Environment.NewLine +
            "01/01/2015 | Something                 |       ($0.01)" + System.Environment.NewLine +
            "01/01/2015 | Something                 |        $0.00 " + System.Environment.NewLine +
            "01/01/2015 | Something                 |        $0.01 "

        formatLedger currency locale entries |> AssertEquality expected

    [<Test>]
    let ``Ledger - Overlong descriptions`` () =
        let currency = "USD"
        let locale = "en-US"
        let entries =
            [
                mkEntry "2015-01-01" "Freude schoner Gotterfunken" -123456
            ]
        let expected =
            "Date       | Description               | Change       " + System.Environment.NewLine +
            "01/01/2015 | Freude schoner Gotterf... |   ($1,234.56)"

        formatLedger currency locale entries |> AssertEquality expected

    [<Test>]
    let ``Ledger - Euros`` () =
        let currency = "EUR"
        let locale = "en-US"
        let entries =
            [
                mkEntry "2015-01-01" "Buy present" -1000
            ]
        let expected =
            "Date       | Description               | Change       " + System.Environment.NewLine +
            "01/01/2015 | Buy present               |      (€10.00)"

        formatLedger currency locale entries |> AssertEquality expected

    [<Test>]
    let ``Ledger - Dutch locale`` () =
        let currency = "USD"
        let locale = "nl-NL"
        let entries =
            [
                mkEntry "2015-03-12" "Buy present" 123456
            ]
        let expected =
            "Datum      | Omschrijving              | Verandering  " + System.Environment.NewLine +
            "12-03-2015 | Buy present               |   $ 1.234,56 "

        formatLedger currency locale entries |> AssertEquality expected

    [<Test>]
    let ``Ledger - Dutch negative number with 3 digits before decimal point`` () =
        let currency = "USD"
        let locale = "nl-NL"
        let entries =
            [
                mkEntry "2015-03-12" "Buy present" -12345
            ]
        let expected =
            "Datum      | Omschrijving              | Verandering  " + System.Environment.NewLine +
            "12-03-2015 | Buy present               |     $ -123,45"

        formatLedger currency locale entries |> AssertEquality expected

    [<Test>]
    let ``American negative number with 3 digits before decimal point`` () =
        let currency = "USD"
        let locale = "en-US"
        let entries =
            [
                mkEntry "2015-03-12" "Buy present" -12345
            ]
        let expected =
            "Date       | Description               | Change       " + System.Environment.NewLine +
            "03/12/2015 | Buy present               |     ($123.45)"

        formatLedger currency locale entries |> AssertEquality expected
