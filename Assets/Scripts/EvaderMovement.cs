using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaderMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    public MyVector3 movement = new MyVector3(0,0,0);
    public MyVector3 movNormalize = new MyVector3(0,0,0);
    private MyVector3 position;


    // Update is called once per frame
    void Update()
    {
        //Gets the input of the player
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        //Gets for the position of the sphere in game
        position = new MyVector3(transform.position.x, transform.position.y, transform.position.z);

        //Checks if theres input, if not it doesnt move
        if(inputX != 0 || inputZ != 0)
        {
            //Gets the direction it should move
            movement =  new MyVector3(inputX, 0, inputZ);

            //Normalizes the direction of movement
            movNormalize = movement.NormalizeVector();

            //Multiplies the direction with a speed variable to move at a certain speed with the same speed per frame 
            MyVector3 moveVelocity = MyVector3.ScaleVector(movNormalize, moveSpeed);

            //Updates the position of the sphere in a velocity
            transform.position += moveVelocity.ToUnityVector3() * Time.deltaTime;
        }

        Raycasting();
    }

    private void Raycasting()
    {
        Debug.DrawRay(position.ToUnityVector3(), movNormalize.ToUnityVector3() * 2, Color.green);
    }
}
