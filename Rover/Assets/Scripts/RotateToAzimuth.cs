using RoverGUI.ViewModels;
using RoverGUI.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToAzimuth : MonoBehaviour
{
    TelemetryScreenViewModel _context;

    [SerializeField] Camera noesisCamera;

    void Start()
    {
        var view = noesisCamera.GetComponent<NoesisView>().Content;
        var telemetryview = (TelemetryScreenView)view.FindName("telemetryScreenView");
        _context = (TelemetryScreenViewModel)telemetryview.DataContext;
    }

    void Update()
    {

        _context.Azimuth = (int)transform.rotation.eulerAngles.y;
    }
}
