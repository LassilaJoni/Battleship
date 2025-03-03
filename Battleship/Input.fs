module Input

open Config

let parseInput (input: string) =
    
    if input.Length < 2 then None
    else 
        let row = rows |> List.tryFindIndex (fun c -> c = input.[0])
        let col = input.Substring(1) |> int
        match row with
        | Some r when col >= 1 && col <= boardSize -> Some (r, col - 1)
        | _ -> None