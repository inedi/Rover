using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class PostprosessCameraShaderEffect : MonoBehaviour
{
    [SerializeField]
    private Material material;

    private Camera camera;

    void Awake()
    {
        camera = GetComponent<Camera>();
        camera.depthTextureMode = camera.depthTextureMode | DepthTextureMode.DepthNormals;
    }

    private void Start()
    {
        
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
