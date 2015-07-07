using UnityEngine;
using System.Collections;

public class AddScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            StartCoroutine(CoAddScene(7));
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(CoAddScene(5));
            StartCoroutine(CoAddScene(6));
            StartCoroutine(CoAddScene(7));
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            StartCoroutine(CoAddScene(Application.loadedLevel));
        }
	}

    IEnumerator CoAddScene(int which)
    {
        AsyncOperation async = Application.LoadLevelAdditiveAsync(which);
        yield return async;
        Debug.Log("Loading complete");
    }
}
