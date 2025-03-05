open Game
open Ship
open System

(*
    Main entry for the game
    Sets up the initial game and starts the game loop
    After the ship has been destroyed, the game can be ended by presing any key
*)

[<EntryPoint>]
let main argv =
    // Generates the ship
    let shipPositions = generateShip (1)
    printfn "The enemy is being reinforced with a dreadnought! Destroy it!!"
    // Start the game loop with the ship positions and empty sets for guesses and hits
    gameLoop shipPositions Set.empty Set.empty
    printfn "press any key to exit the game.."
    Console.ReadKey() |> ignore
    0
