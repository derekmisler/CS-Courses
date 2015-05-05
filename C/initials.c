/**
 * initials.c
 *
 * Derek Misler
 * derekmisler@gmail.com
 *
 * prompts user for their name
 * outputs initials in uppercase
 *
 */
#include <cs50.h>
#include <ctype.h>
#include <string.h>
#include <stdio.h>

int main(void)
{
    string name;
    do
    {
        name = GetString();
    }
    while (strlen(name) <= 0);
    
    printf("%c", toupper(name[0]));
    for (int i = 0, characters = strlen(name); i < characters; i++)
    {

        if (name[i] == ' ')
        {
            printf("%c", toupper(name[i + 1]));
        }
    }
    printf("\n");
}
