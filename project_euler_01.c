// Multiples of 3 and 5
// Problem 1
//
// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
// Find the sum of all the multiples of 3 or 5 below 1000.

#include <stdio.h>
#include <string.h>

main()
{
	int sum;
	int i;
	int iterations = 1000 / 3;

	for(i = 1; i <= iterations; i++)
	{
		sum += i * 3;
		
		int m5 = i * 5;
		if(m5 < 1000 && m5 % 3 != 0)
		{
			sum += m5;
		}
	}
	
	printf("%d", sum);
}
