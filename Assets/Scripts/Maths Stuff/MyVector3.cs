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
        //Initialize our return value (rv)
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

        rv.x = a.x * scalar;
        rv.y = a.y * scalar;
        rv.z = a.z * scalar;

        return rv;
    }

    public static MyVector3 operator *(MyVector3 lhs, float rhs)
    {
        return ScaleVector(lhs, rhs);
    }

    public static MyVector3 DivideVector(MyVector3 a, float divisor)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = a.x / divisor;
        rv.y = a.y / divisor;
        rv.z = a.z / divisor;

        return rv;
    }

    public static MyVector3 operator /(MyVector3 lhs, float rhs)
    {
        return DivideVector(lhs, rhs);
    }

    public MyVector3 NormalizeVector()
    {
        MyVector3 rv;

        rv = this / Length();

        return rv;
    }

    public static float DotProductVector(MyVector3 a, MyVector3 b, bool shouldNormalize = true)
    {
        float rv;

        MyVector3 A = new MyVector3(a.x, a.y, a.z);
        MyVector3 B = new MyVector3(b.x, b.y, b.z);

        //Normalize the vectors
        if(shouldNormalize)
        {
            A = A.NormalizeVector();
            B = B.NormalizeVector();

            //Do the dot product using the formula
            rv = A.x * B.x + A.y * B.y + A.z * B.z;
        }
        else
        {
            //Do the dot product using the formula
            rv = A.x * B.x + A.y * B.y + A.z * B.z;
        }


        return rv;
    }

    public static MyVector3 ToMyVector3(Vector3 vector3)
    {
        MyVector3 rv = new MyVector3(vector3.x, vector3.y, vector3.z);

        return rv;
    }

    public static implicit operator MyVector3(MyVector4 vector4) => new MyVector3(vector4.x, vector4.y, vector4.z);

    public static MyVector3[] Vector3ArrayToMyVector3Array(Vector3[] vector3Array)
    {
        MyVector3[] rv = new MyVector3[vector3Array.Length];

        for (int i = 0; i < vector3Array.Length; i++)
        {
            rv[i] = ToMyVector3(vector3Array[i]);
        }

        return rv;
    }

    public static Vector3[] MyVector3ArrayToVector3Array(MyVector3[] myVector3Array)
    {
        Vector3[] rv = new Vector3[myVector3Array.Length];

        for (int i = 0; i < myVector3Array.Length; i++)
        {
            rv[i] = myVector3Array[i].ToUnityVector3();
        }

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

    public Vector3 ToUnityVector3()
    {
        Vector3 rv = new Vector3(x, y, z);

        return rv;
    }
}
