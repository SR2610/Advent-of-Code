
def generate_password(password):
	validPassword = False
	while(not validPassword):
		password = increment_password(password)
		validPassword = check_password(password)
	return password
	

def increment_password(password):
	
	reversed = list(password)[::-1] #reverse password
	i = 0
	for char in reversed:
		if char == 'z':
			reversed[i] = 'a'
		else:
			reversed[i] = chr(ord(char)+1)
			break
		i += 1
	password = ''.join(reversed[::-1])

	return password

def check_password(password):
	if(rule_two(password)):
		if(rule_three(password)):
			if(rule_one(password)):
				return True
	return False


#Check for consecutive
def rule_one(password):
	wasLastCharConsecutive = False
	lastChar='#'
	for char in password:
		if(ord(lastChar)+1==ord(char)):
			if(wasLastCharConsecutive):
				return True
			wasLastCharConsecutive=True
		else:
			wasLastCharConsecutive=False

		lastChar=char

	return False


#check for banned chars (i,o,l)
def rule_two(password):
	if("i" not in password):
		if("o" not in password):
			if("l" not in password):
				return True
	return False

#check for two repeating pairs
def rule_three(password):
	pairChars = set()
	lastChar=''
	for char in password:
		if(lastChar==char):
			pairChars.add(char)
			if(len(pairChars)==2):
				return True
		lastChar=char
	return False

newPassword = generate_password("hepxcrrq")
print("Part One: " + newPassword)
print("Part Two: "+generate_password(newPassword))