using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRSMethod : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Vector3 Rotate;
    [SerializeField] private Vector3 Position;
    [SerializeField] private Vector3 Scale;

    [Header("Initial Values")]
    private MeshFilter MF;
    [Range(1, 10)]
    [SerializeField] private float objectSize;

    [Header("Vectors")]
    private Vector3[] cubeVertices;
    private MyVector3 rolledVertex;
    private MyVector3 pitchedVertex;
    private MyVector3 yawedVertex;

    void Start()
    {
        Rotate = new Vector3(0, 0, 0);
        Position = new Vector3(0, 0, 0);
        Scale = new Vector3(1, 1, 1);
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

        //Translation Matrix
        Matrix4by4 transMatrix = new Matrix4by4(
            new MyVector4(1, 0, 0, 0),
            new MyVector4(0, 1, 0, 0),
            new MyVector4(0, 0, 1, 0),
            new MyVector4(Position.x, Position.y, Position.z, 1));

        //Scaling Matrix
        Matrix4by4 scaMatrix = new Matrix4by4(new MyVector3(Scale.x, 0, 0) * objectSize, new MyVector3(0, Scale.y, 0) * objectSize, new MyVector3(0, 0, Scale.z) * objectSize, new MyVector3(0, 0, 0));

        Matrix4by4 rotMatrix = yawMatrix * (pitchMatrix * rollMatrix);

        Matrix4by4 M = transMatrix * (rotMatrix * scaMatrix);

        //Transform each vertex of the model
        for (int i = 0; i < transformedVertices.Length; i++)
        {
            //Debug.Log("The position of vertice " + i + " is (" + cubeVertices[i].x + ", " +cubeVertices[i].y + ", " + cubeVertices[i].z + ")");

            transformedVertices[i] = M * MyVector3.ToMyVector3(cubeVertices[i]);
        }

        MF.mesh.vertices = MyVector3.MyVector3ArrayToVector3Array(transformedVertices);

        //These is to make the final step look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
