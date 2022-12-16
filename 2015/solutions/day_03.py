def deliver_presents(twoSanta):
    pos = [(0,0),(0,0)]
    visited = {pos[0]}
    file = open("../data/day_03.txt", "r").read()
    santa = 0
    for char in file:
        match char:
            case '^':
                pos[santa] = (pos[santa][0],pos[santa][1]+1)
            case 'v':
                pos[santa] = (pos[santa][0],pos[santa][1]-1)
            case '>':
                pos[santa] = (pos[santa][0]+1,pos[santa][1])
            case '<':
                pos[santa] = (pos[santa][0]-1,pos[santa][1])
        visited.add(pos[santa])
        if twoSanta:
            santa = 1-santa
    print(len(visited))

deliver_presents(False)
deliver_presents(True)      
