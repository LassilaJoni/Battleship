module Input

open Config

(*
    parseInput converts the string input into a coordinates tuple, (row,col)
    Uses the rows list from Config to determine the correct row index
*)

let parseInput (input: string) =
    
    if input.Length < 2 then None
    else 
        // Find the index of the first character in the rows list.
        let row = rows |> List.tryFindIndex (fun c -> c = input.[0])
        // Convert the second character to an integer
        let col = input.Substring(1) |> int
        // If the row is found and the column is within bounds, return the coordinates
        match row with
        | Some r when col >= 1 && col <= boardSize -> Some (r, col - 1)
        | _ -> None