def part_one():
    total =0
    lines = open("../data/day_02.txt", "r").readlines()
    for line in lines:
        dimensions = list(map(int,line.split("x")))
        lw = dimensions[0]*dimensions[1]  
        wh = dimensions[1]*dimensions[2]     
        hl = dimensions[2]*dimensions[0]
        total += (2*lw)+(2*wh)+(2*hl)+min(lw,wh,hl)
    print(total)

def part_two():
    total =0
    lines = open("../data/day_02.txt", "r").readlines()
    for line in lines:
        dimensions = list(map(int,line.split("x")))
        total+=dimensions[0]*dimensions[1]*dimensions[2]
        dimensions.sort()
        total+=(dimensions[0]*2+dimensions[1]*2)
    print(total)

part_one()
part_two()