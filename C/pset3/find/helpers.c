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
    if (n < 0)
        return false;
    else
    {
        for (int i = 0; i <= n; i++)
        {
            if (value == values[i])
            {
                return true;
            }
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
    
    // this loop sorts. if nothing gets swapped, change it to 'false' and move to the next one
    while (swapped == true)
    {
        swapped = false;
        int hold;
        for (int i = 0; i < (n-1); i++)
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
