#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int circularOrderedArraySearch(int number, int array[], int size);
int *generateCircularSortedArray(int size, int offset);

int iterations = 0;

int main()
{
    int array1[] = {6, 7, 1, 2, 3, 4, 5};
    int array2[] = {5, 1, 2, 3, 4};
    int array3[] = {1, 2, 3, 4, 5, 6, 7, 10, 12, 13};
    int array5[] = {6, 7, 8, 9, 1, 2, 3, 4, 5 };

    int *array4 = generateCircularSortedArray(10000, 245);

    circularOrderedArraySearch(10, array1, 7);
    circularOrderedArraySearch(7, array1, 7);
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
int circularOrderedArraySearch(int number, int arr[], int size)
{
    iterations++;

    int last = (size - 1);
    int middle = last / 2;
    int firstHalfSize = middle + 1;
    int secondHalfSize = last - middle;

    if(arr[0] == number)
    {
        printf("Found %d in array\n", number);

        return 1;
    }

    if(size == 1)
    {
        printf("Didn't find %d in array\n", number);

        return 0;
    }

    if(arr[0] <= arr[middle] && number >= arr[0] && number <= arr[middle])
    {
        return circularOrderedArraySearch(number, arr, firstHalfSize);
    }
    else if(arr[middle] <= arr[last] && number >= arr[firstHalfSize] && number <= arr[last])
    {
        return circularOrderedArraySearch(number, &arr[firstHalfSize], secondHalfSize);
    }
    else
    {
        if(arr[0] > arr[middle])
        {
            return circularOrderedArraySearch(number, arr, firstHalfSize);
        }
        else if(arr[middle] > arr[last])
        {
            return circularOrderedArraySearch(number, &arr[firstHalfSize], secondHalfSize);
        }
        else
        {
            printf("Didn't find %d in array\n", number);

            return 0;
        }
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