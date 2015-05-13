/**
 * greedy.c
 *
 * Derek Misler
 * derekmisler@gmail.com
 *
 * asks the user how much changes is owed
 * then spits out the minimum number of coins with which said change can be made
 * using only quarters, dimes, nickels, and pennies
 *
 */
#include <cs50.h>
#include <stdio.h>
#include <math.h>
int main(void)
{
    float money = 0;
    int coins = 0;
    int moneyLeft = 0;
    do
    {
        printf("How much changes is owed?\n");
        money = GetFloat();
    }while(money < 0);
    
    moneyLeft = (int) round(money * 100);
    while (moneyLeft >= 25)
    {
        coins++;
        moneyLeft -= 25;
    }
    while (moneyLeft >= 10)
    {
        coins++;
        moneyLeft -= 10;
    }
    while (moneyLeft >= 5)
    {
        coins++;
        moneyLeft -= 5;
    }
    while (moneyLeft >= 1)
    {
        coins++;
        moneyLeft -= 1;
    }
    
    printf("%i\n", coins);
}
