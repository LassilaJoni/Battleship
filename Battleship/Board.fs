module Board

open System
open Config

(*
    PrintBoard displays the current game board.
    It takes three arguments:
    - guesses: a set of coordinates that the player has guessed
    - hits: a set of coordinates that the player has hit
    - shipCells: a set of coordinates that contain the ship
*)
let printBoard (guesses: Set<int * int>) (hits: Set<int * int>) (shipCells: Set<int * int>) =
    // Print the column headers with letters. Prints the rows from Config.fs
    printfn "  %s" (String.Join(" ", rows |> List.map string))
    for row in 0 .. boardSize - 1 do
        // Print the row number on the left
        printf "%d " (row + 1)
        // Print the board
        for col in 0 .. boardSize - 1 do
            // Store the coordinates in a pos variable, containing column and rown
            let pos = (col, row)
            // Check if the current position is a hit, prints O if hit, X if miss and else a . if not guessed
            if hits.Contains pos then
                printf "O "
            elif guesses.Contains pos then
                printf "X "
            else
                printf ". "
        printfn ""