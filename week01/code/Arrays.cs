using System;
using System.Collections.Generic;

public static class Arrays 
{ 
    /// <summary> 
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For  
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive 
    /// integer greater than 0. 
    /// </summary> 
    /// <returns>array of doubles that are the multiples of the supplied number</returns> 
    public static double[] MultiplesOf(double number, int length) 
    { 
        // TODO Problem 1 Start 
        // Remember: Using comments in your program, write down your process for solving this problem 
        // step by step before you write the code. The plan should be clear enough that it could 
        // be implemented by another person. 

        // Plan:
        // 1. Create a new array of doubles with the specified 'length'.
        // 2. Loop from 1 up to and including 'length'. This loop will represent the multiplier for each step.
        // 3. In each iteration of the loop, calculate the multiple by multiplying 'number' by the current loop value.
        // 4. Store the calculated result in the array at the correct position. Since array indices start at 0, 
        //    the value for the first multiple (i=1) will go into index 0, the second multiple (i=2) into index 1, and so on.
        // 5. After the loop completes, return the newly created and populated array.
        
        double[] result = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            // The multiplier is (i + 1) because the loop index starts at 0.
            // 1st multiple: number * (0 + 1)
            // 2nd multiple: number * (1 + 1)
            // etc.
            result[i] = number * (i + 1);
        }

        return result; 
    } 

    /// <summary> 
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is  
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be  
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive. 
    /// 
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list. 
    /// </summary> 
    public static void RotateListRight(List<int> data, int amount) 
    { 
        // TODO Problem 2 Start 
        // Remember: Using comments in your program, write down your process for solving this problem 
        // step by step before you write the code. The plan should be clear enough that it could 
        // be implemented by another person. 

        // Plan:
        // 1. Identify the block of elements that needs to be moved from the end to the front. The size of this block is 'amount'.
        // 2. Determine the starting index of this block. This will be the total count of the list minus the 'amount'.
        // 3. Create a temporary copy of this block of elements. We can use the GetRange() method for this.
        // 4. Remove that same block of elements from the original list. The RemoveRange() method is suitable for this.
        // 5. Insert the temporarily stored block of elements at the beginning (index 0) of the original list using InsertRange().
        // The list will now be rotated as required.

        if (data == null || data.Count <= 1 || amount <= 0)
        {
            // No rotation is needed if the list is empty, has one element, or amount is zero.
            return;
        }

        // Calculate the starting index of the elements to move.
        int startIndex = data.Count - amount;

        // 1. Get a copy of the elements from the end of the list.
        List<int> elementsToMove = data.GetRange(startIndex, amount);
        
        // 2. Remove those elements from the original list.
        data.RemoveRange(startIndex, amount);
        
        // 3. Insert the copied elements at the beginning of the list.
        data.InsertRange(0, elementsToMove);
    } 
}