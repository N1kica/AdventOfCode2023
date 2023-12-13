// dotnet run < input.txt
// cat input.txt | dotnet run

let max_red = 12
let max_green = 13
let max_blue = 14

let exceeds_max count color =
    match color with
    | "red" -> count > max_red
    | "green" -> count > max_green
    | "blue" -> count > max_blue
    | _ -> false

let find_max count color red green blue =
    match color with
    | "red" -> 
        if count > red then
            (count, green, blue)
        else
            (red, green, blue)
    | "green" -> 
        if count > green then
            (red, count, blue)
        else
            (red, green, blue)
    | "blue" -> 
        if count > blue then
            (red, green, count)
        else
            (red, green, blue)
    | _ -> (red, green, blue)

let rec parse_round (input: string array) index sum game=
    match exceeds_max (int input.[index]) input.[index + 1] with
    | true -> sum 
    | _ ->  
        if index + 2 >= input.Length then
            sum + game
        else
            parse_round input (index + 2) sum game

let rec parse_round_two (input: string array) index sum game red green blue=
    let (a, b, c) = find_max (int input.[index]) input.[index + 1] red green blue
    if index + 2 >= input.Length then
        sum + a * b * c
    else
        parse_round_two input (index + 2) sum game a b c

let rec sum_games sum game = 
    match System.Console.ReadLine() with  
    | null | "" -> sum
    | line -> 
        let round = 
            parse_round_two (line.Substring(line.IndexOf(':') + 2)
                .Trim()
                .Replace(",", "")
                .Replace(";", "")
                .Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries)
            ) 0 sum game 0 0 0
        sum_games round (game + 1)

let result  = sum_games 0 1
printfn "Total sum: %d" result

