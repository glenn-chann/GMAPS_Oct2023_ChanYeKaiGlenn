using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();
    private HMatrix2D mat1, mat2, resultMat;
    private HVector2D vec1, resultVec;
    // Start is called before the first frame update
    void Start()
    {
        //mat.setIdentity();
        //mat.Print();

        Question2();
    }

    void Question2()
    {
        mat1 = new HMatrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
        mat2 = new HMatrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
        vec1 = new HVector2D(20, 20);

        resultMat = mat1 * mat2;

        resultVec = mat1 * vec1;

        resultVec.Print();
        resultMat.Print();
    }
  
}
