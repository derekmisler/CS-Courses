/**
 * vigenere.c
 *
 * Derek Misler
 * derekmisler@gmail.com
 *
 * encrypts a message using Vigenère's cipher
 *
 */
#include <cs50.h>
#include <ctype.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>

int alphaCheck(string argv[]);
string lowerKey(string k);
void cipher(string k);

int main(int argc, string argv[])
{
    if (argc != 2 || alphaCheck(argv) == 2)
    {
        printf("%s", "No!\n");
        return 1;
    }
    else
    {
        string k = argv[1];
        lowerKey(k);
        cipher(k);
        return 0;
    }

}


/*making sure the key is only letters*/

int alphaCheck(string argv[])
{
    for (int letter = 0, p = strlen(argv[1]); letter < p; letter++)
    {
        if (!isalpha(argv[1][letter]))
        {
            return 2;
        }
    }
    return 0;
}


/* 'A' and 'a' have the same values, so make the key all lowercase*/

string lowerKey(string k)
{
    for (int letter = 0, p = strlen(k); letter < p; letter++)
    {
        k[letter] = tolower(k[letter]);
    }
    return k;
}

/*translate the letters of the message*/

void cipher(string k)
{
    string mess = GetString();
    int kLen = 0;
    for (int i = 0, y = strlen(mess); i < y; i++)
    {
        kLen = kLen % strlen(k);
        if (isalpha(mess[i]))
        {
            if (isupper(mess[i]))
            {
                char encrypt = (((mess[i] - 'A') + (k[kLen] - 'a')) % 26) + 'A';
                printf("%c", encrypt);
                kLen++;
            }
            else
            {
                char encrypt = (((mess[i] - 'a') + (k[kLen] - 'a')) % 26) + 'a';
                printf("%c", encrypt);
                kLen++;
            }
        }
        else
        {
            printf("%c", mess[i]);
        }
    }
    printf("\n");
}
