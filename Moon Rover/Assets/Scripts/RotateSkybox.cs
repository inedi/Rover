using UnityEngine;

public class RotateSkybox : MonoBehaviour
{

    public float roteteSpeed = 1f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_RotationX", Time.time/10 * roteteSpeed);
    }
}
