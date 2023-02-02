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

    public Vector2 ToUnityVector2()
    {
        Vector2 rv = new Vector2(x, y);

        return rv;
    }
}
