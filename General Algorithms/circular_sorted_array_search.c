#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int circularOrderedArraySearch(int number, int array[], int size);
int *generateCircularSortedArray(int size, int offset);

main()
{
    int array[] = {6, 7, 1, 2, 3, 4, 5};
    int array2[] = {5, 1, 2, 3, 4};
    int array3[] = {1, 2, 3, 4, 5, 6, 7, 10, 12, 13};

    int *array4 = generateCircularSortedArray(10000, 245);

    circularOrderedArraySearch(10, array, 7);
    circularOrderedArraySearch(7, array, 7);
    circularOrderedArraySearch(5, array2, 5);
    circularOrderedArraySearch(10, array3, 10);
    circularOrderedArraySearch(11, array3, 10);
    circularOrderedArraySearch(2, array3, 10);
    circularOrderedArraySearch(8, array3, 10);
    circularOrderedArraySearch(123, array4, 10000);
    circularOrderedArraySearch(1453, array4, 10000);

    free(array4);
}

// Recursive binary search in circular ascending order array
int circularOrderedArraySearch(int number, int array[], int size)
{
    printf("- ");

    int last = (size - 1); // last index of array
    int middle = last / 2; // middle index of array
    int halfSize = size / 2; // half the size of array

    if(array[middle] == number) // check if middle index is searched number
    {
        printf("Found %d in array\n", number);

        return 1;
    }

    if(size == 1) // check if there is only 1 element in array
    {
        printf("Didn't find %d in array\n", number);

        return 0;
    }

    if(array[middle] < array[0]) // check if right half of array is ordered
    {
        if(number >= array[middle + 1] && number <= array[last]) // check if number is contained in right half of array
        {
            return circularOrderedArraySearch(number, &array[middle + 1], halfSize); // search for number recursively in right half of array, in this case a normal binary search
        }
        else
        {
            return circularOrderedArraySearch(number, array, middle); // search for number recursively in left half of array
        }
    }

    if(array[last] < array[middle])// check if left half of array is ordered
    {
        if(number >= array[0] && number <= array[middle])// check if number is contained in left half of array
        {
            return circularOrderedArraySearch(number, array, middle); // search for number recursively in left half of array, in this case a normal binary search
        }
        else
        {
            return circularOrderedArraySearch(number, &array[middle + 1], halfSize); // search for number recursively in right half of array
        }
    }

    if(number >= array[0] && number <= array[last]) // if number is in array, normal binary search
    {
        if(array[middle] > number)
        {
            return circularOrderedArraySearch(number, array, middle);
        }
        else
        {
            return circularOrderedArraySearch(number, &array[middle + 1], halfSize);
        }
    }
    else
    {
        printf("Didn't find %d in array\n", number);

        return 0;
    }

    return 0;
}

int *generateCircularSortedArray(int size, int offset)
{
    int *array = (int *)malloc(size * sizeof(int));

    int i;
    for(i = 0; i < size; i++)
    {
        array[i] = (i + offset) % size;
    }

    return array;
}