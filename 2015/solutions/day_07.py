calc = dict()
results = dict()

def part_one():
	commands = open("../data/day_07.txt", "r").readlines()
	for command in commands:
		(ops, res) = command.split('->')
		calc[res.strip()] = ops.strip().split(' ')

def part_two():
	part_one()
	a = calculate('a')
	calc.clear()
	results.clear()
	results['b']=a
	commands = open("../data/day_07.txt", "r").readlines()
	for command in commands:
		(ops, res) = command.split('->')
		calc[res.strip()] = ops.strip().split(' ')


def calculate(name):
	try:
		return int(name)
	except ValueError:
		pass

	if name not in results:
		ops = calc[name]
		if len(ops) == 1:
			res = calculate(ops[0])
		else:
			op = ops[-2]
			if op == 'AND':
				res = calculate(ops[0]) & calculate(ops[2])
			elif op == 'OR':
				res = calculate(ops[0]) | calculate(ops[2])
			elif op == 'NOT':
				res = ~calculate(ops[1]) & 0xffff
			elif op == 'RSHIFT':
				res = calculate(ops[0]) >> calculate(ops[2])
			elif op == 'LSHIFT':
				res = calculate(ops[0]) << calculate(ops[2])
		results[name] = res
	return results[name]

part_one()
print("a: %d" % calculate('a'))

part_two()
print("a: %d" % calculate('a'))