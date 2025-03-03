module Ship

open Config
open System

let generateShip (amoutOfShips: int) =
    let rand = Random()
    let orientation = rand.Next(2) // 0 horizontal, 1 vertical
    if orientation = 0 then
        let row = rand.Next(boardSize)
        let col = rand.Next(boardSize - shipLength + 1)
        [ for i in 0 .. shipLength - 1 -> (row, col + i) ] |> Set.ofList
    else
        let col = rand.Next(boardSize)
        let row = rand.Next(boardSize - shipLength + 1)
        [ for i in 0 .. shipLength - 1 -> (row + i, col) ] |> Set.ofList