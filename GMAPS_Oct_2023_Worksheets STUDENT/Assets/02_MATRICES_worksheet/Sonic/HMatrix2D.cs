using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        entries = new float[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int row = 0; row < multiArray.GetLength(0); row++)
            for (int col = 0; col < multiArray.GetLength(1); col++)
                entries[row, col] = multiArray[row, col];
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;

        // Second row
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;

        // Third row
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D addition = new HMatrix2D();
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                addition.entries[row, col] = left.entries[row, col] + right.entries[row, col];

        return addition;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D subtraction = new HMatrix2D();
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                subtraction.entries[row, col] = left.entries[row, col] + right.entries[row, col];

        return subtraction;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D multiplication = new HMatrix2D();
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                multiplication.entries[row, col] = left.entries[row, col] * scalar;

        return multiplication;
    }

    // Note that the second argument is a HVector2D object
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.entries[0, 0] * right.x + left.entries[0, 1] * right.y,
            left.entries[1, 0] * right.x + left.entries[1, 1] * right.y
        );
    }

    // Note that the second argument is a HMatrix2D object
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D(new float[left.entries.GetLength(0), right.entries.GetLength(1)]);
        for (int mat1Row = 0; mat1Row < left.entries.GetLength(0); mat1Row++)
            for (int mat2Col = 0; mat2Col < right.entries.GetLength(1); mat2Col++)
            {
                result.entries[mat1Row, mat2Col] = 0;
                for (int insideNum = 0; insideNum < left.entries.GetLength(1); insideNum++)
                {
                    result.entries[mat1Row, mat2Col] += left.entries[mat1Row, insideNum] * right.entries[insideNum, mat2Col];
                }
            }
        return result;
        /* 
            00 01 02    00 xx xx
            xx xx xx    10 xx xx
            xx xx xx    20 xx xx
            */
        //left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

        /* 
            00 01 02    xx 01 xx
            xx xx xx    xx 11 xx
            xx xx xx    xx 21 xx
            */
        //left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

        // and so on for another 7 entries
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                if (left.entries[row, col] != right.entries[row, col])
                    return false;
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                if (left.entries[row, col] != right.entries[row, col])
                    return true;
        return false;
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

    public void setIdentity()
    {
        //for (int y = 0; y < 3; y++)
        //{
        //    for (int x = 0; x < 3; x++)
        //    {
        //        if (x == y)
        //        {
        //            entries[y, x] = 1;
        //        }
        //        else
        //        {
        //            entries[y, x] = 0;
        //        }
        //    }
        //}
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                entries[y, x] = x == y ? 1 : 0;
    }

    //public void setTranslationMat(float transX, float transY)
    //{
    //    // your code here
    //}

    public void setRotationMat(float rotDeg)
    {
        setIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;
        entries[0, 0] = entries[0, 0] * Mathf.Cos(rad) - entries[0, 1] * Mathf.Sin(rad);
        entries[1, 1] = entries[0, 0] * Mathf.Sin(rad) + entries[1, 1] * Mathf.Cos(rad);

    }

    //public void setScalingMat(float scaleX, float scaleY)
    //{
    //    // your code here
    //}

    public void Print()
    {
        string result = "";
        for (int r = 0; r < entries.GetLength(0); r++)
        {
            for (int c = 0; c < entries.GetLength(1); c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}