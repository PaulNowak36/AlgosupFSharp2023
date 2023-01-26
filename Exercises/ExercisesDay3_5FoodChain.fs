namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay3_5FoodChain =

    // Generate the lyrics of the song 'I Know an Old Lady Who Swallowed a Fly'.

    // While you could copy/paste the lyrics,
    // or read them from a file, this problem is much more
    // interesting if you approach it algorithmically.

    // This is a [cumulative song](http://en.wikipedia.org/wiki/Cumulative_song) of unknown origin.

    // This is one of many common variants.

    // ```text
    // I know an old lady who swallowed a fly.
    // I don't know why she swallowed the fly. Perhaps she'll die.

    // I know an old lady who swallowed a spider.
    // It wriggled and jiggled and tickled inside her.
    // She swallowed the spider to catch the fly.
    // I don't know why she swallowed the fly. Perhaps she'll die.

    // I know an old lady who swallowed a bird.
    // How absurd to swallow a bird!
    // She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.
    // She swallowed the spider to catch the fly.
    // I don't know why she swallowed the fly. Perhaps she'll die.

    // I know an old lady who swallowed a cat.
    // Imagine that, to swallow a cat!
    // She swallowed the cat to catch the bird.
    // She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.
    // She swallowed the spider to catch the fly.
    // I don't know why she swallowed the fly. Perhaps she'll die.

    // I know an old lady who swallowed a dog.
    // What a hog, to swallow a dog!
    // She swallowed the dog to catch the cat.
    // She swallowed the cat to catch the bird.
    // She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.
    // She swallowed the spider to catch the fly.
    // I don't know why she swallowed the fly. Perhaps she'll die.

    // I know an old lady who swallowed a goat.
    // Just opened her throat and swallowed a goat!
    // She swallowed the goat to catch the dog.
    // She swallowed the dog to catch the cat.
    // She swallowed the cat to catch the bird.
    // She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.
    // She swallowed the spider to catch the fly.
    // I don't know why she swallowed the fly. Perhaps she'll die.

    // I know an old lady who swallowed a cow.
    // I don't know how she swallowed a cow!
    // She swallowed the cow to catch the goat.
    // She swallowed the goat to catch the dog.
    // She swallowed the dog to catch the cat.
    // She swallowed the cat to catch the bird.
    // She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.
    // She swallowed the spider to catch the fly.
    // I don't know why she swallowed the fly. Perhaps she'll die.

    // I know an old lady who swallowed a horse.
    // She's dead, of course!
    // ```

    let recite start stop: string list = __

    [<Ignore("Not implemented");Test>]
    let ``FoodChain - Fly`` () =
        let expected =
            [ "I know an old lady who swallowed a fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die." ]
        recite 1 1 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``FoodChain - Spider`` () =
        let expected =
            [ "I know an old lady who swallowed a spider.";
            "It wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die." ]
        recite 2 2 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``FoodChain - Bird`` () =
        let expected =
            [ "I know an old lady who swallowed a bird.";
            "How absurd to swallow a bird!";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die." ]
        recite 3 3 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``FoodChain - Cat`` () =
        let expected =
            [ "I know an old lady who swallowed a cat.";
            "Imagine that, to swallow a cat!";
            "She swallowed the cat to catch the bird.";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die." ]
        recite 4 4 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``FoodChain - Dog`` () =
        let expected =
            [ "I know an old lady who swallowed a dog.";
            "What a hog, to swallow a dog!";
            "She swallowed the dog to catch the cat.";
            "She swallowed the cat to catch the bird.";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die." ]
        recite 5 5 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``FoodChain - Goat`` () =
        let expected =
            [ "I know an old lady who swallowed a goat.";
            "Just opened her throat and swallowed a goat!";
            "She swallowed the goat to catch the dog.";
            "She swallowed the dog to catch the cat.";
            "She swallowed the cat to catch the bird.";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die." ]
        recite 6 6 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``FoodChain - Cow`` () =
        let expected =
            [ "I know an old lady who swallowed a cow.";
            "I don't know how she swallowed a cow!";
            "She swallowed the cow to catch the goat.";
            "She swallowed the goat to catch the dog.";
            "She swallowed the dog to catch the cat.";
            "She swallowed the cat to catch the bird.";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die." ]
        recite 7 7 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``FoodChain - Horse`` () =
        let expected =
            [ "I know an old lady who swallowed a horse.";
            "She's dead, of course!" ]
        recite 8 8 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``FoodChain - Multiple verses`` () =
        let expected =
            [ "I know an old lady who swallowed a fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die.";
            "";
            "I know an old lady who swallowed a spider.";
            "It wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die.";
            "";
            "I know an old lady who swallowed a bird.";
            "How absurd to swallow a bird!";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die." ]
        recite 1 3 |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``FoodChain - Full song`` () =
        let expected =
            [ "I know an old lady who swallowed a fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die.";
            "";
            "I know an old lady who swallowed a spider.";
            "It wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die.";
            "";
            "I know an old lady who swallowed a bird.";
            "How absurd to swallow a bird!";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die.";
            "";
            "I know an old lady who swallowed a cat.";
            "Imagine that, to swallow a cat!";
            "She swallowed the cat to catch the bird.";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die.";
            "";
            "I know an old lady who swallowed a dog.";
            "What a hog, to swallow a dog!";
            "She swallowed the dog to catch the cat.";
            "She swallowed the cat to catch the bird.";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die.";
            "";
            "I know an old lady who swallowed a goat.";
            "Just opened her throat and swallowed a goat!";
            "She swallowed the goat to catch the dog.";
            "She swallowed the dog to catch the cat.";
            "She swallowed the cat to catch the bird.";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die.";
            "";
            "I know an old lady who swallowed a cow.";
            "I don't know how she swallowed a cow!";
            "She swallowed the cow to catch the goat.";
            "She swallowed the goat to catch the dog.";
            "She swallowed the dog to catch the cat.";
            "She swallowed the cat to catch the bird.";
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
            "She swallowed the spider to catch the fly.";
            "I don't know why she swallowed the fly. Perhaps she'll die.";
            "";
            "I know an old lady who swallowed a horse.";
            "She's dead, of course!" ]
        recite 1 8 |> AssertEquality expected

