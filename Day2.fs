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

let rec parse_round (input: string array) index sum game=
    match exceeds_max (int input.[index]) input.[index + 1] with
    | true -> sum 
    | _ ->  
        if index + 2 >= input.Length then
            sum + game
        else
            parse_round input (index + 2) sum game

let rec sum_games sum game = 
    match System.Console.ReadLine() with  
    | null | "" -> sum
    | line -> 
        let round = 
            parse_round (line.Substring(line.IndexOf(':') + 2)
                .Trim()
                .Replace(",", "")
                .Replace(";", "")
                .Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries)
            ) 0 sum game
        sum_games round (game + 1)

let result  = sum_games 0 1
printfn "Total sum: %d" result
