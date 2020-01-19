using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraLerpSpeed = 1.0f;
    void LateUpdate()
    {
        Vector3 lerpCamera = Vector3.Lerp(transform.position, playerTransform.position, cameraLerpSpeed * Time.deltaTime);
        lerpCamera = new Vector3(lerpCamera.x, lerpCamera.y, -10);
        transform.position = lerpCamera;
    }
}
