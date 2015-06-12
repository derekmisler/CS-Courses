# The Question:
# "Given 2 sorted lists of integers, can you merge them into one sorted list? Try to do this as optimally as possible."

def mergeLists(list1, list2):
	output = []								# defining an empty list as output
	while list1 and list2:					# keep looping while both of the lists contain something
		if (list1[0] < list2[0]):			# check the number at the beginning of both lists, remove the smaller, and append that item onto the output list
			output.append(list1.pop(0))		# since the two lists are already sorted, just keep moving the smaller item to the output list
		else:
			output.append(list2.pop(0))

	if (len(list1) != 0):					# since the lists are already sorted, if one of the lists isn't empty yet, just append it at the end of the output list
		output.extend(list1)
	elif (len(list2) != 0):
		output.extend(list2)

	return output
