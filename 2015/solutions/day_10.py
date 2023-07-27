def solve(starting, iterations):
	current = starting
	for i in range(iterations):
		newString = ""
		currentChar = ""
		count = 0
		for char in current:
			if(char==currentChar):
				count+=1
			else:
				if(count>0):
					newString+=str(count)
					newString+=currentChar
				currentChar=char
				count=1
		newString+=str(count)
		newString+=currentChar
		current=newString
	print(len(current))

solve("1321131112",40)
solve("1321131112",50)