using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector4 
{
    public float x, y, z, w;

    public MyVector4(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public static MyVector4 ToMyVector4(Vector4 vector4)
    {
        MyVector4 rv = new MyVector4(vector4.x, vector4.y, vector4.z, vector4.w);

        return rv;
    }

    public Vector4 ToUnityVector4()
    {
        Vector4 rv = new Vector4(x, y, z, w);

        return rv;
    }

    public static implicit operator MyVector4(MyVector3 vector3) => new MyVector4(vector3.x, vector3.y, vector3.z, 1);

}
