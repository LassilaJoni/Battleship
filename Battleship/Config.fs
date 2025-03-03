module Config

let boardSize = 5
let shipLength = 2

// Rows are presented as letters. Much better format than in C# :)
let rows = [ for i in 1 .. boardSize ->  (char (i + 64)) ]