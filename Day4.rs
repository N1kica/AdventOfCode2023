use std::fs;

fn parse_numbers(unparsed: &str) -> Vec<i32> {
    unparsed
        .split_whitespace()
        .filter_map(|s| s.parse().ok())
        .collect()
}

fn main() {
    let points = fs::read_to_string("input.txt")
        .expect("Something went wrong reading file!")
        .lines()
        .filter_map(|line| line
            .split_once(":")
            .and_then(|(_, second)| second.split_once("|"))
        )
        .map(|(first, second)| (
            parse_numbers(first),
            parse_numbers(second)
        )).fold(0, |acc, (x,y)| match x.iter().filter(|x| y.contains(x)).count() {
            0 => acc,
            count => (1 << count - 1) + acc
        });

    println!("{:?}", points);
}
