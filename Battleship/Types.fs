module Types

type GuessOutcome =
    | Hit
    | Miss
    | AlreadyGuessed
    | InvalidInput