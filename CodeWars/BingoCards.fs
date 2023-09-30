module CodeWars.BingoCards

open System

type BingoCard = { ColumnName: string; Count: int; From: int; To: int }

let BingoRules =
    [ { ColumnName = "B"; Count = 5; From = 1; To = 15 }
      { ColumnName = "I"; Count = 5; From = 16; To = 30 }
      { ColumnName = "N"; Count = 4; From = 31; To = 45 }
      { ColumnName = "G"; Count = 5; From = 46; To = 60 }
      { ColumnName = "O"; Count = 5; From = 61; To = 75 } ]

let rnd = new Random()

let shuffle (from: int) (to_: int) (count: int) =
    let mutable result = []
    while List.length result < count do
        let randomNumber = rnd.Next(from, to_)
        if not <| List.contains randomNumber result then
            result <- randomNumber :: result
    result

let getCard () =
    seq {
        for i in BingoRules do
            let randomNumbersRange = shuffle i.From i.To i.Count
            for j in randomNumbersRange do
                let result = sprintf "%s%i" i.ColumnName j
                yield result
    }
    |> Array.ofSeq
