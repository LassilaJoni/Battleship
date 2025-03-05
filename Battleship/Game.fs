module Game

open Config
open Board
open Input
open Ship
open Types

open System
open System.Threading

let rec gameLoop (shipCells: Set<int * int>) (guesses: Set<int * int>) (hits: Set<int * int>) =
    if shipCells.IsEmpty then
        printfn "You Defeated The Dreadnought!"  
    else
        printBoard guesses hits shipCells
        printfn "Enter a coordinate (e.g. A1): "
        let input = Console.ReadLine().Trim().ToUpper()
        match parseInput input with
        | None ->
            printfn "Invalid input. Try again!"
            gameLoop shipCells guesses hits
        | Some pos ->
            let outcome =
                if guesses.Contains pos then AlreadyGuessed
                elif shipCells.Contains pos then Hit
                else Miss
            match outcome with
            | AlreadyGuessed ->
                printfn "You already guessed that position. Try again!"
                gameLoop shipCells guesses hits
            | Hit _ ->
                printfn "Hit!"
                let newGuesses = guesses.Add pos
                let newHits = hits.Add pos
                let remainingShipCells = shipCells.Remove pos
                gameLoop remainingShipCells newGuesses newHits
            | Miss _ ->
                printfn "Miss!"
                let newGuesses = guesses.Add pos
                gameLoop shipCells newGuesses hits