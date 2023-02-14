using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateBetween2Points : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private GameObject sphere1;
    [SerializeField] private GameObject sphere2;
    private MyVector3 finalPos;
    private MyVector3 startPos;

    [Header("Lerp Settings")]
    [Range(0, 1)]
    [SerializeField] private float fractionalValue;
    [Header("Vectors")]
    private MyVector3 lerpPosition = new MyVector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        startPos = new MyVector3(sphere1.transform.position.x, sphere1.transform.position.y, sphere1.transform.position.z);
        finalPos = new MyVector3(sphere2.transform.position.x, sphere2.transform.position.y, sphere2.transform.position.z);

        transform.position = sphere1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lerpPosition = MathFunctions.VectorLerp(startPos, finalPos, fractionalValue);

        transform.position = lerpPosition.ToUnityVector3();
    }
}
