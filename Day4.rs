use std::fs;

fn main() {
    let mut points: Vec<_> = fs::read_to_string("input.txt")
        .expect("Something went wrong reading file!")
        .lines()
        .filter_map(|line| line
            .split_once(":")
            .and_then(|(_, second)| second.split_once("|"))
        )
        .map(|(first, second)| (
            first.split_whitespace().filter_map(|s| s.parse().ok()).collect::<Vec<i32>>(),
            second.split_whitespace().filter_map(|s| s.parse().ok()).collect::<Vec<i32>>()
        ))
        .map(|(x, y)| (1, x.iter().filter(|x| y.contains(x)).count()))
        .collect();

    for i in 0..points.len() {
        for j in (i + 1)..(i + 1 + points[i].1).min(points.len()) {
            points[j].0 += points[i].0;
        }
    }

    println!("Part 2 & 1: {:?}", points.iter().fold((0,0), |acc, &(x, y)| (acc.0 + x, match y {
        0 => acc.1,
        count => (1 << count - 1) + acc.1
    })));
}
