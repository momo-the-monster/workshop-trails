using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class SetTextFromSceneName : MonoBehaviour {

	void Start () {
        GetComponent<UnityEngine.UI.Text>().text = Application.loadedLevelName;
	}

}