def part_one():
	rows, cols = (1000, 1000)
	lights = [[0 for i in range(cols)] for j in range(rows)]

	lines = open("../data/day_06.txt", "r").readlines()
	for line in lines:
		instructions = line.split()
		offset = 0 if instructions[0] == "toggle" else 1
		posOne = instructions[1+offset].split(',')
		posTwo = instructions[3+offset].split(',')
		for x in range(((int)(posOne[0])),((int)(posTwo[0])+1)):
			for y in range(((int)(posOne[1])),((int)(posTwo[1])+1)):
				if(offset==0):#TOGGLE
					lights[x][y] = abs(lights[x][y]-1)
				else:
					lights[x][y]=1 if instructions[1] == "on" else 0
	result = 0
	for x in lights:
		result+=x.count(1)

	print(result)

def part_two():
	rows, cols = (1000, 1000)
	lights = [[0 for i in range(cols)] for j in range(rows)]

	lines = open("../data/day_06.txt", "r").readlines()
	for line in lines:
		instructions = line.split()
		offset = 0 if instructions[0] == "toggle" else 1
		posOne = instructions[1+offset].split(',')
		posTwo = instructions[3+offset].split(',')
		for x in range(((int)(posOne[0])),((int)(posTwo[0])+1)):
			for y in range(((int)(posOne[1])),((int)(posTwo[1])+1)):
				if(offset==0):#TOGGLE
					lights[x][y] = lights[x][y]+2
				else:
					lights[x][y]=lights[x][y]+1 if instructions[1] == "on" else lights[x][y]-1
					lights[x][y] = 0 if lights[x][y]<0 else lights[x][y]
	result = 0
	for x in lights:
		result+=sum(x)

	print(result)

part_one()
part_two()