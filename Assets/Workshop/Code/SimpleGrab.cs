using UnityEngine;
using System.Collections;

public class SimpleGrab : MonoBehaviour {

    public KeyCode triggerKey;
    [Range(1, 20)]
    public int superSize = 1;
    public string subfolder = "Workshop";

	void Start () {
        System.IO.DirectoryInfo info = System.IO.Directory.CreateDirectory(GetScreenshotDirectory());
	}
	
	void Update () {
        if (Input.GetKeyDown(triggerKey))
        {
            TakeScreenshot();
        }
	}

    void TakeScreenshot()
    {
        Application.CaptureScreenshot(GetScreenshotName(),superSize);
        Debug.LogFormat("Captured Screenshot to {0}", GetScreenshotName());
    }
                
    public string GetScreenshotName() {
        return GetScreenshotDirectory() + System.IO.Path.DirectorySeparatorChar + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".png";
    }

    public string GetScreenshotDirectory()
    {
        return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments).ToString() + System.IO.Path.DirectorySeparatorChar + subfolder;
    }
    

}