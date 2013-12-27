// Multiples of 3 and 5
// Problem 17
//
// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
// Find the sum of all the multiples of 3 or 5 below 1000.

#include <stdio.h>
#include <string.h>

int lettersForUnity(int u)
{
    switch(u)
    {
        case 1: // one
        case 2: // two
        case 6: // six
            return 3; 
            
        case 3: // three
        case 7: // seven
        case 8: // eight
            return 5;
            
        case 4: // four
        case 5: // five
        case 9: // nine
            return 4;
    }
    
    return 0;
}

main()
{
    int sum = 0;
    int u;
    int d;
    int h;
    int t;
    
    int i;
    for(i = 1; i <= 1000; i++)
    {
        u = i % 10;
        d = (i % 100) / 10;
        h = (i % 1000) / 100;
        t = i / 1000;
        
        if(t > 0)
        {
            sum += 11; // one thousand
        }
        
        if(h > 0)
        {
            sum += lettersForUnity(h);
            sum += 7; // hundred
        }
        
        if((t > 0 || h > 0) && (d > 0 || u > 0)) // and
        {
            sum += 3;
        }
        
        if(d < 1 || d >= 2)
        {
            if(u != 0)
            {
                sum += lettersForUnity(u);
            }

            switch(d)
            {
                case 2: // twenty
                case 3: // thirty
                case 8: // eighty
                case 9: // ninety
                    sum += 6;
                    break;
                case 4: // forty
                case 5: // fifty
                case 6: // sixty
                    sum += 5;
                    break;
                case 7: // seventy
                    sum += 7;
                    break;
            }
        }
        else
        {
           switch(u)
            {
                case 0: // ten
                    sum += 3;
                    break;
                    
                case 1: // eleven
                case 2: // twelve
                    sum += 6;
                    break;
                    
                case 3: // thirteen
                case 4: // fourteen
                case 8: // eighteen
                case 9: // nineteen
                    sum += 8;
                    break;
                    
                case 5: // fifteen
                case 6: // sixteen
                    sum += 7;
                    break;
                    
                case 7: // seventeen
                    sum += 9;
                    break;
            }
        }
    }
    
    printf("%d", sum);
}
