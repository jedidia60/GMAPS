using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    HMatrix2D mat1;
    HMatrix2D mat2;
    HVector2D vec1;

    // Start is called before the first frame update
    void Start()
    {
        Question2();
    }

    void Question2()
    {
        mat1 = new HMatrix2D(new float[3, 3] { { 1, 2, 1 }, { 0, 1, 0 }, { 2, 3, 4 } });
        mat2 = new HMatrix2D(new float[3, 2] { { 2, 5 }, { 6, 7 }, { 1, 8 } });
        HMatrix2D resultMat = mat1 * mat2;
        resultMat.Print();
    }
}
