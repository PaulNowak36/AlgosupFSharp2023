namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay3_8AtbashCipher =

    // Create an implementation of the atbash cipher, an ancient encryption system created in the Middle East.

    // The Atbash cipher is a simple substitution cipher that relies on
    // transposing all the letters in the alphabet such that the resulting
    // alphabet is backwards. The first letter is replaced with the last
    // letter, the second with the second-last, and so on.

    // An Atbash cipher for the Latin alphabet would be as follows:

    // ```text
    // Plain:  abcdefghijklmnopqrstuvwxyz
    // Cipher: zyxwvutsrqponmlkjihgfedcba
    // ```

    // It is a very weak cipher because it only has one possible key, and it is
    // a simple mono-alphabetic substitution cipher. However, this may not have
    // been an issue in the cipher's time.

    // Ciphertext is written out in groups of fixed length, the traditional group size
    // being 5 letters, leaving numbers unchanged, and punctuation is excluded.
    // This is to make it harder to guess things based on word boundaries.
    // All text will be encoded as lowercase letters.

    let encode str = __

    let decode str = __

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Encode yes`` () =
        encode "yes" |> AssertEquality "bvh"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Encode no`` () =
        encode "no" |> AssertEquality "ml"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Encode OMG`` () =
        encode "OMG" |> AssertEquality "lnt"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Encode spaces`` () =
        encode "O M G" |> AssertEquality "lnt"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Encode mindblowingly`` () =
        encode "mindblowingly" |> AssertEquality "nrmwy oldrm tob"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Encode numbers`` () =
        encode "Testing,1 2 3, testing." |> AssertEquality "gvhgr mt123 gvhgr mt"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Encode deep thought`` () =
        encode "Truth is fiction." |> AssertEquality "gifgs rhurx grlm"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Encode all the letters`` () =
        encode "The quick brown fox jumps over the lazy dog." |> AssertEquality "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Decode exercism`` () =
        decode "vcvix rhn" |> AssertEquality "exercism"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Decode a sentence`` () =
        decode "zmlyh gzxov rhlug vmzhg vkkrm thglm v" |> AssertEquality "anobstacleisoftenasteppingstone"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Decode numbers`` () =
        decode "gvhgr mt123 gvhgr mt" |> AssertEquality "testing123testing"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Decode all the letters`` () =
        decode "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt" |> AssertEquality "thequickbrownfoxjumpsoverthelazydog"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Decode with too many spaces`` () =
        decode "vc vix    r hn" |> AssertEquality "exercism"

    [<Ignore("Not implemented");Test>]
    let ``AtbashCipher - Decode with no spaces`` () =
        decode "zmlyhgzxovrhlugvmzhgvkkrmthglmv" |> AssertEquality "anobstacleisoftenasteppingstone"
