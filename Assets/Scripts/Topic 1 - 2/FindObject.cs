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
    [SerializeField] private EvaderMovement evaderMovement_script;

    private void Update()
    {
        //Position of the cube
        oldPos = new MyVector3(transform.position.x, transform.position.y, transform.position.z);

        //Position of the sphere
        finalPos = new MyVector3(sphere.transform.position.x, sphere.transform.position.y, sphere.transform.position.z);

        
        //Check if the objects are not in the same place
        if (transform.position != finalPos.ToUnityVector3())
        {
            //Gets the direction it should move
            MyVector3 direction = MyVector3.SubtractVector(finalPos, oldPos);

            //Calculates the distance between the cube and the sphere
            float distance = direction.Length();

            //Normalizes the direction vector
            MyVector3 normDirection = direction.NormalizeVector();

            //Multiplies the direction with a speed variable to move at a certain speed
            MyVector3 moveVelocity = MyVector3.ScaleVector(normDirection, moveSpeed);

            //Dot product of the positions
            float dotProductVectors = MyVector3.DotProductVector(direction, evaderMovement_script.movement, false);

            //Checks that the cube is behind the sphere and if its close enough in order to move towards it
            if(dotProductVectors >= 0 && distance < 15)
            {
                transform.position += moveVelocity.ToUnityVector3() * Time.fixedDeltaTime;
            }
            
        }
        //Makes the cube always look at its target
        transform.LookAt(finalPos.ToUnityVector3());    
        
        Raycasting();
    }

    private void Raycasting()
    {
        Debug.DrawRay(oldPos.ToUnityVector3(), MyVector3.SubtractVector(finalPos, oldPos).ToUnityVector3(), Color.red);
    }

}
