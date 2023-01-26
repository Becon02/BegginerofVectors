using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector3
{
    public float x, y, z;

    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static MyVector3 AddVector(MyVector3 a, MyVector3 b)
    {
        //Initialize our return valure (rv)
        MyVector3 rv = new MyVector3(0, 0, 0);

        //Add our two vectors
        rv.x = a.x + b.x;
        rv.y = a.y + b.y;
        rv.z = a.z + b.z;

        //Return the added value
        return rv;
    }

    public static MyVector3 operator +(MyVector3 lhs, MyVector3 rhs) 
    {
        return AddVector(lhs, rhs);
    }

    public static MyVector3 SubtractVector(MyVector3 a, MyVector3 b)
    {
        //Initialize our return valure (rv)
        MyVector3 rv = new MyVector3(0, 0, 0);

        //Subtract our two vectors
        rv.x = a.x - b.x;
        rv.y = a.y - b.y;
        rv.z = a.z - b.z;

        //Return the subtracted value
        return rv;
    }

    public static MyVector3 operator -(MyVector3 lhs, MyVector3 rhs)
    {
        return SubtractVector(lhs, rhs);
    }

    public static MyVector3 ScaleVector(MyVector3 a, float scalar)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = rv.x * scalar;
        rv.y = rv.y * scalar;
        rv.z = rv.z * scalar;

        return rv;
    }

    public static MyVector3 operator *(MyVector3 lhs, float rhs)
    {
        return ScaleVector(lhs, rhs);
    }

    public static MyVector3 DivideVector(MyVector3 a, float divisor)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = rv.x * divisor;
        rv.y = rv.y * divisor;
        rv.z = rv.z * divisor;

        return rv;
    }

    public static MyVector3 operator /(MyVector3 lhs, float rhs)
    {
        return DivideVector(lhs, rhs);
    }

    public MyVector3 NormalizeVector()
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = x;
        rv.y = y;
        rv.z = z;

        rv = rv / rv.Length();

        return rv;
    }

    public float Length()
    {
        float rv = 0.0f;

        rv = Mathf.Sqrt(x * x + y * y + z * z);

        return rv;
    }

    public float LengthSquare()
    {
        float rv = 0.0f;

        rv = x * x + y * y + z * z;

        return rv;
    }

    public Vector3 ToUnityVector()
    {
        Vector3 rv = new Vector3(x, y, z);

        return rv;
    }
}
