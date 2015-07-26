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
            
            if (values[middle] == value)
                return true;
            else if (values[middle] > value)
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
    bool swapped;
    
    // this loop does the sorting.
    // change 'swapped' to false, unless the 'if' is true,
    // if it's true, swap it and set 'swapped' to true
    do
    {
      swapped = false;
      for (int i = 0; i < n-1; i++)
      {
          if (values[i] > values[i+1])
          {
              int hold = values[i];
              values[i] = values[i+1];
              values[i+1] = hold;
              swapped = true;
          }
      }
    } while (swapped);
    return;
}
