using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float roteteSpeed = 1.2f;

    void Update()
    {
      // RenderSettings.skybox.SetFloat("_RotationY", Time.time * roteteSpeed);
        RenderSettings.skybox.SetFloat("_RotationX", Time.time * roteteSpeed);
    }
}
