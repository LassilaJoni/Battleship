module Board

open System
open Config

let printBoard (guesses: Set<int * int>) (hits: Set<int * int>) (shipCells: Set<int * int>) =
    printfn "  %s" (String.Join(" ", [ for i in 1 .. boardSize -> string (char (i + 64)) ]))
    for row in 0 .. boardSize - 1 do
        printf "%d " (row + 1)
        for col in 0 .. boardSize - 1 do
            let pos = (col, row)
            if hits.Contains pos then
                printf "O "
            elif guesses.Contains pos then
                printf "X "
            else
                printf ". "
        printfn ""