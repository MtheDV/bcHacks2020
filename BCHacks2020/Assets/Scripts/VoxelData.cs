using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelData : MonoBehaviour
{
    public static readonly Vector2[] voxelVertics = new Vector2[4]
    {
        new Vector2(0.0f, 0.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 1.0f),
        new Vector2(0.0f, 1.0f),
    };

    public static readonly int[,] voxelTriangle = new int[1, 6]
    {
        {0, 3, 1, 1, 3, 2}
    };

    public static readonly Vector2[] voxelUvs = new Vector2[6] {

        new Vector2 (0.0f, 0.0f),
        new Vector2 (0.0f, 1.0f),
        new Vector2 (1.0f, 0.0f),
        new Vector2 (1.0f, 0.0f),
        new Vector2 (0.0f, 1.0f),
        new Vector2 (1.0f, 1.0f)

    };



}
