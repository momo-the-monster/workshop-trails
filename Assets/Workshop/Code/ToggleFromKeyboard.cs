using UnityEngine;
using System.Collections;

public class ToggleFromKeyboard : MonoBehaviour {

    public KeyCode triggerKey = KeyCode.Space;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(triggerKey))
        {
            Renderer r = GetComponent<Renderer>();
            if (r != null)
            {
                r.enabled = !r.enabled;
            }
        }
	}
}
