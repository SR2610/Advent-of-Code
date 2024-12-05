import utils.io as io

def part_one():
    lines = io.read_file_lines(__file__)
    totalValue = 0
    for line in lines:
        totalValue+=getScoreFromMatches(getNumberOfMatches(line))
    return totalValue

def part_two():
    lines = io.read_file_lines(__file__,False)
    cards = []
    counts = []
    for line in lines:
        cards.append(getNumberOfMatches(line))
        counts.append(1)
    
    for x in range(len(cards)):
        for y in range(cards[x]):
            counts[x+y+1]+=counts[x]
      
    return sum(counts)


def getNumberOfMatches(line):
    matches = 0
    winningNumbers = line.split('|')[0].split(": ")[1].strip().split(" ")
    playerNumbers = " ".join(line.split('|')[1].strip().split("  ")).split(" ")
    for number in playerNumbers:
        if number in winningNumbers:
            matches=matches+1
    return matches

def getScoreFromMatches(matches):
    if(matches>0):
        return pow(2,matches-1)
    return 0

print(part_one())
print(part_two())