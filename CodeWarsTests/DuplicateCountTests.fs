module DuplicateCountTests

open NUnit.Framework
open FsUnit
open CodeWars.DuplicateCount

let lowercase = "abcdefghijklmnopqrstuvwxyz"
let uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

let duplicateCountTestCases =
    seq {
        yield TestCaseData("abcde", 0)
        yield TestCaseData("abcdeaa", 1)
        yield TestCaseData("abcdeaB", 2)
        yield TestCaseData("abcdeaB", 2)
        yield TestCaseData("Indivisibilities", 2)
        yield TestCaseData(lowercase, 0)
        yield TestCaseData(lowercase + "aaAb", 2)
        yield TestCaseData(lowercase + lowercase, 26)
        yield TestCaseData(lowercase + uppercase, 26)
    }

[<TestCaseSource(nameof(duplicateCountTestCases))>]
let ``Should equal to`` (input: string, expected: int) =
    let actual = duplicateCount input
    actual |> should equal expected



