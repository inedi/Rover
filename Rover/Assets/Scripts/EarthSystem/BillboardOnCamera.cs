using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardOnCamera : MonoBehaviour
{
    public UnityEngine.Camera _camera;
    void Start()
    {
        //for dynamic camera use void Update
        transform.LookAt(_camera.transform.position, -Vector3.up);
    }

    void Update()
    {
        //for static camera use void Start
        // transform.LookAt(_camera.transform.position, -Vector3.up);
    }
}
