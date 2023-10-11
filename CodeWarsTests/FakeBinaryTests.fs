module FakeBinaryTests

open NUnit.Framework
open FsUnit
open CodeWars.FakeBinary

let testStr = "testStr"

let fakeBinTestCases =
    seq {
        yield TestCaseData("45385593107843568", "01011110001100111")
        yield TestCaseData("509321967506747", "101000111101101")
        yield TestCaseData("366058562030849490134388085", "011011110000101010000011011")
    }

[<TestCaseSource("fakeBinTestCases")>]
let ``Should equal to test`` (input: string, expected: string) = // (input: string, expected: string) =
    let actual = fakeBin input
    actual |> should equal expected


let testTestCases =
    [| true |]


[<TestCaseSource(nameof(testTestCases))>]
let ``Should be true`` (input: bool) =
    true |> should equal true



