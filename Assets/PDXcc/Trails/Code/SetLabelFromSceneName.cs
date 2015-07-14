using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(UnityEngine.UI.Text))]
namespace pdxcc {

    public class SetLabelFromSceneName : MonoBehaviour {

	void Start () {
        GetComponent<UnityEngine.UI.Text>().text = Application.loadedLevelName;
	}

    }
}