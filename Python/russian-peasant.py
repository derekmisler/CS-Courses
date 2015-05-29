## Input two numbers
## Output the solution to those two numbers using
## the Russian Peasant Algorithm

def russia(a,b):
    x = a
    y = b
    z = 0
    while x > 0:
        if x % 2 == 1:      ## find every odd number
            z += y          ## add the partner number to z
        y = y << 1          ## shift binary is like multiplying by 2
        x = x >> 1          ## this one is dividing by 2
    return z

print russia(24,16)
