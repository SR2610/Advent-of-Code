import utils.io as io


replaceDictionary = {
    'one': 'o1ne',
    'two': 't2wo',
    'three': 't3hree',
    'four': 'f4our',
    'five': 'f5ive',
    'six': 's6ix',
    'seven': 's7even',
    'eight': 'e8ight',
    'nine': 'n9ine'
}


def part_one():
    lines = io.read_file_lines(__file__)
    return sumNumbers(lines)

def part_two():
    lines = io.read_file_lines(__file__)
    newLines = []
    for line in lines:
        newLines.append(replaceWordsWithNumbers(line))

    return sumNumbers(newLines)


def replaceWordsWithNumbers(line):
    for key in replaceDictionary :
        line = line.replace(key, replaceDictionary[key])
    return line


def sumNumbers(lines):
    sum=0
    for line in lines:
        firstDigit = "X"
        lastDigit="X"
        for char in line:
            if(char.isnumeric()):
                if(firstDigit =="X"):
                    firstDigit = char
                lastDigit = char
        sum = sum + int(firstDigit+lastDigit)
    return sum

print(part_one())
print(part_two())