using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour 
{
    [Header("Game Object")]
    [SerializeField] private GameObject sphere;

    private MyVector3 finalPos;
    private MyVector3 oldPos;
    private MyVector3 direction;


    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        finalPos = new MyVector3(sphere.transform.position.x, sphere.transform.position.y, sphere.transform.position.z);
        oldPos = new MyVector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        oldPos = new MyVector3(transform.position.x, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("OldPos: (" + oldPos.x + ", " + oldPos.y + ", " + oldPos.z + ")");
            direction = MyVector3.SubtractVector(finalPos, oldPos);
            Debug.Log("Direction: (" + direction.x + ", " + direction.y + ", " + direction.z + ")");

            //First topic Cube TP to Sphere instantly
            //MyVector3 moveTo = MyVector3.AddVector(direction, oldPos);
            //transform.position = moveTo.ToUnityVector();

            MyVector3 normDirection = direction.NormalizeVector();
            Debug.Log("Norm Direction: (" + normDirection.x +", " + normDirection.y + ", " + normDirection.z + ")");

            MyVector3 moveVelocity = MyVector3.ScaleVector(normDirection, moveSpeed);
            Debug.Log("Move Velocity: (" + moveVelocity.x + ", " + moveVelocity.y + ", " + moveVelocity.z + ")");

            transform.position = moveVelocity.ToUnityVector();

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
