namespace Minesweeper

open System
open Eto.Forms
open Eto.Drawing

module Value =

    // counts the neighbouring mines
    let count (chars:char[][]) (x,y) =
        [-1,-1; 0,-1; 1,-1
         -1, 0;       1, 0
         -1, 1; 0, 1; 1, 1]
        |> List.filter (fun (dx,dy) ->
            let x, y = x + dx, y + dy
            y>=0 && y<chars.Length &&
            x>=0 && x<chars.[y].Length &&
            chars.[y].[x] = '*'
        )
        |> List.length

    // decides when a character should be replaced with when clicked
    let from chars (x,y) c =
        let neighbours = count chars (x,y)
        match c with
        | '*' -> c
        | '.' when neighbours > 0 -> '0' + char (neighbours)
        | '.' -> ' '
        | _ -> new System.ArgumentException("Unexpected character") |> raise

module Algorithm =
    // calculates if a patch of empty squares can revealed
    let flood canFill fill (x,y) =
        let rec next = function
            | [] -> ()
            | ps ->
                let qs =
                    ps
                    |> List.filter canFill
                    |> List.collect (fun (x,y) ->
                        [(x-1,y);(x+1,y);(x,y-1);(x,y+1)]
                    )
                ps |> List.iter fill
                qs |> next
        next [(x,y)]

// Represents the current state of a square
type SquareState = { Value:char; mutable IsShowing:bool }
// used to return the updates for neighbouring squares
type SquareInfo = { X:int; Y:int; Value:char }

// a class that represents the current mine field
type Minefield (squares:SquareState[][]) =
    // calculate some properties of the board
    let height, width = squares.Length, squares.[0].Length

    // test if coordinates are within the board
    let isInRange (x,y) =
        y >= 0  && y < height &&
        x >= 0  && x < width

    // get details of the surrounding squares
    let surroundingSquares (x,y) =
        let values = System.Collections.Generic.List<_>()
        let canFill (x,y) =
            isInRange (x,y) &&
            squares.[y].[x].Value=' ' &&
            not squares.[y].[x].IsShowing
        let fill (x,y) =
            if isInRange (x,y) then
                let square = squares.[y].[x]
                if not square.IsShowing then
                    square.IsShowing <- true
                    values.Add(x,y,square.Value)
        Algorithm.flood canFill fill (x,y)
        values |> Seq.toList |> Seq.distinct |> Seq.toArray

    // the mine locations
    let mines =
        squares |> Array.mapi (fun y row ->
            row |> Array.mapi (fun x square ->
                (x,y,'*'), (square.Value = '*')
            )
        )
        |> Array.concat
        |> Array.filter snd
        |> Array.map fst

    // implementation of reveal
    let reveal (x,y) =
        let square = squares.[y].[x]
        if square.IsShowing
        then [||]
        else
            match square.Value with
            | '*' -> mines
            | ' ' -> surroundingSquares (x,y)
            |  c  ->
                square.IsShowing <- true
                [|x,y,c|]
        |> Array.map (fun (x,y,c) -> { X=x; Y=y; Value=c })

    // construct an instance of the class from a matrix of chars
    new (chars:char[][]) =
        Minefield(
            chars |> Array.mapi (fun y row ->
                row |> Array.mapi (fun x c ->
                    let value = Value.from chars (x,y) c
                    { Value=value; IsShowing=false} )
            ))

    // number of mines
    member field.Mines = mines.Length

    // width of the board
    member field.Width = width

    // height of the board
    member field.Height = height

    // provides what squares should be revealed when a square is clicked
    member field.Reveal(x,y) = reveal (x,y)

type MainForm () as this =
    inherit Form()
    do
        this.Title <- "Minesweeper"
        this.MinimumSize <- new Size(200, 200)
        this.Padding <- new Padding(10)

        // this defines the minefield
        // it's useful to have a static minefield for testing
        // TODO generate a random minefield
        let minefield = "*...
                        ....
                        .*..
                        ...."

        // split and clean the minefield to a character array
        let chars =
            let options = System.StringSplitOptions.RemoveEmptyEntries
            minefield.Split([|'\r';'\n'|], options)
            |> Array.map (fun line -> line.Trim().ToCharArray() )

        let minefield = Minefield(chars)

        let reveal (square:Button) c =
            square.Text <- c.ToString()
            // TODO the button should become inactive when clicked
            // TODO it's difficult to tell when an empty square (c = ' ') has been clicked
            // use colour or some other method to give the user feedback
            // TODO should mines and numbers have different coloured backgrounds

        // TODO create a matrix of buttons to represent the squares on the board
        let squares =
            [| [| new Button() |] |]

        let subscribe (x,y) (square:Button) =
            square.Click.Add (fun _ ->
                // TODO call minefield.Reveal (x,y) and handle the result
                ())

        let layout = new StackLayout()

        // TODO iterate over the matrix and add rows of buttons to the "layout" StackLayout
        // the next few lines demonstrate how to add a row to the layout,
        // then how to add a single button to the row.
        // You should ensure all the buttons from the matrix are added to the layout
        // -------------------- start button layout --------------------
        let buttonRow = new StackLayout(Orientation=Orientation.Horizontal)
        layout.Items.Add(new StackLayoutItem(buttonRow))

        let x, y = 0, 0
        let button = squares.[y].[x]
        subscribe (0,0) button
        buttonRow.Items.Add(new StackLayoutItem(button))
        // --------------------  end button layout  --------------------

        // TODO detect when the game is won or lost and tell the user
        // TODO allow the user to start a new game
        // TODO offer different board sizes
        // TODO by default the buttons are a rectangle, make them square
        // TODO add happy / sad face :)

        // this sets the lay into the main control
        this.Content <- layout

