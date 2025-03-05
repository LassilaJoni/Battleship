module Game

open Config
open Board
open Input
open Ship
open Types

open System
open System.Threading

(*
    gameLopp is the recursive main game loop.
    It takes three arguments:
    - shipCells: a set of coordinates that contain the ship
    - guesses: a set of coordinates that the player has guessed
    - hits: a set of coordinates that the player has hit
    The game continues untl the ship has been completely destroyed.
*)

let rec gameLoop (shipCells: Set<int * int>) (guesses: Set<int * int>) (hits: Set<int * int>) =
    // If all ship cells have been destroyed, the player wins
    if shipCells.IsEmpty then
        printfn "You Defeated The Dreadnought!"  
    else
        // Display the current state on the board
        printBoard guesses hits shipCells
        printfn "Enter a coordinate (e.g. A1): "
        let input = Console.ReadLine().Trim().ToUpper()
        match parseInput input with
        // If input was invalid, for example out of bounds, ask again.
        | None ->
            printfn "Invalid input. Try again!"
            gameLoop shipCells guesses hits
        | Some pos ->
            // Determine the outcome. And initialize the outcome variable
            let outcome =
                if guesses.Contains pos then AlreadyGuessed
                elif shipCells.Contains pos then Hit
                else Miss
            // Handle each outcome using the pattern matching
            match outcome with
            | AlreadyGuessed ->
                printfn "You already guessed that position. Try again!"
                gameLoop shipCells guesses hits
            | Hit _ ->
                printfn "Hit!"
                // Update the guesses and hits sets
                let newGuesses = guesses.Add pos
                let newHits = hits.Add pos
                let remainingShipCells = shipCells.Remove pos
                gameLoop remainingShipCells newGuesses newHits
            | Miss _ ->
                printfn "Miss!"
                // Only updates the guesses set since it was a miss
                let newGuesses = guesses.Add pos
                gameLoop shipCells newGuesses hits