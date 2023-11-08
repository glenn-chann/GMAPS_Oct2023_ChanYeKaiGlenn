using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3];

    //creating a 3x3 matrix with all the elements as 0 
    public HMatrix2D()
    {
        for (int y = 0; y < 3; y++) //rows 
            for (int x = 0; x < 3; x++) //columns
            {
                //set the element to 0 
                Entries[x, y] = 0; 
            }
    }

    public HMatrix2D(float[,] multiArray)
    {
        if (multiArray == null)
            throw new ArgumentNullException(nameof(multiArray));

        if (multiArray.GetLength(0) != 3 || multiArray.GetLength(1) != 3)
            throw new ArgumentNullException(nameof(multiArray));

        for (int y = 0; y < 3; y++) //rows 
            for (int x = 0; x < 3; x++) //columns
            {
                Entries[x, y] = multiArray[x, y]; //setting the matrix using the values in multiArray
            }
    }

    //creating a 3x3  matrix using the values given 
    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second row
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third row
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    //overloading the + operator to add 2 HMatrix2Ds together 
    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        //create a multi dimensional array 
        float[,] add = { };
        for (int y = 0; y < 3; y++) //rows 
            for (int x = 0; x < 3; x++) //columns
            {
                add[y, x] = left.Entries[y, x] + right.Entries[y, x]; //add the elements of the left and right matrix and add it to the multi dimensional array 
            }
        //return the result of running the HMatrix2D function passing the add multi dimensional array as an argument 
        return new HMatrix2D(add);
    }

    //overloading the - operator to subtract 2 HMatrix2Ds from each other
    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        //create a multi dimensional array 
        float[,] sub = { };
        for (int y = 0; y < 3; y++) //rows 
            for (int x = 0; x < 3; x++) //columns
            {
                sub[y, x] = left.Entries[y, x] - right.Entries[y, x]; //subtract the elements of the left and right matrix and add it to the multi dimensional array 
            }
        //return the result of running the HMatrix2D function passing the add multi dimensional array as an argument 
        return new HMatrix2D(sub);
    }

    //overloading the * operator to multiply a HMatrix2D by a scalar value 
    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        //create a multi dimensional array 
        float[,] multi = { };
        for (int y = 0; y < 3; y++) //rows 
            for (int x = 0; x < 3; x++) //columns
            {
                multi[y, x] = left.Entries[y, x] * scalar; //multiply the left matrix by the scalar value and add it to the multi dimensional array 
            }
        //return the result of running the HMatrix2D function passing the multi multi dimensional array as an argument 
        return new HMatrix2D(multi);
    }

    // Note that the second argument is a HVector2D object
    //multiplying a matrix with a vector
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            //multiply the first row of the matrix by the x and y vector components and sum the products
            left.Entries[0,0] * right.x + left.Entries[0,1] * right.y,
            //multiply the second row of the matrix by the x and y vector components and sum the products
            left.Entries[1,0] * right.x + left.Entries[1,1] * right.y
        );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
            */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
            */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

            /* 
                00 01 02    xx xx 02
                xx xx xx    xx xx 12
                xx xx xx    xx xx 22
            */
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            /* 
                xx xx xx    00 xx xx
                10 11 12    10 xx xx
                xx xx xx    20 xx xx
            */
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],

            /* 
                xx xx xx    xx 01 xx
                10 11 12    xx 11 xx
                xx xx xx    xx 21 xx
            */
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],

            /* 
                xx xx xx    xx xx 02
                10 11 12    xx xx 12
                xx xx xx    xx xx 22
            */
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],

            /* 
                xx xx xx    00 xx xx
                xx xx xx    10 xx xx
                20 21 22    20 xx xx
            */
            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],

            /* 
                xx xx xx    xx 01 xx
                xx xx xx    xx 11 xx
                20 21 22    xx 21 xx
            */
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],

            /* 
                xx xx xx    xx xx 02
                xx xx xx    xx xx 12
                20 21 22    xx xx 22
            */
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
        );
    }


    //overloading the == operator to check if 2 HMatrix2Ds are equal
    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++) //rows 
            for (int x = 0; x < 3; x++) //columns
                if (left.Entries[y, x] != right.Entries[y, x]) //if any element in the left matrix is not the same as it's respective element in the right matrix 
                    return false; //return false
        return true;//return true if all elements are the same   
    }

    //overloading the != operator to check if 2 HMatrix2Ds are not equal 
    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++) //rows 
            for (int x = 0; x < 3; x++) //columns
                if (left.Entries[y, x] != right.Entries[y, x])//if any element in the left matrix is not the same as it's respective element in the right matrix 
                    return true;//return true 
        return false; //return false 
    }

    //public override bool Equals(object obj)
    //{
    //    // your code here
    //}

    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    //public HMatrix2D transpose()
    //{
    //    return // your code here
    //}

    //public float getDeterminant()
    //{
    //    return // your code here
    //}

    public void SetIdentity()
    {
        //for (int y = 0; y < 3; y++)
        //{
        //    for (int x = 0; x < 3; x++)
        //    {
        //        if (x == y)
        //        {
        //            entries[x,y] = 1;
        //        }
        //        else
        //        {
        //            entries[x,y] = 0;
        //        }
        //    }
        //}

        for (int y = 0; y<3; y++) //rows
            for(int x = 0; x<3; x++) //columns 
                Entries[y, x] = x == y ? 1 : 0; //if x is equal to y it means this element falls on the diagonal thus we set its value to 1 
    }

    public void SetTranslationMatrix(float transX, float transY)
    {
        SetIdentity();
        Entries[0, 2] = transX;
        Entries[1, 2] = transY; 
    }

    public void SetRotationMat(float rotDeg)
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;
        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = - Mathf.Sin(rad);
        Entries[1, 0] = Mathf.Sin(rad);
        Entries[1, 1] = Mathf.Cos(rad);
    }

    //public void setScalingMat(float scaleX, float scaleY)
    //{
    //    // your code here
    //}

    //printing the matrix to the console 
    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
