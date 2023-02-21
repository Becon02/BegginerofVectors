using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Vector3 scale;
    [Range(1, 10)]
    [SerializeField] private float objectSize;

    [Header("Initial Values")]
    private MeshFilter MF;

    [Header("Vectors")]
    private Vector3[] cubeVertices;

    void Start()
    {
        scale = new Vector3(1, 1, 1);
        objectSize = 1;

        //Stores information about the current mesh of the object
        MF = GetComponent<MeshFilter>();

        //We get a copy of all of the vertices of the cube
        cubeVertices = MF.mesh.vertices;

        //Debug.Log("The cube has " + cubeVertices.Length + " vertices.");
    }

    void Update()
    {
        //Define a new array with the correct size
        MyVector3[]  transformedVertices = new MyVector3[cubeVertices.Length];

        //Create our rotation Matrix
        Matrix4by4 scaMatrix = new Matrix4by4(new MyVector3(scale.x, 0, 0) * objectSize, new MyVector3(0, scale.y, 0) * objectSize, new MyVector3(0, 0, scale.z) * objectSize, new MyVector3(0, 0, 0));

        //Transform each vertex of the model
        for (int i = 0; i < transformedVertices.Length; i++)
        {
            //Debug.Log("The position of vertice " + i + " is (" + cubeVertices[i].x + ", " +cubeVertices[i].y + ", " + cubeVertices[i].z + ")");
            
            transformedVertices[i] = scaMatrix * MyVector3.ToMyVector3(cubeVertices[i]);

        }

        MF.mesh.vertices = MyVector3.MyVector3ArrayToVector3Array(transformedVertices);

        //These is to make the final step look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
