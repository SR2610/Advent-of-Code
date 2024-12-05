from pathlib import Path
def read_file(file, isTest = False):
	day = Path(file).stem
	pathModifier = "test/" if isTest else ""
	data = open("./data/"+ pathModifier +day+".txt", "r").read()
	return data


def read_file_lines(file, isTest = False):
	day = Path(file).stem
	pathModifier = "test/" if isTest else ""
	lines = open("./data/"+ pathModifier +day+".txt", "r").readlines()
	return lines