using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector2
{
    public float x, y;

    public MyVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static MyVector2 ToMyVector2(Vector2 vector2)
    {
        MyVector2 rv = new MyVector2(vector2.x, vector2.y);

        return rv;
    }

    public Vector2 ToUnityVector2()
    {
        Vector2 rv = new Vector2(x, y);

        return rv;
    }
}
