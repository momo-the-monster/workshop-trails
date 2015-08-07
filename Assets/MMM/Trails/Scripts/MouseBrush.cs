using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class MouseBrush : MonoBehaviour {

    public GameObject brushPrefab;
    public int gridSnap = 1;
    internal GameObject currentBrush;
    internal Vector3 mousePositionPrevious;

	// Use this for initialization
	void Start () {
        if (brushPrefab == null)
        {
            enabled = false;
        }

        mousePositionPrevious = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            AddBrush(0, GetBrushPositionFromMouse());
        }

        if (Input.GetMouseButtonUp(0))
        {
            RemoveBrush(0);
        }

        // If mouse has moved
        if (currentBrush != null && Vector3.Distance(mousePositionPrevious, Input.mousePosition) > 0)
        {
            currentBrush.transform.position = GetBrushPositionFromMouse();
        }
	}

    void AddBrush(int index, Vector3 position)
    {
        GameObject g = (GameObject)GameObject.Instantiate(brushPrefab, position, Quaternion.identity);
        currentBrush = g;
    }

    Vector3 GetBrushPositionFromMouse()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.x = gridSnap * Mathf.Round(position.x / gridSnap);
        position.y = gridSnap * Mathf.Round(position.y / gridSnap);
        position.z = 0;
        return position;
    }

    void RemoveBrush(int index)
    {
        if (this.currentBrush != null)
        {
            this.currentBrush.GetComponent<DestroyDelayed>().Trigger(this.currentBrush.GetComponentInChildren<TrailRenderer>().time);
        }
        currentBrush = null;
    }
}
