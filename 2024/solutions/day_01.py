import utils.io as io

def part_one():
    lines = io.read_file_lines(__file__)
    left = []
    right = []
    for line in lines:
        split = line.split()
        left.append(int(split[0]))
        right.append(int(split[1]))
    left.sort()
    right.sort()
    index = 0
    sum = 0
    for x in left:
        sum+=abs(x-right[index])
        index+=1
    print(sum)
    return

def part_two():
    lines = io.read_file_lines(__file__)
    left = []
    right = []
    for line in lines:
        split = line.split()
        left.append(int(split[0]))
        right.append(int(split[1]))
    sum = 0
    for x in left:
        count = 0
        for y in right:
            if(x == y):
                count+=1
        sum+=(count*x)
    print(sum)
    return

part_one()
part_two()