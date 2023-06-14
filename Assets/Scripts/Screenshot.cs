using UnityEngine;
using UnityEditor;
using System.IO;

public class Screenshot : MonoBehaviour
{

    public Camera mainCam;

    public int cWidth;
    public int cHeight;

    public string folderPath;

    private RenderTexture rt;
    private Texture2D screenshotOutput;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            TakeScreenshot();
    }

    private void TakeScreenshot()
    {
        if (mainCam == null)
            mainCam = GetComponent<Camera>();

        rt = new RenderTexture(cWidth, cHeight, 24);
        mainCam.targetTexture = rt;

        screenshotOutput = new Texture2D(cWidth, cHeight, TextureFormat.RGBA32, false);
        mainCam.Render();

        RenderTexture.active = rt;
        screenshotOutput.ReadPixels(new Rect(0, 0, cWidth, cHeight), 0, 0);

        mainCam.targetTexture = null;
        RenderTexture.active = null;

        Destroy(rt);

        byte[] bytes = screenshotOutput.EncodeToPNG();
        File.WriteAllBytes(folderPath + "Didder" + ".PNG", bytes);

        AssetDatabase.Refresh();
    }
}

public enum Format
{
    RAW,
    JPG,
    PNG
}
