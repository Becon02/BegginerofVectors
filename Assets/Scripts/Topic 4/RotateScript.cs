using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Vector3 Rotate;

    [Header("Initial Values")]
    private MeshFilter MF;

    [Header("Vectors")]
    private Vector3[] cubeVertices;
    private MyVector3 rolledVertex;
    private MyVector3 pitchedVertex;
    private MyVector3 yawedVertex;

    void Start()
    {
        Rotate = new Vector3(0, 0, 0);

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

        //Create our rotation Matrix rotation around the Roll, Pitch and Yaw in that order
        Matrix4by4 rollMatrix = new Matrix4by4(
            new MyVector3(Mathf.Cos(Rotate.z), Mathf.Sin(Rotate.z), 0), 
            new MyVector3(-Mathf.Sin(Rotate.z), Mathf.Cos(Rotate.z), 0), 
            new MyVector3(0, 0, 1), 
            new MyVector3(0, 0, 0));

        Matrix4by4 pitchMatrix = new Matrix4by4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, Mathf.Cos(Rotate.x), Mathf.Sin(Rotate.x)),
            new MyVector3(0, -Mathf.Sin(Rotate.x), Mathf.Cos(Rotate.x)),
            new MyVector3(0, 0, 0));

        Matrix4by4 yawMatrix = new Matrix4by4(
            new MyVector3(Mathf.Cos(Rotate.y), 0, -Mathf.Sin(Rotate.y)),
            new MyVector3(0, 1, 0),
            new MyVector3(Mathf.Sin(Rotate.y), 0, Mathf.Cos(Rotate.y)),
            new MyVector3(0, 0, 0));

        //Transform each vertex of the model
        for (int i = 0; i < transformedVertices.Length; i++)
        {
            //Debug.Log("The position of vertice " + i + " is (" + cubeVertices[i].x + ", " +cubeVertices[i].y + ", " + cubeVertices[i].z + ")");

            rolledVertex = rollMatrix * MyVector3.ToMyVector3(cubeVertices[i]);
            pitchedVertex = pitchMatrix * rolledVertex;
            yawedVertex = yawMatrix * pitchedVertex;

            transformedVertices[i] = yawedVertex;
        }

        MF.mesh.vertices = MyVector3.MyVector3ArrayToVector3Array(transformedVertices);

        //These is to make the final step look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
