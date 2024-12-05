import utils.io as io

def part_one():
	lines = io.read_file_lines(__file__)
	width = len(lines[0].strip())
	height = len(lines)
	map = [["." for i in range(width)] for j in range(height)]
	for y in range(height):
		for x in range(width):
			map[y][x] = lines[y][x]

	
	partsSum = 0
	for y in range(height):
		currentNumber = ""
		for x in range(width):
			current = map[y][x]
			if(current.isnumeric()):
				currentNumber+=current        
			elif currentNumber!="":
				#end of number, check surroundings
				if(isTouchingSymbol(map,x-len(currentNumber),x-1,y,width,height)):
					partsSum+=int(currentNumber)
				else:
					print(str(currentNumber) + " - NO")
				currentNumber=""
				continue

	return partsSum

def isTouchingSymbol(map,startX,endX,startY,width,height):

	minX = startX-1 if startX>0 else startX
	minY = startY-1 if startY>0 else startY
	maxX = endX+1 if endX+1<width else endX
	maxY = startY+1 if startY+1<height else startY

	#print(str(minX)+","+str(maxX)+","+str(minY)+","+str(maxY))

	for y in range(minY,maxY+1):
		for x in range(minX,maxX+1):
			if isSymbol(map[y][x]):
				return True

	return False


def isSymbol(char):
	if(char!='.' and not char.isnumeric()):
		return True
	return False

def part_two():
	#print(io.read_file(__file__))
	return

print(part_one())
part_two()