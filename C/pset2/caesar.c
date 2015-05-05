/**
 * caesar.c
 *
 * Derek Misler
 * derekmisler@gmail.com
 *
 * encrypts a message using Caesar's cipher
 *
 */
#include <cs50.h>
#include <ctype.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>

int main(int argc, string argv[])
{
    if (argc == 2)
    {
        int k = atoi(argv[1]);
        string p = GetString();
        for (int i = 0, n = strlen(p); i < n; i++) 
        {
            if (isalpha(p[i]))
            {
                if (isupper(p[i]))
                {
                    printf("%c",((p[i] - 'A' + k) % 26) + 'A');
                }
                if (islower(p[i]))
                {
                    printf("%c",((p[i] - 'a' + k) % 26) + 'a');
                }
            }
            else
            {
                printf("%c", p[i]);
            }
        }
        printf("\n");
        return 0;
    }
    else
    {
        printf("%s", "No!\n");
        return 1;
    }

}
