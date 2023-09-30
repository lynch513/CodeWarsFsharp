module TribonacciTests

open NUnit.Framework
open FsUnit
open CodeWars.Tribonacci

let tribonacciTestCases =
    seq {
        yield TestCaseData([1; 1; 1], 10, [1;1;1;3;5;9;17;31;57;105])
        yield TestCaseData([0; 0; 1], 10, [0;0;1;1;2;4;7;13;24;44])
        yield TestCaseData([0; 1; 1], 10, [0;1;1;2;4;7;13;24;44;81])
        yield TestCaseData([1; 0; 0], 10, [1;0;0;1;1;2;4;7;13;24])
        yield TestCaseData([0; 0; 0], 10, [0;0;0;0;0;0;0;0;0;0])
        yield TestCaseData([1; 2; 3], 10, [1;2;3;6;11;20;37;68;125;230])
        yield TestCaseData([3; 2; 1], 10, [3;2;1;6;9;16;31;56;103;190])
        yield TestCaseData([300; 200; 100], 0, List.empty<int>)
    }

[<TestCaseSource(nameof(tribonacciTestCases))>]
let ``Should equal to`` (input: int list, n: int, expected: int list) =
    let actual = tribonacci input n
    actual |> should equal expected




