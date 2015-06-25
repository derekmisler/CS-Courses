/**
 * helpers.c
 *
 * Computer Science 50
 * Problem Set 3
 *
 * Helper functions for Problem Set 3.
 */
       
#include <cs50.h>
#include <stdio.h>
#include <stdlib.h>

#include "helpers.h"

/**
 * Returns true if value is in array of n values, else false.
 */
bool search(int value, int values[], int n)
{
    if (n <= 0)
        return false;
    else
    {
        sort(values, n);
        int min = 0;
        int max = n-1;
        
        while (max >= min)
        {
            int middle = (min + max)/2;
            
            if (max == min)
            {
                if (value == values[n-1])
                    return true;
            }
            
            if (value == values[middle])
                return true;
            else if (value < values[middle])
                max = middle - 1;
            else
                min = middle + 1;
        }
    }
    return false;
}

/**
 * Sorts array of n values.
 */
void sort(int values[], int n)
{
    // exit the loop if "swapped" ever becomes false
    bool swapped = true;
    
    // this loop does the sorting.
    // change 'swapped' to false, unless the 'if' is true,
    // if it's true, swap it and set 'swapped' to true
    while (swapped == true)
    {
        swapped = false;
        int hold;
        for (int i = 0; i < n; i++)
        {
            if (values[i] > values[i+1])
            {
                hold = values[i+1];
                values[i+1] = values[i];
                values[i] = hold;
                swapped = true;
            }
        }
    }
    return;
}
