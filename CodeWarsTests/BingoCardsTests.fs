module BingoCardsTests

open NUnit.Framework
open CodeWars.BingoCards

let columnHasCorrectRange (c: string seq) (p: string) (l: int) =
    let column =
        c
        |> Seq.filter (fun x -> x.StartsWith(p))
        |> Seq.map (fun x -> Seq.skip 1 x |> Seq.map string |> String.concat "")
        |> Seq.map (fun x -> System.Convert.ToInt32(x))

    let result =
        column
        |> Seq.filter (fun x -> x < l && x > (l + 14))
        |> Seq.length
        |> (fun x -> x = 0)

    Assert.AreEqual(true, result)

let columnHasCorrectLength (c: string seq) (p: string) (l: int) =
    let column = c |> Seq.filter (fun x -> x.StartsWith(p))
    let result = column |> Seq.length |> (fun x -> x = l)
    Assert.AreEqual(true, result)

[<Test>]
let ``has 24 number`` () =
    let card = getCard ()
    Assert.AreEqual(24, card |> Array.toSeq |> Seq.length)

[<Test>]
let ``has only unique numbers`` () =
    let card = getCard ()

    Assert.True(
        card
        |> Array.toSeq
        |> Seq.length
        |> (fun x -> x > 2)
    )

    Assert.AreEqual(card.Length, card |> Array.toSeq |> Seq.distinct |> Seq.length)

[<Test>]
let ``has columns of correct length`` () =
    let card = getCard ()
    columnHasCorrectLength card "B" 5
    columnHasCorrectLength card "I" 5
    columnHasCorrectLength card "N" 4
    columnHasCorrectLength card "G" 5
    columnHasCorrectLength card "O" 5

[<Test>]
let ``numbers are ordered by column`` () =
    let card = getCard ()

    Assert.AreEqual(
        "BINGO",
        card
        |> Array.toSeq
        |> Seq.map (fun x -> x.[0].ToString())
        |> Seq.distinct
        |> String.concat ""
    )

[<Test>]
let ``numbers within column are in correct range`` () =
    let card = getCard ()
    Assert.True(card |> Seq.length |> (fun x -> x > 2))
    columnHasCorrectRange card "B" 1
    columnHasCorrectRange card "I" 16
    columnHasCorrectRange card "N" 31
    columnHasCorrectRange card "G" 46
    columnHasCorrectRange card "O" 61

[<Test>]
let ``numbers within column are in random order`` () =
    let card = getCard ()

    let numbers =
        Array.toSeq card
        |> Seq.map (fun x -> System.Convert.ToInt32(x.[1]))
        |> Seq.toList

    Assert.True(
        [ for i in 1 .. card.Length - 1 ->
              if numbers.[i] > numbers.[i - 1] then
                  0
              else
                  1 ]
        |> Seq.sum
        |> (fun x -> x > 2)
    )

    Assert.True(
        [ for i in 1 .. card.Length - 1 ->
              if numbers.[i] < numbers.[i - 1] then
                  0
              else
                  1 ]
        |> Seq.sum
        |> (fun x -> x > 2)
    )

