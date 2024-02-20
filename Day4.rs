use std::fs;

fn main() {
    let points1 = fs::read_to_string("input.txt")
        .expect("Something went wrong reading file!")
        .lines()
        .filter_map(|line| line
            .split_once(":")
            .and_then(|(_, second)| second.split_once("|"))
        )
        .map(|(first, second)| (
            first.split_whitespace().filter_map(|s| s.parse().ok()).collect::<Vec<i32>>(),
            second.split_whitespace().filter_map(|s| s.parse().ok()).collect::<Vec<i32>>()
        )).fold(0, |acc, (x,y)| match x.iter().filter(|x| y.contains(x)).count() {
            0 => acc,
            count => (1 << count - 1) + acc
        });

    let mut points2: Vec<_> = fs::read_to_string("input.txt")
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
        for j in (i + 1)..(i + points[i].1 + 1).min(points.len()) {
            points[j].0 += points[i].0;
        }
    }

    println!("{:?}", points1);
    println!("{:?}", points2.iter().map(|(a, _)| a).sum::<usize>());
}
