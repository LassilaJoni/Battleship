module Config

// Configuration settings for the game

// Size of the board. (e.g. 5 is 5x5)
let boardSize = 5
// Length of the ship
let shipLength = 2

// Rows are presented as letters. Much better format than in C# :)
let rows = [ for i in 1 .. boardSize ->  (char (i + 64)) ]