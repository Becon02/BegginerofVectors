using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateScript : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Vector3 Position;

    [Header("Initial Values")]
    private MeshFilter MF;

    [Header("Vectors")]
    private Vector3[] cubeVertices;

    void Start()
    {
        Position = new Vector3(0, 0, 0);

        //Stores information about the current mesh of the object
        MF = GetComponent<MeshFilter>();

        //We get a copy of all of the vertices of the cube
        cubeVertices = MF.mesh.vertices;

        //Debug.Log("The cube has " + cubeVertices.Length + " vertices.");
    }

    void Update()
    {
        //Define a new array with the correct size
        MyVector3[] transformedVertices = new MyVector3[cubeVertices.Length];

        //Create our rotation Matrix
        Matrix4by4 transMatrix = new Matrix4by4(
            new MyVector4(1, 0, 0, 0), 
            new MyVector4(0, 1, 0, 0), 
            new MyVector4(0, 0, 1, 0), 
            new MyVector4(Position.x, Position.y, Position.z, 1));

        //Transform each vertex of the model
        for (int i = 0; i < transformedVertices.Length; i++)
        {
            //Debug.Log("The position of vertice " + i + " is (" + cubeVertices[i].x + ", " +cubeVertices[i].y + ", " + cubeVertices[i].z + ")");

            transformedVertices[i] = transMatrix * MyVector3.ToMyVector3(cubeVertices[i]);

        }

        MF.mesh.vertices = MyVector3.MyVector3ArrayToVector3Array(transformedVertices);

        //These is to make the final step look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
