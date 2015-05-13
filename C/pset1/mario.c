/**
 * mario.c
 *
 * Derek Misler
 * derekmisler@gmail.com
 *
 * requests an integer between 1 and 23 from the user
 * generates a half-pyramid with that integer as the height
 *
 */
#include <cs50.h>
#include <stdio.h>

int main(void)
{
    int height;
    int space;
    int column;
    do
    {
        printf("height: ");
        height = GetInt();
    }
    while (height > 23 || height < 0);

    for (int i = 0; i < height; i++)
    {
        space = height - i;
        while (space > 1)
        {
            printf(" ");
            space--;
        }
        column = 0;
        while (column < i + 1)
        {
            printf("#");
            column++;
        }          
        printf("#\n");
    }
}
