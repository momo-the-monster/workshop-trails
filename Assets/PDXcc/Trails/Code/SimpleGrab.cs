using UnityEngine;
using System.Collections;

/**
 * Save a screengrab to a subdirectory of the user's Documents folder
 * Change the subfolder property to pick a different subfolder
 */

namespace pdxcc
{

    public class SimpleGrab : MonoBehaviour
    {
        // Trigger a Capture with this key
        public KeyCode triggerKey;
        // Factor by which to increase resolution
        [Range(1, 20)]
        public int superSize = 1;
        // Subfolder within which to save images (blank for none)
        public string subfolder = "Workshop";

        // Create directory on startup (does nothing if it already exists)
        void Start()
        {
            System.IO.DirectoryInfo info = System.IO.Directory.CreateDirectory(GetScreenshotDirectory());
        }

        // Trigger screenshot on keypress
        void Update()
        {
            if (Input.GetKeyDown(triggerKey))
            {
                TakeScreenshot();
            }
        }

        // Capture the screenshot and log the path to the console
        void TakeScreenshot()
        {
            Application.CaptureScreenshot(GetScreenshotName(), superSize);
            Debug.LogFormat("Captured Screenshot to {0}", GetScreenshotName());
        }

        // Create filename from Timestamp
        public string GetScreenshotName()
        {
            return GetScreenshotDirectory() + System.IO.Path.DirectorySeparatorChar + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".png";
        }

        // Get path to desired directory
        public string GetScreenshotDirectory()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments).ToString() + System.IO.Path.DirectorySeparatorChar + subfolder;
        }

    }
}