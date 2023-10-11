module FakeBinaryTests

open NUnit.Framework
open FsUnit
open CodeWars.FakeBinary

[<TestCase("45385593107843568", "01011110001100111")>]
[<TestCase("509321967506747", "101000111101101")>]
[<TestCase("366058562030849490134388085", "011011110000101010000011011")>]
let ``Should equal to test`` (input: string, expected: string) = // (input: string, expected: string) =
    let actual = fakeBin input
    actual |> should equal expected





