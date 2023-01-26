using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour 
{
    [Header("Game Object")]
    [SerializeField] private GameObject sphere;

    private MyVector3 newPos;
    private MyVector3 oldPos;
    private MyVector3 direction;

    private void Start()
    {
        newPos = new MyVector3(sphere.transform.position.x, sphere.transform.position.y, sphere.transform.position.z);
        oldPos = new MyVector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = newPos - oldPos;

            MyVector3 moveTo = MyVector3.AddVector(direction, oldPos);

            transform.position = moveTo.ToUnityVector();
        }
    }

}
