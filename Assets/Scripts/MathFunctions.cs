using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathFunctions
{
    public static float VectorToRadians(MyVector2 V2)
    {
        float rv = 0.0f;

        rv = Mathf.Atan2(V2.y, V2.x);

        return rv;
    }

    public static MyVector2 RadiansToVector(float angleRad)
    {
        MyVector2 rv = new MyVector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

        return rv;
    }

    public static MyVector3 EulerAnglesToVector(MyVector3 eulerAngles)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = Mathf.Cos(eulerAngles.y) * Mathf.Cos(eulerAngles.x);
        rv.y = Mathf.Cos(eulerAngles.x) * Mathf.Sin(eulerAngles.y);
        rv.z = Mathf.Sin(eulerAngles.x);

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
}
