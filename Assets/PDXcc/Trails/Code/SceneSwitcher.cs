using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {

    public KeyCode triggerKey = KeyCode.Equals;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(triggerKey))
        {
            // Incrementing Scene
            int nextLevel = Application.loadedLevel;
            nextLevel++;
            if (nextLevel >= Application.levelCount)
            {
                nextLevel = 0;
            }
            Application.LoadLevel(nextLevel);
        }
	}
}
