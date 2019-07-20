using UnityEngine;
using Noesis;
using RoverGUI.Views;
public class RenderCameraToTelemetryScreenXaml : MonoBehaviour
{
    public UnityEngine.Camera _camera;

    public string _renderElementRectangleName;
    void Start()
    {
        
        var view = this.GetComponent<NoesisView>().Content;
        var telemetryview = (TelemetryScreenView)view.FindName("telemetryScreenView");
        var rect = (Rectangle)telemetryview.FindName(_renderElementRectangleName);

        // Create render texture
        UnityEngine.RenderTexture renderTexture = new UnityEngine.RenderTexture(
            1024, 1024, 1, UnityEngine.RenderTextureFormat.ARGB32, UnityEngine.RenderTextureReadWrite.Linear);
        UnityEngine.RenderTexture.active = renderTexture;


        // Set render texture as camera target
        this._camera.targetTexture = renderTexture;
        this._camera.aspect = 1;

        // Create Noesis texture
        renderTexture.Create();
        var tex = Noesis.Texture.WrapTexture(renderTexture, renderTexture.GetNativeTexturePtr(),
            renderTexture.width, renderTexture.height, 1);

        // Create brush to store render texture and assign it to the rectangle
        rect.Fill = new ImageBrush()
        {
            ImageSource = new TextureSource(tex),
            Stretch = Stretch.UniformToFill,
        };

    }
}
