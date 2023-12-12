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

let get_game (line: string) =
    let start = line.IndexOf(' ')
    let end_idx = line.IndexOf(':')
    let game_id = line.Substring(start, end_idx - start)
    printfn "Start %s" game_id
    0

let rec get_rounds (line: string) =
    let round_end = line.IndexOf(';')
    if round_end > 0 then
        printfn "Round: %s" (line.Substring(0, round_end))
        get_rounds (line.Substring(round_end + 2))
    else 
        printfn "Round: %s" (line.Substring(0))
        0

let rec sum_games sum = 
    match System.Console.ReadLine() with  
    | null | "" -> sum
    | line -> 
        printfn "---Game---"
        let round = get_rounds (line.Substring(line.IndexOf(':') + 2))
        sum_games sum + 1

let total_sum = sum_games 0
printfn "Total sum: %d" total_sum
