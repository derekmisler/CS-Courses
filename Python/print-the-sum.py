def forLoop(numList):
	theSum = 0
	for i in numList:
		theSum = theSum + i
	return theSum

def recursive(numList):
	if len(numList) == 1:
		return numList[0]
	else:
		return numList[0] + recursive(numList[1:])

def whileLoop(numList):
	theSum = 0
	i = 0
	while len(numList) > i:
		theSum += numList[i]
		i += 1
	return theSum








print(forLoop([1,3,5,7,9]))
print(recursive([1,3,5,7,9]))
print(whileLoop([1,3,5,7,9]))
