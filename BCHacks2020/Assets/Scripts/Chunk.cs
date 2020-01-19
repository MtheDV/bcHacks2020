using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    void Start()
    {
        int vertexIndex = 0;
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangle = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        for (int i = 0; i < 6; i++)
        {
            int triangleIndex = VoxelData.voxelTriangle[0, i];
            vertices.Add(new Vector3(VoxelData.voxelVertics[triangleIndex].x, VoxelData.voxelVertics[triangleIndex].y, 0));
            triangle.Add(vertexIndex);
            uvs.Add(VoxelData.voxelUvs[i]);

            vertexIndex++;
        }



        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangle.ToArray();
        mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;



    }
}
