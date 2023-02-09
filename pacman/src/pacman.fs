module Pacman

// Another great F# game by Phil Trelford! The code involves rendering the maze,
// AI for the ghosts, user interaction and even playing sound effects. There is
// some brief commentary, but if you're a beginner look at the other examples first.

open Fable.Core
open Fable.Core.JsInterop
open Browser.Types
open Browser

module Sound =
    let [<Global>] Audio: obj = jsNative

    let origin =
        // Sample is running in an iframe, so get the location of parent
        let topLocation = window.top.location
        topLocation.origin + topLocation.pathname

    let play (fileName: string) =
        let audio = createNew Audio (origin + "sound/" + fileName + ".wav")
        audio?play()

module Images =
    // The following block embeds the ghosts and other parts of graphics as Base64 encoded strings.
    // This way, we can load them without making additional server requests:
    let cyand = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAiUlEQVQoU8WSURKAIAhE8Sh6Fc/tVfQoJdqiMDTVV4wfufAAmw3kxEHUz4pA1I8OJVjAKZZ6+XiC0ATTB/gW2mEFtlpHLqaktrQ6TxUQSRCAPX2AWPMLyM0VmPOcV8palxt6uoAMpDjfWJt+o6cr0DPDnfYjyL94NwIcYjXcR/FuYklcxrZ3OO0Ep4dJ/3dR5jcAAAAASUVORK5CYII="
    let oranged = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAgklEQVQoU8WS0RGAIAxDZRRYhblZBUZBsBSaUk/9kj9CXlru4g7r1FxBdsFpGwoa2NwrYIFPEIeM6QS+hQQMYC70EjzuuOlt6gT5kRGGTf0Cx5qfwJYOYIw0L6W1bg+09Al2wAcCS8Y/WjqAZhluxD/B3ghZBO6n1sadzLLEbNSg8pzXIVLvbNvPwAAAAABJRU5ErkJggg=="
    let pinkd = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAj0lEQVQoU8WSsRWAIAxEZRQpXITGVZzIVWxYxAJHwRfwMInxqZV0XPIvgXeuM05eUuayG73TbULQwKWZGTTwCYIJphfwLcRhAW5DLfWrXFLrNLWBKAIBbOkFxJpfQDIXYAh1XoznumRo6Q0kwE8VTLN8o6UL0ArDnfYjSF/Mg4CEaA330sxD3ApHLvUdSdsBdgNkr9L8gxYAAAAASUVORK5CYII="
    let redd = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAkklEQVQoU8WSvRWAIAyEZRQtXIRCV3EiVtGCRSx0FHxBD5MYn1pJl0u+/PDOVcZLY5e47PrJ6TIhaOBSzBoU8AlCE0zP4FuIwwJc25Bz9TyILbVOUwuIJAjAlp5BrPkFpOYC9H6fF+O5LjW09AIS0Az7jUuQN1q6AC0z3Gk/gvTF3AhwiNYQ52Ju4pI4fKljOG0DA3tp97vN6C8AAAAASUVORK5CYII="
    let pu1 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAWElEQVQoU62SUQoAIAhD9f6HNiYYolYi9VfzuXIxDRYbI0LCTHsfe3ldi3BgRRUY9Rnku1Rupf4NgiPeVjVU7STckphBceSvrHHtNPI21HWz4NO3eUUAgwVpmjX/zwK8KQAAAABJRU5ErkJggg=="
    let pu2 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAW0lEQVQoU8WSwQoAIAhD9f8/2lIwdKRIl7o1e010THBESJiJXca76qnoDxFC3SD9LRpWkLnsLt4gdImtlLX/EK4iDapqr4VuI2+BauQjaOrmSz8xillDp5gQrS054jv/0fkNVAAAAABJRU5ErkJggg=="
    let pd1 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAXElEQVQoU62SUQoAIAhD9f6HNgyMWpMs6k/XU5mqwDMTw5yq6JwbAfucwR2qAFHAu75BN11Gt6+Qz54VpMJsMV3BaS9UR8txkUzfLC9DUY0BYbOPGfpyU3g2WdwAOvU1/9KZsT4AAAAASUVORK5CYII="
    let pd2 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAU0lEQVQoU62SUQoAIAhD9f6HNgwUGw4s6q/pc6KqwDMTQ01VtGr56ZIZvKEJEAXc9Q26cUm3r5D3zgrywHeoG3ldJrZIRz6C0I1BoR83FTBCeHsLIlw7/wOkQycAAAAASUVORK5CYII="
    let pl1 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAVUlEQVQoU62S2woAIAhD9f8/2jAwvGRMyDfF49iQKZUISZ4xE/vZaW7LHbwhBLADqjpSUjBAdglRDQa9hxfcQi+vf5RGnpDlkB4KlMgR0N6pBIH83gIPFCb/N+MLCwAAAABJRU5ErkJggg=="
    let pl2 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAUklEQVQoU52SUQoAIAhD3f0PbRQoZgnT/hyttYeQdFRFswYIoubD73JlPibGYA/s1Jmpk+JpDIinWxbiXP3iQslCwbhTxzhHbsWZNFsnCkTevQW2bCb/VRTuVwAAAABJRU5ErkJggg=="
    let pr1 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAWElEQVQoU52S4Q4AIASE3fs/tKalSTHyL/O5CyAXzMQ+BxBsbj9exRE8oQqgDUS1BalNVFSuP2WQL94WIygCBEzttZWOvbz2VBnGtLXg1sgV/L8I679yewN9sScO5wcxLQAAAABJRU5ErkJggg=="
    let pr2 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAVElEQVQoU62SWwoAIAgE9f6HNgqU3BK2R3+J48KoCjwzMaypis61+OyaK3hADOADeuoddJISaQy0iKggbEz2viah7mVPTNq7cp/ApLmcdFPVdaDJBnWdJwjk629HAAAAAElFTkSuQmCC"
    let blue = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAeklEQVQoU62S0Q3AIAhEyyi6UcfoRB2jG+koNkeCoVcaTaw/huMeEkS24KTUmpdrFWHbQ2CAzb5AB0eQFTFYwVnIw/+B5by0cD52vTmGhnaF25wBAb/A6HsibR0ctch5fRHi1zCigvCut4oR+wnbhrBmsZr9DlqCQfbcnfZjDyiZqCEAAAAASUVORK5CYII="
    let eyed = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAUElEQVQoU2NkIBMwkqmPYYA13rt37z/I6UpKSiguwSYOVwCThPkZphmXOHU0OjtD7Nu7F+FckI3YxFH8oqgI8eP9+6h+xCY+wNFBSiqiv1MBDgYsD185vj8AAAAASUVORK5CYII="
    let _200 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAS0lEQVQoU2NkIBMwkqmPYYA0vpVR+Q9zsvCTO4yE+CC1KE4FaYBpxEfDNWKzgWiNIIUw5xKyGa+N+PyM4UdS4nSA4pEUJ8LUku1UAMC0VA8iscBNAAAAAElFTkSuQmCC"
    let _400 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAASElEQVQoU2NkIBMwkqmPYYA0vpVR+S/85A4jMg3zAkwcmQ9ig52KTSO6Qch8FI3oNhClEaaJWJvhNmLTSJQfyYnLAYpHujoVAChTXA9pVJi5AAAAAElFTkSuQmCC"
    let _800 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAQElEQVQoU2NkIBMwkqmPYYA0vpVR+Q9zsvCTO4yE+CC1YKeCFMI0EEOjaES3EZ8BtLERn5/hNpITlwMUj3R1KgCe5lwPHtUmcwAAAABJRU5ErkJggg=="
    let _1600 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAQ0lEQVQoU2NkIBMwkqmPYQA0vpVR+S/85A4jiIY5mxg+WANMIYiGaUYXR+ejaES3EdlAvBrxKSTJRnx+HoDoGDopBwDHLGwPAhDgRQAAAABJRU5ErkJggg=="

    // Create image using the specified data
    let createImage data =
        let img = document.createElement("img") :?> HTMLImageElement
        img.src <- data
        img

    // Load the different Pacman images
    let private pu1Img, pu2Img =
        createImage pu1, createImage  pu2
    let private pd1Img, pd2Img =
        createImage pd1, createImage  pd2
    let private pl1Img, pl2Img =
        createImage pl1, createImage pl2
    let private pr1Img, pr2Img =
        createImage pr1, createImage pr2

    // Represent Pacman's mouth state
    let mutable private lastp = pr1Img

    // This function returns the pacman image for the specified X and Y location, taking into account the
    // direction in which Pacman is going. It keeps a mutable state with current step of Pacman's
    // mouth.
    let imageAt(x, y, directionVector) =
        // TODO choose the correct image for Pacman based on his direction and location
        // remember you should use the location to animate the mouth
        printfn "%A" directionVector

        let p = 
            match directionVector with
            | 0,-1 -> pu1Img
            | 0,1 -> pd1Img
            | -1,0 -> pl1Img
            | 1,0 -> pr1Img
            | _ -> lastp
        lastp <- p
        p

module Keyboard =

    // Set of currently pressed keys
    let mutable keysPressed = Set.empty
    // Update the keys as requested
    let reset () = keysPressed <- Set.empty
    let isPressed keyCode = Set.contains keyCode keysPressed

    // Triggered when key is pressed/released
    let update (e : KeyboardEvent, pressed) =
        let keyCode = int e.keyCode
        let op =  if pressed then Set.add else Set.remove
        keysPressed <- op keyCode keysPressed

    // Register DOM event handlers
    let init () =
        window.addEventListener("keydown", fun e -> update(e :?> _, true))
        window.addEventListener("keyup", fun e -> update(e :?> _, false))

module Types =
    // Creating ghosts
    // ===============
    // Ghosts are represented by a simple F# class type that contains the image of the ghost,
    // current X, Y positions and a velocity in both directions. In Pacman, ghosts are mutable
    // and expose `Move` and `Reset` methods that change their properties.

    // Wrap around the sides of the Maze
    let wrap (x,y) (dx,dy) =
        let x =
                if dx = -1 && x = 0 then 30 * 8
                elif dx = 1  && x = 30 *8 then 0
                else x
        x + dx, y + dy

    // Mutable representation of a ghost
    type Ghost(image: HTMLImageElement,x,y,v) =
        let mutable x' = x
        let mutable y' = y
        let mutable v' = v
        member val Image = image
        member val IsReturning = false with get, set
        member __.X = x'
        member __.Y = y'
        member __.V = v'
        // Move back to initial location
        member ghost.Reset() =
            x' <- x
            y' <- y
        // Move in the current direction
        member ghost.Move(v) =
            v' <- v
            let dx,dy = v
            let x,y = wrap (x',y') (dx,dy)
            x' <- x
            y' <- y

module Game =

    open Images
    open Types

    // Here we define the maze, tile bits and blank block. The maze is defined as one big string
    // using ASCII-art encoding. Where `/`, `7`, `L` and `J` represent corners (upper-left, upper-right,
    // lower-left and lower-right), `!`, `|`, `-` and `_` represent walls (left, right, top, bottom) while
    // `o` and `.` represent two kinds of pills in the maze.
    let maze =
        [|  "##/------------7/------------7##"
            "##|............|!............|##"
            "##|./__7./___7.|!./___7./__7.|##"
            "##|o|  !.|   !.|!.|   !.|  !o|##"
            "##|.L--J.L---J.LJ.L---J.L--J.|##"
            "##|..........................|##"
            "##|./__7./7./______7./7./__7.|##"
            "##|.L--J.|!.L--7/--J.|!.L--J.|##"
            "##|......|!....|!....|!......|##"
            "##L____7.|L__7 |! /__J!./____J##"
            "#######!.|/--J LJ L--7!.|#######"
            "#######!.|!          |!.|#######"
            "#######!.|! /__==__7 |!.|#######"
            "-------J.LJ |      ! LJ.L-------"
            "########.   | **** !   .########"
            "_______7./7 |      ! /7./_______"
            "#######!.|! L______J |!.|#######"
            "#######!.|!          |!.|#######"
            "#######!.|! /______7 |!.|#######"
            "##/----J.LJ L--7/--J LJ.L----7##"
            "##|............|!............|##"
            "##|./__7./___7.|!./___7./__7.|##"
            "##|.L-7!.L---J.LJ.L---J.|/-J.|##"
            "##|o..|!.......<>.......|!..o|##"
            "##L_7.|!./7./______7./7.|!./_J##"
            "##/-J.LJ.|!.L--7/--J.|!.LJ.L-7##"
            "##|......|!....|!....|!......|##"
            "##|./____JL__7.|!./__JL____7.|##"
            "##|.L--------J.LJ.L--------J.|##"
            "##|..........................|##"
            "##L--------------------------J##" |]

    let tileBits =
        [|  [|0b00000000;0b00000000;0b00000000;0b00000000;0b00000011;0b00000100;0b00001000;0b00001000|]
            [|0b00000000;0b00000000;0b00000000;0b00000000;0b11111111;0b00000000;0b00000000;0b00000000|] // top
            [|0b00000000;0b00000000;0b00000000;0b00000000;0b11000000;0b00100000;0b00010000;0b00010000|] // tr
            [|0b00001000;0b00001000;0b00001000;0b00001000;0b00001000;0b00001000;0b00001000;0b00001000|] // left
            [|0b00010000;0b00010000;0b00010000;0b00010000;0b00010000;0b00010000;0b00010000;0b00010000|] // right
            [|0b00001000;0b00001000;0b00000100;0b00000011;0b00000000;0b00000000;0b00000000;0b00000000|] // bl
            [|0b00000000;0b00000000;0b00000000;0b11111111;0b00000000;0b00000000;0b00000000;0b00000000|] // bottom
            [|0b00010000;0b00010000;0b00100000;0b11000000;0b00000000;0b00000000;0b00000000;0b00000000|] // br
            [|0b00000000;0b00000000;0b00000000;0b00000000;0b11111111;0b00000000;0b00000000;0b00000000|] // door
            [|0b00000000;0b00000000;0b00000000;0b00011000;0b00011000;0b00000000;0b00000000;0b00000000|] // pill
            [|0b00000000;0b00011000;0b00111100;0b01111110;0b01111110;0b00111100;0b00011000;0b00000000|] // power
        |]

    let blank =
        [| 0b00000000;0b00000000;0b00000000; 0b00000000;0b00000000;0b00000000;0b00000000;0b00000000 |]

    // Check for walls:
    // The following functions parse the maze representation and check various properties of the maze.
    // Those are used for rendering, but also for checking whether Pacman can go in a given direction.
    // Characters _|!/7LJ represent different walls

    let isWall (c:char) =
        "_|!/7LJ-".IndexOf(c) <> -1

    // Returns ' ' for positions outside of range
    let tileAt (x,y) =
        if x < 0 || x > 30 then ' ' else maze.[y].[x]

    // Is the maze tile at x,y a wall?
    let isWallAt (x,y) =
        tileAt(x,y) |> isWall

    // Is Pacman at a point where it can turn?
    let isAligned n = (n % 8) = 5

    // Check whether Pacman can go in given direction
    let noWall (x,y) (ex,ey) =
        let bx, by = (x+6+ex) >>> 3, (y+6+ey) >>> 3
        isWallAt (bx,by) |> not

    let canGoUp (x,y) =
        // TODO calculate if sprite can move up
        if noWall(x,y) (0,-1) = true then
            true
        else false
    let canGoDown (x,y) =
        if noWall(x,y) (0,1) = true then
            true
        else false
    let canGoLeft (x,y) =
        if noWall(x,y) (-1,0) = true then
            true
        else false
    let canGoRight (x,y) =
        if noWall(x,y) (1,0) = true then
            true
        else false

    // Background rendering
    // ================================
    // To render the background, we first fill the background
    // and then iterate over the string lines that represent the maze and we draw images of
    // walls specified in the `tileBits` value earlier (or use `blank` tile for all other characters).

    // The following is used to map from tile characters to the `tileBits` values and to draw individual lines:
    let tileColors = "BBBBBBBBBYY"
    let tileChars =  "/_7|!L-J=.o"

    // Returns tile for a given Maze character
    let toTile (c:char) =
        let i = tileChars.IndexOf(c)
        if i = -1 then blank, 'B'
        else tileBits.[i], tileColors.[i]

    // Draw the lines specified by a wall tile
    let draw f (lines:int[]) =
        let width = 8
        lines
        |> Array.iteri
            (fun y line ->
                for x in 0 .. width-1 do
                    let bit = (1 <<< (width - 1 - x))
                    let pattern = line &&& bit
                    if pattern <> 0 then f (x,y))

    // Creates a brush for rendering the given RGBA color
    let createBrush (context:CanvasRenderingContext2D) (r,g,b,a) =
        let id = context.createImageData(1.0, 1.0)
        let d = id.data
        d.[0] <- r; d.[1] <- g
        d.[2] <- b; d.[3] <- a
        id

    // The main function for rendering background just fills the canvas with a black color and
    // then iterates over the maze tiles and renders individual walls:
    let createBackground () =
        let background = document.createElement("canvas") :?> HTMLCanvasElement
        background.width <- 256.
        background.height <- 256.
        let context = background.getContext_2d()

        // Fill background with black
        context.fillStyle <- !^ "rgb(0,0,0)"
        context.fillRect (0., 0. , 256., 256.);

        // Render individual tiles of the maze
        let bush = 
            createBrush context (255uy, 255uy, 255uy, 255uy)

        let yellow = 
            createBrush context (255uy, 255uy, 0uy, 255uy)
        
        let blue = 
            createBrush context (0uy, 0uy, 255uy, 255uy)

        for y in 0 .. maze.Length - 1 do
            let line = maze.[y]
            for x in 0 .. line.Length - 1  do
                let c = line.[x] 
                let data, color = toTile(c)
                
                let brush = 
                    if color = 'B' then blue
                    else yellow
                let drawPoint (x',y') =
                    context.putImageData
                        (brush, float (x*8 + x'), float (y*8 + y'))
                draw drawPoint data
                    
        background

    // Clear whatever is rendered in the specified Maze cell
    let clearCell (background : HTMLCanvasElement) (x,y) =
        let context = background.getContext_2d()
        context.fillStyle <- !^ "rgb(0,0,0)"
        context.fillRect (float (x*8), float (y*8), 8., 8.)

    let createGhosts context =
        [|  Images.redd, (16, 11), (1,0)
            Images.cyand, (14, 15), (1,0)
            Images.pinkd, (16, 13), (0,-1)
            Images.oranged, (18, 15), (-1,0) |]
            |> Array.map (fun (data,(x,y),v) ->
                Ghost(Images.createImage data, (x*8)-7, (y*8)-3, v) )

    // Generating Ghost movement
    // =========================
    // For generating Ghost movements, we need an implementation of the [Flood fill algorithm](https://en.wikipedia.org/wiki/Flood_fill),
    // which we use to generate the shortest path home when Ghosts are returning. The `fillValue` function does this, by starting
    // at a specified location (which can be one of the directions in which ghosts can go).

    // Recursive flood fill function
    let flood canFill fill (x,y) =
        let rec f n = function
        | [] -> ()
        | ps ->
            let ps = ps |> List.filter (fun (x, y) -> canFill (x, y))
            ps
            |> List.iter (fun (x, y) -> fill (x,y,n))

            ps
            |> List.collect
                (fun (x, y) ->
                    [(x-1, y); (x+1, y); (x, y-1); (x, y+1)]) |> f (n+1)
        f 0 [(x,y)]

    // Possible routes that take the ghost home
    let homeRoute =
        let numbers =
            maze
            |> Array.map
                (fun line ->
                    line.ToCharArray()
                    |> Array.map (fun c -> if isWall c then 999 else -1) )
        let canFill (x:int,y:int) =
            y>=0 && y < (numbers.Length-1) &&
            x>=0 && x < (numbers.[y].Length-1) &&
            numbers.[y].[x] = -1
        let fill (x,y,n) =
            numbers.[y].[x] <- n
        flood canFill fill (16,15)
        numbers

    // Find the shortest way home from specified location
    // (adjusted by offset in which ghosts start)
    let fillValue (x,y) (ex,ey) =
        let bx = int (floor(float ((x+6+ex)/8)))
        let by = int (floor(float ((y+6+ey)/8)))
        homeRoute.[by].[bx]

    let fillUp (x,y) = fillValue (x,y) (0,-4)
    let fillDown (x,y) = fillValue (x,y) (0,5)
    let fillLeft (x,y) = fillValue (x,y) (-4,0)
    let fillRight (x,y) = fillValue (x,y) (5,0)

    // When choosing a direction, ghosts that are returning will go in the direction
    // that leads them home. Other ghosts generate a list of possible directions (the `directions` array)
    // and then filter those that are in the direction of Pacman and choose one of the options. If they
    // are stuck and cannot go in any way, they stay where they are.
    let chooseGhostMoveDirection (ghost:Ghost) =
        let x,y = ghost.X, ghost.Y
        let dx,dy = ghost.V
        // Are we facing towards the given point?
        let isBackwards (a,b) =
            (a <> 0 && a = -dx) || (b <> 0 && b = -dy)
        // Generate array with possible directions
        let directions =
            [|  if canGoLeft(x,y) then yield (-1,0), fillLeft(x,y)
                if canGoDown(x,y) then yield (0,1), fillDown(x,y)
                if canGoRight(x,y) then yield (1,0), fillRight(x,y)
                if canGoUp(x,y) then yield (0,-1), fillUp(x,y) |]

        if ghost.IsReturning then
            // Returning ghosts find the shortest way home
            let xs = directions |> Array.sortBy snd
            let v, n = xs.[0]
            if n = 0 then ghost.IsReturning <- false
            v
        else
            // Other ghosts pick one direction towards Pacman
            let xs =
                directions
                |> Array.map fst
                |> Array.filter (not << isBackwards)
            if xs.Length = 0 then 0, 0
            else
                let randomNum = System.Random().NextDouble()
                let i = randomNum * float xs.Length
                xs.[int (floor i)]

    // Count number of dots in the maze
    let countDots () =
        // TODO for the end of level detection to work, you'll need to count the dots in the maze
        1

    // ## The game play function

    // Most of the Pacman game logic is wrapped in the top-level `playLevel` function. This takes two functions - that are called
    // when the game completes - and then it initializes the world state and runs in a loop until the end of the game.
    // The following outlines the structure of the function:

    //     let playLevel (onLevelCompleted, onGameOver) =
    //         // (Create canvas, background and ghosts)
    //         // (Define the Pacman state)
    //         // (Move ghosts and Pacman)
    //         // (Detect pills and collisions)
    //         // (Rendering everything in the game)
    //         let rec update () =
    //             logic ()
    //             render ()
    //             if !dotsLeft = 0 then onLevelCompleted()
    //             elif !energy <= 0 then onGameOver()
    //             else window.setTimeout(update, 1000. / 60.) |> ignore

    //         update()

    // After defining all the helpers, the `update` function runs in a loop (via a timer) until there are no dots
    // left or until the Pacman is out of energy and then it calls one of the continuations.

    // In the following 5 sections, we'll look at the 5 blocks of code that define the body of the function.

    let playLevel (onLevelCompleted, onGameOver) =
        // ### Create canvas, background and ghosts
        // In the first part, the function finds the `<canvas>` element, paints it with black background and
        // creates other graphical elements - namely the game background, ghosts and eyes:
        // Fill the canvas element
        let canvas = document.getElementsByTagName("canvas").[0] :?> HTMLCanvasElement
        canvas.width <- 256.
        canvas.height <- 256.
        let context = canvas.getContext_2d()
        context.fillStyle <- !^ "rgb(0,0,0)"
        context.fillRect (0., 0. , 256., 256.);
        let bonusImages =
            [|  createImage Images._200; createImage Images._400;
                createImage Images._800; createImage Images._1600 |]

        // Load images for rendering
        let background = createBackground()
        let ghosts = createGhosts(context)
        let blue,eyed = createImage Images.blue, createImage Images.eyed

        // ### Define the Pacman state
        // Next, we define the game state. Pacman game uses mutable state, so the following uses
        // mutable identifiers.
        let pills =
            maze
            |> Array.map
                (fun line ->
                    line.ToCharArray() |> Array.map id)
        let mutable dotsLeft = countDots()
        let mutable score = 0
        // the index of the bonus scored for eating a ghost
        // 200,  400, 800, or 1600 points
        let mutable bonus = 0
        // the bonus images to be rendered, the first part of the tuple
        // is a count down of how long they should stay on the screen
        let mutable bonuses = []
        let mutable energy = 128
        let mutable flashCountdown = 0
        let mutable powerCountdown = 0

        // Pacman's location and travel direction
        let mutable pacmanX, pacmanY = (16 * 8 - 7), (23 * 8 - 3)
        let mutable pacmanDirectionVector = (0,0)

        let moveGhosts () =
            // TODO loop through ghosts choose a direction for them to move
            ()

        let movePacman () =
            // In which directions should pacman go?
            let inputs =
                [|  if Keyboard.isPressed 38 (*up*) then
                        yield canGoUp (pacmanX, pacmanY), (0,-1)
                    if Keyboard.isPressed 40 (*down*) then
                        yield canGoDown (pacmanX, pacmanY), (0,1)
                    if Keyboard.isPressed 37 (*left*) then
                        yield canGoLeft (pacmanX, pacmanY), (-1,0)
                    if Keyboard.isPressed 39 (*right*) then
                        yield canGoRight (pacmanX, pacmanY), (1,0) |]
            // Can we continue in the same direction?
            let canGoForward =
                match pacmanDirectionVector with
                | 0,-1 -> canGoUp(pacmanX, pacmanY)
                | 0,1  -> canGoDown(pacmanX, pacmanY)
                | -1,0 -> canGoLeft(pacmanX, pacmanY)
                | 1, 0 -> canGoRight(pacmanX, pacmanY)
                | _ -> false
            // What new directions can we take?
            let availableDirections =
                inputs
                |> Array.filter fst
                |> Array.map snd
                |> Array.sortBy (fun directionVector' -> directionVector' = pacmanDirectionVector)
            if availableDirections.Length > 0 then
                // Choose the first one, prefers no change
                pacmanDirectionVector <- availableDirections.[0]
            elif inputs.Length = 0 || not canGoForward then
                // There are no options - stop
                pacmanDirectionVector <- 0,0

            // Update X and Y accordingly
            let x',y' = wrap (pacmanX, pacmanY) pacmanDirectionVector
            pacmanX <- x'
            pacmanY <- y'

        // Check if Pacman eats a pill at current cell
        let eatPills () =
            // TODO map Pacman's coordinates to the pills array
            // TODO get the current character from the pills array
            // TODO clear the eaten pill from the array
            // TODO call 'clearCell' to clear the pill from the background
            // TODO  decrement the dotsLeft
            // TODO if it's small pill:
                // * update the score
                // * play a pill eaten sound
            // TODO if it's large pill:
                // Eating a large pill turns on the power mode
                // * reset the bonus count to zero
                // * update the score
                // * set powerCountdown to 250 to turn on power mode
                // * play a Powerup sound
            ()

        // Are there any ghosts that collide with Pacman?
        let touchingGhosts () =
            // TODO loop though the ghosts to see if any is within 13 pixels of Pacman
            [||]

        // Handle collision detections between Pacman and ghosts
        let collisionDetection () =
            let touched = touchingGhosts ()
            // TODO handle any collisions
                // if any ghost are touching Pacman then
                // * if we're in power mode the ghost is eaten so:
                    // for each ghost eaten:
                        // * play the "EatGhost" sound
                        // * set the ghost's IsReturning to true
                        // * calculate the bonus and update the score
                        // * update the 'bonuses' image list
                        // * update the 'bonus' index
                // * else Pacman is hurt by the ghosts so:
                    // * decrement his energy
                    // * play the "Hurt" sound
                    // * set 'flashCountdown' to 30
                // if 'flashCountdown' down is positive decrement it
            ()

        // Updates bonus points
        let updateBonus () =
            // TODO update the bonus lists, this means:
                // * decrementing the counters by 1
                // * bonuses where the counter is zero
            ()

        // The logic is called from the following single `logic` function that includes all the checks:
        let logic () =
            moveGhosts()
            movePacman()
            eatPills ()
            if powerCountdown > 0 then powerCountdown <- powerCountdown - 1
            collisionDetection()
            updateBonus ()

        // ### Rendering everything in the game
        // When rendering everything in the game, we first draw the background and then we render
        // individual components. Those include the score, remaining energy, pacman, ghosts and bonuses.
        // Each of those is handled by a single nested function that are put together in `render`.
        // We start with Pacman and remaining energy:
        let renderPacman () =
            let p = Images.imageAt(pacmanX, pacmanY, pacmanDirectionVector)
            if (flashCountdown >>> 1) % 2 = 0 then
                context.drawImage(!^ p, float pacmanX, float pacmanY)

        let renderEnergy () =
            // TODO use context.fillRect to draw a bar representing remaining energy
            ()

        // The next three functions render ghosts, current score and bonuses:
        let renderGhosts () =
            for ghost in ghosts do
                let image =
                    // TODO calculate the right ghost image
                    // if the ghost is returning, use the eyes
                    // if Pacman is in power mode use the blue ghost
                    // if power mode is almost over the ghost should flash
                    ghost.Image
                context.drawImage(!^ image, float ghost.X, float ghost.Y)

        let renderScore () =
            // TODO use context.fillText to render score, you'll need to set .fillStyle & .font first
            ()

        let renderBonus () =
            // TODO use context.drawImage to render each image in the bonus list
            ()

        let render () =
            context.drawImage(!^ background, 0., 0.)
            renderScore ()
            renderEnergy ()
            renderPacman()
            renderGhosts ()
            renderBonus ()

        let rec update () =
            logic ()
            render ()
            if dotsLeft = 0 then onLevelCompleted()
            elif energy <= 0 then onGameOver()
            else window.setTimeout(update, 1000 / 60) |> ignore

        update()

    // Game entry point
    // ================
    // Now we have everything we need to start the game, so the last step is to define the
    // `levelCompleted` and `gameOver` functions (that are called when the game ends), render
    // the starting state of the game (with "CLICK TO START" text) and start the game!
    let rec game () =
        // Initialize keyboard and canvas
        Keyboard.reset()
        let canvas = document.getElementsByTagName("canvas").[0] :?> HTMLCanvasElement
        let context = canvas.getContext_2d()

        // A helper function to draw text
        let drawText(text,x,y) =
            context.fillStyle <- !^ "white"
            context.font <- "bold 8px";
            context.fillText(text, x, y)

        // Called when level is completed
        let levelCompleted () =
            drawText("COMPLETED",96.,96.)
            window.setTimeout(game, 5000) |> ignore

        // Called when the game ends
        let gameOver () =
            drawText("GAME OVER",96.,96.)
            window.setTimeout(game, 5000) |> ignore

        // Start a new game after click!
        let start () =
            let background = createBackground()
            context.drawImage(!^ background, 0., 0.)
            context.fillStyle <- !^ "white"
            context.font <- "bold 8px";
            drawText("CLICK TO START", 88., 96.)
            let mutable playing = false
            canvas.addEventListener("click", fun _ ->
                if not playing then
                    playing <- true
                    playLevel (levelCompleted, gameOver))

        // Resize canvas and get ready for a game
        let canvas = document.getElementsByTagName("canvas").[0] :?> HTMLCanvasElement
        canvas.width <- 256.
        canvas.height <- 256.
        start()

Keyboard.init()
Game.game()