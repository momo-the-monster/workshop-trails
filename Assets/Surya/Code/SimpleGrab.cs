using UnityEngine;
using System.Collections;

public class SimpleGrab : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeScreenshot();
        }
	}

    void TakeScreenshot()
    {
        string filename = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop).ToString() + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".png";
        Application.CaptureScreenshot(filename,3);
    }

    public int resWidth = 2550; 
    public int resHeight = 3300;
                
    private bool takeHiResShot = false;
                
    public static string ScreenShotName(int width, int height) {
        return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop).ToString() + "\\CardGrabs\\" + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".png";
    }
    
   public void TakeHiResShot() {
       takeHiResShot = true;
   }
    
   void LateUpdate() {
       takeHiResShot |= Input.GetKeyDown("k");
       if (takeHiResShot) 
       {
           RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
           Camera camera = GetComponent<Camera>();
           camera.targetTexture = rt;
           Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.ARGB32, false);
           camera.Render();
           RenderTexture.active = rt;
           screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
           camera.targetTexture = null;
           RenderTexture.active = null; 
           Destroy(rt);
           byte[] bytes = screenShot.EncodeToPNG();
           string filename = ScreenShotName(resWidth, resHeight);
 
           System.IO.File.WriteAllBytes(filename, bytes);
           Debug.Log(string.Format("Took screenshot to: {0}", filename));
   //        Application.OpenURL(filename);
           takeHiResShot = false;
       }
    }

}
