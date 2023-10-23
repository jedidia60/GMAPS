using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    // Create a HVector2D variable using x and y in as their arguments
    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    // Set the x, y value of the HVector2D variable using Vector2
    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    // Default values of the HVector2D construct
    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    // Add the x and y values of 2 different HVector2D variables
    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        HVector2D c = new HVector2D(a.x + b.x, a.y + b.y);
        return c;
    }

    // Subtract the x and y values of 2 different HVector2D variables
    public static HVector2D operator -(HVector2D a, HVector2D b)
    {
        HVector2D c = new HVector2D(a.x - b.x, a.y - b.y);
        return c;
    }

    // Increase the magnitude of a HVector2D variable
    public static HVector2D operator *(HVector2D a, float b)
    {
        HVector2D c = new HVector2D(a.x * b, a.y * b);
        return c;
    }

    // Decrease the magnitude of a HVector2D variable
    public static HVector2D operator /(HVector2D a, float b)
    {
        HVector2D c = new HVector2D(a.x / b, a.y / b);
        return c;
    }

    // Calculate the magnitude of a HVector2D variable
    public float Magnitude()
    {
        float magnitude = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        return magnitude;
    }

    public void Normalize()
    {
        float length = Magnitude();
        x /= length;
        y /= length;
    }

    public float DotProduct(HVector2D b)
    {
        float c = x * b.x + y * b.y;
        return c;
    }

    public HVector2D Projection(HVector2D b)
    {
        HVector2D c = b * (DotProduct(b) / b.DotProduct(b));
        return c;
    }

    public float FindAngle(HVector2D b)
    {
        float c = Mathf.Acos(DotProduct(b) / (Magnitude() * b.Magnitude()));
        return c * Mathf.Rad2Deg;
    }

    // Convert a HVector2D to a Vector2
    public Vector2 ToUnityVector2()
    {
        return new Vector2(x, y);
    }

    // Convert a HVector2D to a Vector3
    public Vector3 ToUnityVector3()
    {
        return new Vector2(x, y);
    }

    // public void Print()
    // {

    // }
}
