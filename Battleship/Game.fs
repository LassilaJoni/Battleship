module Game

open Config
open Board
open Input
open Ship

open System
open System.Threading

let rec gameLoop (shipCells: Set<int * int>) (guesses: Set<int * int>) (hits: Set<int * int>) =
    if shipCells.IsEmpty then
        printfn "You Defeated The dreadnought!"  
    else
        printBoard guesses hits shipCells
        printfn "Enter a coordinate (e.g. A1): "
        let input = Console.ReadLine().Trim().ToUpper()
        match parseInput input with
        | None ->
            printfn "Invalid input. Try again!"
            gameLoop shipCells guesses hits
        | Some pos ->
            if guesses.Contains pos then
                printfn "You've already guessed that, try again!"
                gameLoop shipCells guesses hits
            else
                let newGuesses = guesses.Add pos
                if Set.contains pos shipCells then
                    printfn "Enemy HIT!"
                    let newHits = hits.Add pos
                    let remainingShipCells = shipCells |> Set.filter (fun p -> p <> pos)
                    gameLoop remainingShipCells newGuesses newHits
                else
                    printfn "You missed!"
                    gameLoop shipCells newGuesses hits