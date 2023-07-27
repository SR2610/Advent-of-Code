from itertools import permutations
import sys

def solve():
	places = set()
	distances = dict()
	routes = open("../data/day_09.txt", "r").readlines()
	for route in routes:
		(start, _, end, _, distance) = route.split()
		places.add(start)
		places.add(end)
		distances.setdefault(start, dict())[end] = int(distance)
		distances.setdefault(end, dict())[start] = int(distance)
	shortest = sys.maxsize
	longest = 0
	for perm in permutations(distances):
		dist = sum(map(lambda x, y: distances[x][y], perm[:-1], perm[1:]))
		if(dist<shortest):
			shortest=dist
		if(dist>longest):
			longest = dist
	print(shortest)
	print(longest)




solve()