using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateQuat : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float angle;

    [Header("Quads")]
    private Quat q;
    private Quat K;
    private Quat newK;

    [Header("Vectors")]
    [SerializeField] private Transform pivot;
    [SerializeField] private Vector3 offset;
    private MyVector3 newPivot;

    // Update is called once per frame
    void Update()
    {
        if (offset == new Vector3(0, 0, 0)) return;
        
        angle += Time.deltaTime;

        //Define a quaternion that is equivalent of rotating around the Yaw axis by "angle" amount
        q = new Quat(angle, new MyVector3(0, 1, 0));
        
        //Store that vector in a quaternion 
        K = new Quat(MyVector3.ToMyVector3(offset));

        //newK will have our new position inside of it
        newK = q * K * q.Inverse();
        
        //Gets the position as a vector
        newPivot = MyVector3.ToMyVector3(newK.GetAxis());

        //Set the position so we can see if its working
        transform.position = newPivot.ToUnityVector3() + pivot.transform.position - offset / 2;

        //Angle += Time.deltaTime / offset.Lenght
    }
}
