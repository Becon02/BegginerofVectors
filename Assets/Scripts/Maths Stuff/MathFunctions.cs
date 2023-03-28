using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathFunctions
{
    public static MyVector3 EulerAnglesToDirection(MyVector3 eulerAngles)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = Mathf.Cos(eulerAngles.x) * Mathf.Sin(eulerAngles.y);
        rv.y = -Mathf.Sin(eulerAngles.x);
        rv.z = Mathf.Cos(eulerAngles.y) * Mathf.Cos(eulerAngles.x);

        return rv;
    }

    public static MyVector3 DegreesToRadiansVector(MyVector3 degreesVector)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = (degreesVector.x * Mathf.PI) / 180;
        rv.y = (degreesVector.y * Mathf.PI) / 180;
        rv.z = (degreesVector.z * Mathf.PI) / 180;

        return rv;
    }

    public static MyVector3 CrossProduct(MyVector3 a, MyVector3 b)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = a.y * b.z - a.z * b.y;
        rv.y = a.x * b.z - a.z * b.x;
        rv.z = a.x * b.y - a.y * b.x;

        return rv;
    }

    public static MyVector3 VectorLerp(MyVector3 A, MyVector3 B, float T)
    {
        //Clamps the fractional value so its always between 0 and 1
        T = Mathf.Clamp(T, 0, 1);

        return A * (1 - T) + B * T; 
    }

    public static MyVector3 RotatedVertex(float angle, MyVector3 Axis, MyVector3 Vertex)
    {
        MyVector3 rv = (Vertex * Mathf.Cos(angle)) +
            (Axis * MyVector3.DotProductVector(Vertex, Axis) * (1.0f - Mathf.Cos(angle))) +
            (CrossProduct(Axis, Vertex) * Mathf.Sin(angle));

        return rv;
    }
}

public class Matrix4by4
{
    //Public multidimensional array 2*2 to store matrix values
    public float[,] values;

    //Public constructor that takes MyVector4 arguments to create a 4by4 matrix
    public Matrix4by4(MyVector4 column1, MyVector4 column2, MyVector4 column3, MyVector4 column4)
    {
        values = new float[4, 4];

        //Column 1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;

        //Column 2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;

        //Column 3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;

        //Column 4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;
    }

    //Public constructor that takes MyVector3 arguments to create a 4by4 matrix
    public Matrix4by4(MyVector3 column1, MyVector3 column2, MyVector3 column3, MyVector3 column4)
    {
        values = new float[4, 4];

        //Column 1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0;

        //Column 2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0;

        //Column 3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0;

        //Column 4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1;
    }

    //Operator overload that multiplies a matrix4by4 by a MyVector4
    public static MyVector4 operator *(Matrix4by4 lhs, MyVector4 rhs)
    {
        MyVector4 rv = new MyVector4(0, 0, 0, 0);

        rv.x = lhs.values[0, 0] * rhs.x + lhs.values[0, 1] * rhs.y + lhs.values[0, 2] * rhs.z + lhs.values[0, 3] * rhs.w;
        rv.y = lhs.values[1, 0] * rhs.x + lhs.values[1, 1] * rhs.y + lhs.values[1, 2] * rhs.z + lhs.values[1, 3] * rhs.w;
        rv.z = lhs.values[2, 0] * rhs.x + lhs.values[2, 1] * rhs.y + lhs.values[2, 2] * rhs.z + lhs.values[2, 3] * rhs.w;
        rv.w = lhs.values[3, 0] * rhs.x + lhs.values[3, 1] * rhs.y + lhs.values[3, 2] * rhs.z + lhs.values[3, 3] * rhs.w;

        return rv;
    }

    public static Matrix4by4 Identity
    {
        get
        {
            return new Matrix4by4(
                new MyVector4(1, 0, 0, 0),
                new MyVector4(0, 1, 0, 0),
                new MyVector4(0, 0, 1, 0),
                new MyVector4(0, 0, 0, 1));
        }
    }
    public static Matrix4by4 operator *(Matrix4by4 lhs, Matrix4by4 rhs)
    {
        Matrix4by4 rv = Identity;

        //1st Row
        rv.values[0, 0] = lhs.values[0, 0] * rhs.values[0, 0] + lhs.values[0, 1] * rhs.values[1, 0] + lhs.values[0, 2] * rhs.values[2, 0] + lhs.values[0, 3] * rhs.values[3, 0];
        rv.values[0, 1] = lhs.values[0, 0] * rhs.values[0, 1] + lhs.values[0, 1] * rhs.values[1, 1] + lhs.values[0, 2] * rhs.values[2, 1] + lhs.values[0, 3] * rhs.values[3, 1];
        rv.values[0, 2] = lhs.values[0, 0] * rhs.values[0, 2] + lhs.values[0, 1] * rhs.values[1, 2] + lhs.values[0, 2] * rhs.values[2, 2] + lhs.values[0, 3] * rhs.values[3, 2];
        rv.values[0, 3] = lhs.values[0, 0] * rhs.values[0, 3] + lhs.values[0, 1] * rhs.values[1, 3] + lhs.values[0, 2] * rhs.values[2, 3] + lhs.values[0, 3] * rhs.values[3, 3];

        //2nd Row
        rv.values[1, 0] = lhs.values[1, 0] * rhs.values[0, 0] + lhs.values[1, 1] * rhs.values[1, 0] + lhs.values[1, 2] * rhs.values[2, 0] + lhs.values[1, 3] * rhs.values[3, 0];
        rv.values[1, 1] = lhs.values[1, 0] * rhs.values[0, 1] + lhs.values[1, 1] * rhs.values[1, 1] + lhs.values[1, 2] * rhs.values[2, 1] + lhs.values[1, 3] * rhs.values[3, 1];
        rv.values[1, 2] = lhs.values[1, 0] * rhs.values[0, 2] + lhs.values[1, 1] * rhs.values[1, 2] + lhs.values[1, 2] * rhs.values[2, 2] + lhs.values[1, 3] * rhs.values[3, 2];
        rv.values[1, 3] = lhs.values[1, 0] * rhs.values[0, 3] + lhs.values[1, 1] * rhs.values[1, 3] + lhs.values[1, 2] * rhs.values[2, 3] + lhs.values[1, 3] * rhs.values[3, 3];

        //3rd Row
        rv.values[2, 0] = lhs.values[2, 0] * rhs.values[0, 0] + lhs.values[2, 1] * rhs.values[1, 0] + lhs.values[2, 2] * rhs.values[2, 0] + lhs.values[2, 3] * rhs.values[3, 0];
        rv.values[2, 1] = lhs.values[2, 0] * rhs.values[0, 1] + lhs.values[2, 1] * rhs.values[1, 1] + lhs.values[2, 2] * rhs.values[2, 1] + lhs.values[2, 3] * rhs.values[3, 1];
        rv.values[2, 2] = lhs.values[2, 0] * rhs.values[0, 2] + lhs.values[2, 1] * rhs.values[1, 2] + lhs.values[2, 2] * rhs.values[2, 2] + lhs.values[2, 3] * rhs.values[3, 2];
        rv.values[2, 3] = lhs.values[2, 0] * rhs.values[0, 3] + lhs.values[2, 1] * rhs.values[1, 3] + lhs.values[2, 2] * rhs.values[2, 3] + lhs.values[2, 3] * rhs.values[3, 3];

        //4th Row
        rv.values[3, 0] = lhs.values[3, 0] * rhs.values[0, 0] + lhs.values[3, 1] * rhs.values[1, 0] + lhs.values[3, 2] * rhs.values[2, 0] + lhs.values[3, 3] * rhs.values[3, 0];
        rv.values[3, 1] = lhs.values[3, 0] * rhs.values[0, 1] + lhs.values[3, 1] * rhs.values[1, 1] + lhs.values[3, 2] * rhs.values[2, 1] + lhs.values[3, 3] * rhs.values[3, 1];
        rv.values[3, 2] = lhs.values[3, 0] * rhs.values[0, 2] + lhs.values[3, 1] * rhs.values[1, 2] + lhs.values[3, 2] * rhs.values[2, 2] + lhs.values[3, 3] * rhs.values[3, 2];
        rv.values[3, 3] = lhs.values[3, 0] * rhs.values[0, 3] + lhs.values[3, 1] * rhs.values[1, 3] + lhs.values[3, 2] * rhs.values[2, 3] + lhs.values[3, 3] * rhs.values[3, 3];

        return rv;
    }
}

public class Quat
{
    public float w;
    public MyVector3 v;

    public Quat()
    {
        w = 0.0f;
        v = new MyVector3(0, 0, 0);
    }

    public Quat (float angle, MyVector3 Axis)
    {
        float halfAngle = angle / 2;
        w = Mathf.Cos(halfAngle);

        v = Axis * Mathf.Sin(halfAngle);
    }

    public Quat(MyVector3 Position)
    {
        w = 0.0f;
        v = new MyVector3(Position.x, Position.y, Position.z);
    }

    public static Quat operator * (Quat lhs, Quat rhs)
    {
        Quat rv = new Quat();

        rv.w = lhs.w * rhs.w - MyVector3.DotProductVector(lhs.v, rhs.v);

        rv.v = rhs.v * lhs.w + lhs.v * rhs.w + MathFunctions.CrossProduct(rhs.v, lhs.v);

        return rv;
    }

    public Quat SetAxis(Vector3 Axis)
    {
        Quat rv;

        float w = 0.0f;

        rv = new Quat(w, MyVector3.ToMyVector3(Axis));

        return rv;
    }

    public Vector3 GetAxis()
    {
        Vector3 rv;

        rv = new Vector3(v.x, v.y, v.z);

        return rv;
    }

    public Quat Inverse()
    {
        Quat rv = new Quat();

        rv.w = w;

        rv.SetAxis(-GetAxis());

        return rv;
    }

    public MyVector4 GetAxisAngle()
    {
        MyVector4 rv = new MyVector4(0, 0, 0, 0);

        float halfAngle = Mathf.Acos(w);
        rv.w = halfAngle * 2;

        rv.x = v.x / Mathf.Sin(halfAngle);
        rv.y = v.y / Mathf.Sin(halfAngle);
        rv.z = v.z / Mathf.Sin(halfAngle);

        return rv;
    }

    public static Quat Slerp(Quat q, Quat r, float t)
    {
        t = Mathf.Clamp(t, 0.0f, 1.0f);

        Quat d = r * q.Inverse();

        MyVector4 AxisAngle = d.GetAxisAngle();

        Quat dT = new Quat(AxisAngle.w * t, new MyVector3(AxisAngle.x, AxisAngle.y, AxisAngle.z));

        return dT * q;
    }
}
