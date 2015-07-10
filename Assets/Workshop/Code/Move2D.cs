using UnityEngine;
using System.Collections;

public class Move2D : MonoBehaviour {

    public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 translation = Vector3.zero;
        translation.x = Mathf.RoundToInt(Input.GetAxis("Horizontal")) * speed;
        translation.y = Mathf.RoundToInt(Input.GetAxis("Vertical")) * speed;

        transform.position += translation;
	}
}
