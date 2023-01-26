using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour 
{
    [Header("Game Object")]
    [SerializeField] private GameObject sphere;
    private MyVector3 finalPos;
    private MyVector3 oldPos;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        oldPos = new MyVector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        finalPos = new MyVector3(sphere.transform.position.x, sphere.transform.position.y, sphere.transform.position.z);

        if(transform.position != finalPos.ToUnityVector())
        {
            MyVector3 direction = MyVector3.SubtractVector(finalPos, oldPos);

            MyVector3 normDirection = direction.NormalizeVector();
            MyVector3 moveVelocity = MyVector3.ScaleVector(normDirection, moveSpeed);

            transform.position += moveVelocity.ToUnityVector() * Time.fixedDeltaTime;
        }
    }

    private void FixedUpdate()
    {
        //Raycasting();
    }

    private void Raycasting()
    {
        Debug.DrawRay(oldPos.ToUnityVector(), MyVector3.SubtractVector(finalPos, oldPos).ToUnityVector(), Color.red);
    }

}
