#include <stdio.h>
#include <string.h>
#include <stdlib.h>

void print_array(int *array, int size)
{
    printf("{ ");
    
    int i;
    for(i = 0; i < size; i++)
    {
        printf("%d ", array[i]);
    }
    
    printf("}");
}

int oddFirstHalf(int size)
{
    return ((size % 2) > 0) ? (size / 2) + 1 : size / 2;
}

int *merge(int *array_a, int *array_b, int size_a, int size_b)
{
    int totalSize = size_a + size_b;
    int *new_array = (int *)malloc(sizeof(int) * totalSize);
    
    int i;
    int ia = 0;
    int ib = 0;
    for(i = 0; i < totalSize; i++)
    {
        if(!(ib < size_b) || (array_a[ia] > array_b[ib]))
        {
            new_array[i] = array_a[ia];
            ia++;
        }
        else
        {
            new_array[i] = array_b[ib];
            ib++;
        }
    }
    
    return new_array;
}

int *sort(int *array, int size)
{
    if(size < 2)
    {
        int *new_array = (int *)malloc(sizeof(int));
        new_array[0] = array[0];
        
        return new_array;
    }
    else
    {
        return merge(sort(array, oddFirstHalf(size)), sort(&array[oddFirstHalf(size)], size / 2), oddFirstHalf(size), size / 2);
    }
    
    return array;
}

int *merge_sort(int *array, int size)
{
    return merge(sort(array, oddFirstHalf(size)), sort(&array[oddFirstHalf(size)], size / 2), oddFirstHalf(size), size / 2);
}

main()
{
    int array[18] = {5, 24, 3, 6, 6, 9, 35, 5, 23, 3, 3, 5, 3, 4, 7, 8, 8, 10};
    
    print_array(merge_sort(array, 18), 18);
}