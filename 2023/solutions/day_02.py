import utils.io as io

def part_one():
    lines = io.read_file_lines(__file__)
    sum = 0
    gameID = 0
    for line in lines:
        gameID = gameID+1
        if checkIfValidGame(line,12,13,14):
            sum += gameID        
        
    return sum


def checkIfValidGame(line,maxRed,maxGreen,maxBlue):
    splitLine = line.split(" ")
    buffer = 0
    for part in splitLine:
        if part.isnumeric() :
            buffer = int(part)
        else:
            if(part[0]=='r'):
                if buffer>maxRed:
                    return False
            if(part[0]=='g'):
                if buffer>maxGreen:
                    return False
            if(part[0]=='b'):
                if buffer>maxBlue:
                    return False
            buffer = 0  
    return True



def getRequiredCubesPower(line):
    splitLine = line.split(" ")
    buffer = 0
    maxRed=0
    maxBlue=0
    maxGreen=0
    for part in splitLine:
        if part.isnumeric() :
            buffer = int(part)
        else:
            if(part[0]=='r'):
                if buffer>maxRed:
                    maxRed=buffer
            if(part[0]=='g'):
                if buffer>maxGreen:
                    maxGreen=buffer
            if(part[0]=='b'):
                if buffer>maxBlue:
                    maxBlue=buffer
            buffer = 0  
    return maxGreen*maxRed*maxBlue

def part_two():
    lines = io.read_file_lines(__file__)
    sum = 0
    for line in lines:
        sum += getRequiredCubesPower(line)        
    return sum

print(part_one())
print(part_two())