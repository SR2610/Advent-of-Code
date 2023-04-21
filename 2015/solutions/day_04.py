import hashlib

def bruteForceHash(length):
	file = open("../data/day_04.txt", "r").read()
	x=0
	while x < 10000000000:
		hash = hashlib.md5((file+str(x)).encode()).hexdigest()
		if(hash[:length]==(length*"0")):
			print(x)
			break
		x=x+1



bruteForceHash(5)
bruteForceHash(6)