using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRotation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float sensitivity;
    [SerializeField] private float speed;
    private Vector3 mousePos;
    private MyVector3 position;
    private MyVector3 rotationDegrees;

    [Header("Direction Vectors")]
    private MyVector3 forwardDirection = new MyVector3(0, 0, 0);
    private MyVector3 rightDirection = new MyVector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        //Gets mouse position
        mousePos = Input.mousePosition * sensitivity;

        //Gets for the position in game
        position = new MyVector3(transform.position.x, transform.position.y, transform.position.z);

        //Gets player rotation in game
        rotationDegrees = new MyVector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

        //Rotates the pitch and yaw of the object
        transform.rotation = Quaternion.Euler(mousePos.y, -mousePos.x, 0);

        //Converts degrees into radians
        MyVector3 radiansVector = MathFunctions.DegreesToRadiansVector(rotationDegrees);

        //Transform the euler angles to a direction vector
        forwardDirection = MathFunctions.EulerAnglesToDirection(radiansVector);

        //Cross product
        rightDirection = MathFunctions.CrossProduct(forwardDirection, new MyVector3(0, 1, 0));

        //Move forward
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += forwardDirection.ToUnityVector3() * Time.deltaTime * speed;
        }

        //Move backwards
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= forwardDirection.ToUnityVector3() * Time.deltaTime * speed;
        }

        //Move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += rightDirection.ToUnityVector3() * Time.deltaTime * speed;
        }

        //Move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= rightDirection.ToUnityVector3() * Time.deltaTime * speed;
        }

    }
}
