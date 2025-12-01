import re


def part1():
    with open('in.txt') as file:
        lines = file.readlines()
        curr = 50
        res = 0

        for line in lines:
            match = re.search('([RL])(\\d*)', line)
            direction, n = match.groups()
            n = int(n)

            if direction == 'R':
                curr = (curr + n) % 100
            else:
                curr = (curr - n) % 100

            if curr == 0: res += 1

        print(res)


def part2():
    with open('in.txt') as file:
        lines = file.readlines()
        res = 0
        curr = 50

        for line in lines:
            match = re.search('([RL])(\\d*)', line)
            direction, n = match.groups()
            n = int(n)

            x = n // 100
            rest = n % 100

            res += x

            if direction == 'R':
                go = curr + rest
                if go >= 100 and curr != 0: res += 1
                curr = (curr + rest) % 100
            else:
                go = curr - rest 
                if go <= 0 and curr != 0: res += 1
                curr = (curr - rest) % 100

        print(res)


part1()
part2()