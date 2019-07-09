﻿using UnityEngine;

public class RotateSkybox : MonoBehaviour
{

    public float roteteSpeed = 1.2f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_RotationX", Time.time * roteteSpeed);
    }
}
