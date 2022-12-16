def part_one():
    file = open("../data/day_01.txt", "r").read()
    print(file.count('(')-file.count(')'))

def part_two():
    file = open("../data/day_01.txt", "r").read()
    total = 0
    index = 1
    for char in file:
        if char == '(':
            total+=1
        else:
            total-=1
        if total == -1:
            print(index)
            return
        index += 1

part_one()
part_two()