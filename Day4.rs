use std::fs;

fn main() {
    let mut cards: Vec<_> = fs::read_to_string("input.txt")
        .expect("Error!")
        .lines()
        .filter_map(|line| line
            .split_once(":")
            .and_then(|(_, second)| second.split_once("|"))
        )
        .map(|(winners, drawn)| (
            winners.split_whitespace().filter_map(|s| s.parse().ok()).collect::<Vec<i32>>(),
            drawn.split_whitespace().filter_map(|s| s.parse().ok()).collect::<Vec<i32>>()
        ))
        .map(|(winners, drawn)| (1, winners.iter().filter(|winning| drawn.contains(winning)).count()))
        .collect();

    for i in 0..cards.len() {
        for j in (i + 1)..(i + 1 + cards[i].1).min(cards.len()) {
            cards[j].0 += cards[i].0;
        }
    }

    println!("Part 1 & 2: {:?}", cards.iter().fold((0,0), |acc, &(copies, points)| (match points {
        0 => acc.0,
        count => (1 << count - 1) + acc.0
    }, acc.1 + copies)));
}
