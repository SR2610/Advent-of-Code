vowels = ['a','e','i','o','u']
bannedCombos = ["ab","cd","pq","xy"]
def part_one():
	result = 0
	lines = open("../data/day_05.txt", "r").readlines()
	for line in lines:
		lastChar = '#'
		numVowels = 0
		hasRepeating = False
		hasBanned = False
		for letter in line:
			if(lastChar==letter):
				hasRepeating=True
								
			if(vowels.count(letter)>0):
				numVowels=numVowels+1
								
			if((bannedCombos.count(lastChar+letter)>0)):
					hasBanned=True
			
			lastChar=letter
		if(numVowels>=3 and hasRepeating and not hasBanned):
			result=result+1
			

	print(result)

def part_two():
	result = 0
	lines = open("../data/day_05.txt", "r").readlines()
	for line in lines:
		pairs = []
		twoBack = '#'
		lastChar = '#'
		lastPair=""
		hasPair = False
		hasTwoBack = False
		for letter in line:
			if lastChar != '#':
				pair = lastChar+letter
				if(pairs.count(pair)>0):
					hasPair=True
				pairs.append(lastPair)
				lastPair=pair
			if(letter == twoBack):
				hasTwoBack=True
			twoBack = lastChar
			lastChar=letter
		if(hasTwoBack and hasPair):
			result = result+1
	print(result)

	
part_one()
part_two()