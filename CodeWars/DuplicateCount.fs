module CodeWars.DuplicateCount

open System

let duplicateCount (input: string) =
    input
    |> Seq.groupBy (fun ch -> Char.ToLower ch) // (fun ch -> Char.uppercase ch)
    |> Seq.map (fun (k, v) -> (k, Seq.length v))
    |> Seq.filter (fun (k, v) -> v > 1)
    |> Seq.length
