using UnityEngine;
using Noesis;
using RoverGUI.Views;

public class FPSCounter : MonoBehaviour
{
    public string _TextBlockName;

    float deltaTime = 0.0f;
    float msec;
    float fps;
    TextBlock fpsText;

    void Start()
    {
        var view = this.GetComponent<NoesisView>().Content;
        var hudView = (HudOptionsScreenView)view.FindName("hudOptionsScreenView");
        fpsText = (TextBlock)hudView.FindName(_TextBlockName);
        
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        msec = deltaTime * 1000.0f;
        fps = 1.0f / deltaTime;
        fpsText.Text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
    }

}
