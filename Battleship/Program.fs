open Game
open Ship
open System


[<EntryPoint>]
let main argv =
    let shipPositions = generateShip (2)
    printfn "The enemy is being reinforced with a dreadnought! Destroy it!!"
    gameLoop shipPositions Set.empty Set.empty
    printfn "press any key to exit the game.."
    Console.ReadKey() |> ignore
    0
