// dotnet run Program.fs < input.txt
// cat input.txt | dotnet run Program.fs

let rec find_number (line: string) index direction =
    if index < 0 || index >= line.Length then 
        None
    else
        match line.Substring(index) with
        | c when System.Char.IsDigit(c.[0]) -> Some(int c.[0] - int '0')
        | s when s.StartsWith "one" -> Some(1)
        | s when s.StartsWith "two" -> Some(2)
        | s when s.StartsWith "three" -> Some(3)
        | s when s.StartsWith "four" -> Some(4)
        | s when s.StartsWith "five" -> Some(5)
        | s when s.StartsWith "six" -> Some(6)
        | s when s.StartsWith "seven" -> Some(7)
        | s when s.StartsWith "eight" -> Some(8)
        | s when s.StartsWith "nine" -> Some(9)
        | _ -> find_number line (index + direction) direction

let rec sum_lines sum = 
    match System.Console.ReadLine() with
    | null | "" -> sum
    | line ->
        let first_digit =
            match find_number line 0 1 with
            | Some(digit) -> digit
            | None -> 0
        
        let last_digit =
            match find_number line (line.Length - 1) (-1) with
            | Some(digit) -> digit
            | None -> 0

        sum_lines sum + first_digit * 10 + last_digit

[<EntryPoint>]
let main arg =
    let total_sum = sum_lines 0
    printfn "Total sum: %d" total_sum
    0
