using UnityEngine;
using System.Collections;

/*
 * Set Text value from Scene on Load
 */
namespace mmm {
    
    [RequireComponent(typeof(UnityEngine.UI.Text))]
    public class SetLabelFromSceneName : MonoBehaviour {

	    void Start () {
            GetComponent<UnityEngine.UI.Text>().text = Application.loadedLevelName;
	    }

    }

}