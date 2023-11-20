using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        //Translate(1, 1);
        Rotate(45);
    }

    //function to move the object
    void Translate(float x, float y)
    {
        //set the transformMatrix to the identity matrix
        transformMatrix.SetIdentity();
        //use the SetTranslationMatrix function we created in the HMatrix2D.cs to get the translation matrix 
        transformMatrix.SetTranslationMatrix(x, y);
        Transform();

        //updating the position of the object
        pos = transformMatrix * pos;
    }

    //function to roatate the object
    void Rotate(float angle)
    {
        //set the transformMatrix to the identity matrix 
        transformMatrix.SetIdentity();
        //use the SetRotationMatrix function we created in the HMatrix2D.cs to get the rotation matrix
        transformMatrix.SetRotationMat(angle);

        Transform();
    }

    //function to actually transform the object 
    private void Transform()
    {
        //setting all the vertices in the objects into an array called vertices
        vertices = meshManager.clonedMesh.vertices;

        //for loop that runs for the length of the vertices array
        for (int i = 0; i < vertices.Length; i++)
        {
            //create a new Hvector2D using the vertex's value
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            //move the vertex using the transformMatrix by multiplying it by the transformMatrix
            vert = transformMatrix * vert;
            //set the new position of the vertex
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        //set the object's mesh's vertices as the changed vertices.
        meshManager.clonedMesh.vertices = vertices;
    }
}
