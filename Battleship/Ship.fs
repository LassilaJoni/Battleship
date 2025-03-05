module Ship

open Config
open System

(*
    generateShip randomly creates a set of coordinates for a ship.
    The ship is either placed horizontally or vertically, and ensuring that it fits within the board
    amountOfShips currently only generates a single ship, no logic for that implemented since whole game implementation wasn't the point of the assignment
*)

let generateShip (amoutOfShips: int) =
    let rand = Random()
    let orientation = rand.Next(2) // 0 horizontal, 1 vertical
    // Horizontal placement
    if orientation = 0 then
        //Randomly choose the row and a starting column where the ship fits.
        let row = rand.Next(boardSize)
        let col = rand.Next(boardSize - shipLength + 1)
        // Creates a list of coordinates for the ship and converts it to a set
        [ for i in 0 .. shipLength - 1 -> (row, col + i) ] |> Set.ofList
    else
        // Vertical placement
        // Randomly chooses the column and a starting row where the ship fits.
        let col = rand.Next(boardSize)
        let row = rand.Next(boardSize - shipLength + 1)
        // Creates a list of coordinates for the ship and converts it to a set
        [ for i in 0 .. shipLength - 1 -> (row + i, col) ] |> Set.ofList