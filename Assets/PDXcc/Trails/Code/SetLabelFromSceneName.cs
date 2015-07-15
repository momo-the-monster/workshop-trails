using UnityEngine;
using System.Collections;

namespace pdxcc {
    
    [RequireComponent(typeof(UnityEngine.UI.Text))]
    public class SetLabelFromSceneName : MonoBehaviour {

	    void Start () {
            GetComponent<UnityEngine.UI.Text>().text = Application.loadedLevelName;
	    }

    }

}