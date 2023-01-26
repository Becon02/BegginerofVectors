using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaderMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        MyVector3 movement = new MyVector3(inputX * moveSpeed, inputY * moveSpeed, 0);
        
        transform.position += movement.ToUnityVector() * Time.deltaTime;
    }
}
