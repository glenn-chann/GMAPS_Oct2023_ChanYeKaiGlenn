using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    //overloading the + operator to add 2 Hvector2Ds together 
    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        //adding the x and y values of HVector2D a with the x and y values of HVector2D respectively and returning the results as a new HVector2D
        return new HVector2D(a.x + b.x, a.y + b.y);
    }

    //overloading the - operator to subtract 2 Hvector2Ds from each other
    public static HVector2D operator -(HVector2D a, HVector2D b)
    {
        //subtracting the x and y values of HVector2D a with the x and y values of HVector2D respectively and returning the results as a new HVector2D
        return new HVector2D(a.x - b.x, a.y - b.y);
    }

    //overloading the * operator to multiply 2 Hvector2Ds 
    public static HVector2D operator *(HVector2D a, HVector2D b)
    {
        //multiplying the x and y values of HVector2D a with the x and y values of HVector2D respectively and returning the results as a new HVector2D
        return new HVector2D(a.x * b.x, a.y * b.y);
    }

    //overloading the * operator to multiply a HVector2D by a scalar value 
    public static HVector2D operator *(HVector2D a, float b)
    {
        //multiplying the x and y values of HVector2D a with b and returning the results as a new HVector2D
        return new HVector2D(a.x * b, a.y * b);
    }

    //overloading the / operator to divide 2 HVector2Ds
    public static HVector2D operator /(HVector2D a, HVector2D b)
    {
        //divide the x and y values of HVector2D a with the x and y values of HVector2D respectively and returning the results as a new HVector2D
        return new HVector2D(a.x / b.x, a.y / b.y);
    }

    //overloading the / operator to divide a HVector2D by a scalar value 
    public static HVector2D operator /(HVector2D a, float b)
    {
        //divide the x and y values of HVector2D a with b and returning the results as a new HVector2D
        return new HVector2D(a.x / b, a.y / b);
    }

    //function to get the magnitude of a vector 
    public float Magnitude()
    {
        //get the magnitude using the pythagorean theorem, square the x and y values and square root the result to get the magnitude of the vector 
        return Mathf.Sqrt((x * x + y * y));
    }

    //function to normalise a vector
    public HVector2D Normalize()
    {
        //get the magnitude of the vector first 
        float mag = Magnitude();
        //divide both x and y values with the magnitude and return the results in a HVector2D as the normalised vector 
        return new HVector2D(x / mag, y / mag);
    }

    //function to get the DotProduct 
    public float DotProduct(HVector2D vec)
    {
        //multiply the x and y values of both Vectors then add the 2 values together to get the dotproduct
        return (x * vec.x + y * vec.y);
    }

    //function to get the smallest angle between 2 vectors 
    public float FindAngle(HVector2D vec)
    {
        // Calculate the arccosine of the dot product divided by the magnitudes multiplied together which gives the angle in radians and return the results as a float 
        return (float)Mathf.Acos(DotProduct(vec)/(Magnitude()* vec.Magnitude()));
    }

    //changes HVector2D class into unity's Vector2 class
    public Vector2 ToUnityVector2()
    {
        return new Vector2(x, y);
    }

    //changes HVector2D class into unity's Vector3 class
    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, 0);
    }

    //printing vector to console
    public void Print()
    { 
        Debug.Log(x + " " + y);
    }
}
