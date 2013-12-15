// Multiples of 3 and 5
// Problem 1
//
// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
// Find the sum of all the multiples of 3 or 5 below 1000.

#include <stdio.h>
#include <string.h>

main()
{
    int limit = 1000;
    int n3 = 1000 / 3;
    int n5 = (1000 / 5) - 1;
    int n15 = (1000 / 15);
    
    int sum = ((3 + (3 * n3)) * n3) / 2;
    sum += ((5 + (5 * n5)) * n5) / 2;
    sum -= ((15 + (15 * n15)) * n15) / 2;
   
    printf("%d", sum);
}
