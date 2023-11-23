using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    //function to find the distance between 2 position vectors
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        //return the magnitude of vector p1 - p2 to get the distance between the 2 vectors. 
        return (p1 - p2).Magnitude() ;
    }
}
