def part_one():
	strings = open("../data/day_08.txt", "r").readlines()
	isEscaped = False
	toSkip = 0
	totalChars = 0
	countedChars = 0
	for string in strings:
		for char in string.strip():
			totalChars = totalChars+1
			if(toSkip>0):
				toSkip-=1
				continue
			if(isEscaped):
				isEscaped=False
				if(char=="\\" or char=="\""):
					countedChars+=1
					continue
				if(char=="x"):
					countedChars+=1
					toSkip=2
					continue
			if(char == "\\"):
				isEscaped = True
			else:
				countedChars+=1
		countedChars = countedChars - 2
	print(totalChars-countedChars)


def part_two():
	strings = open("../data/day_08.txt", "r").readlines()
	totalChars = 0
	countedChars = 0
	for string in strings:
		countedChars+=2
		for char in string.strip():
			totalChars+=1
			countedChars+=1
			if(char=="\\" or char=="\""):
				countedChars+=1
			
	print(countedChars-totalChars)

part_one()
part_two()