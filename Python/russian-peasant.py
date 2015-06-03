## Input two numbers
## Output the solution to those two numbers using
## the Russian Peasant Algorithm

import time

CACHE = {}

def russia(a,b):
	x = a
	y = b
	z = 0
	while x > 0:
		if x % 2 == 1:      ## find every odd number
			z += y          ## add the partner number to z
		y = y << 1          ## shift binary by 1 is like multiplying by 2
		x = x >> 1          ## this one is dividing by 2
	return z

def test_russia():
	assert russia(357,16) == 5712		## test the algorithm

	start_time = time.time()			## time the algorithm
	print russia(357,16)
	print "Russian Algorithm took %f seconds" % (time.time()-start_time)

test_russia()
