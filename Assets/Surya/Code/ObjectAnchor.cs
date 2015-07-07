using UnityEngine;
using System.Collections;

public class ObjectAnchor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

#if UNITY_EDITOR
    public void OnDrawGizmosSelected()
    {
        float arrowSize = 0.5f;
        UnityEditor.Handles.color = Color.yellow;
     //   UnityEditor.Handles.ArrowCap(0, transform.position, Quaternion.LookRotation(transform.up), arrowSize);
    }
#endif

}
