using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {

    public Vector3 rotationAmount;
    internal Vector3 vXAxis;
    internal Vector3 vYAxis;
    internal Vector3 vZAxis;

	// Use this for initialization
	void Start () {
        vXAxis = new Vector3(1, 0, 0);
        vYAxis = new Vector3(0, 1, 0);
        vZAxis = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
        float deltaTime = Time.deltaTime;
        transform.Rotate(rotationAmount.x * deltaTime, rotationAmount.y * deltaTime, rotationAmount.z * deltaTime);
	}
}
