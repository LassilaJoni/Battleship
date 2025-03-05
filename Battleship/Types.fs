module Types

// GuessOutcome represents the possible outcomes of a guess
type GuessOutcome =
    | Hit
    | Miss
    | AlreadyGuessed
    | InvalidInput