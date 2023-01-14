namespace CodeWars

module Tribonacci =

    let rec tribonacci signature n =
        if List.length signature >= n then List.take n signature
        else match List.rev signature with
             | [] -> [0]
             | [a] -> [0; 0; a]
             | [b; a] -> [0; a; b]
             | c :: b :: a :: _ -> tribonacci (signature @ [ (a + b + c) ]) n

