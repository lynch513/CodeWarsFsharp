module CodeWars.FakeBinary

open System

let fakeBin (x: string) =
    x
    |> Seq.map (fun i -> if (i |> string |> int >= 5) then '1' else '0')
    |> String.Concat

