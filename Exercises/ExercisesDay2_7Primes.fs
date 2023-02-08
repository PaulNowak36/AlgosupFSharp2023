namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay2_7Primes =

    // Given a number n, determine what the nth prime is.

    // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that
    // the 6th prime is 13.

    let prime nth : int option = 
        
        let aboveToo (n:int) : bool =
                n >= 2       
        
        let isPrime (n:int) : bool =
            
            let notZero a =
                n % a <> 0

            let potentialList : int List = [2..n-1]
            potentialList |>List.forall notZero

        let primeSeq = 
            (+) 1 |> Seq.initInfinite 
            |> Seq.filter isPrime 

        if nth > 0 then         
            Some (primeSeq |> Seq.item nth)
        else
            None
        

        

        // let primeNotFound = true
        // //let mutable infiniteLoop = true
        // while primeNotFound do 
        //     if (checkPrime count) = true then count |> primeList.append count
        //     count <- count + 1
        // else
        



        
        

                


    [<Test>]
    let ``Primes - First prime`` () =
        prime 1 |> AssertEquality (Some 2)

    [<Test>]
    let ``Primes - Second prime`` () =
        prime 2 |> AssertEquality (Some 3)

    [<Test>]
    let ``Primes - Sixth prime`` () =
        prime 6 |> AssertEquality (Some 13)

    [<Test>]
    let ``Primes - Big prime`` () =
        prime 10001 |> AssertEquality (Some 104743)

    [<Test>]
    let ``Primes - There is no zeroth prime`` () =
        prime 0 |> AssertEquality None