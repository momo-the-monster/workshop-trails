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
        // Don't start up if we don't have a brush prefab selected
        if (brushPrefab == null)
        {
            enabled = false;
        }
        // seed the start position of the mouse
        mousePositionPrevious = Input.mousePosition;
	}
	
	void Update () {

        // Detect Left Mouse Button Down
        if (Input.GetMouseButtonDown(0))
        {
            AddBrush(0, GetBrushPositionFromMouse());
        }

        // Detect Left Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {
            RemoveBrush(0);
        }

        // If mouse has moved
        if (currentBrush != null && Vector3.Distance(mousePositionPrevious, Input.mousePosition) > 0)
        {
            // Move the current brush position to the mouse, snapping to the grid
            currentBrush.transform.position = GetBrushPositionFromMouse();
        }
	}

    // Add a brush to the scene, set as the current brush
    void AddBrush(int index, Vector3 position)
    {
        GameObject g = (GameObject)GameObject.Instantiate(brushPrefab, position, Quaternion.identity);
        currentBrush = g;
    }

    // Transform mouse position to world space, snap to the specified grid
    Vector3 GetBrushPositionFromMouse()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.x = gridSnap * Mathf.Round(position.x / gridSnap);
        position.y = gridSnap * Mathf.Round(position.y / gridSnap);
        position.z = 0;
        return position;
    }

    // Call a delayed destroy on the brush, unset the currentBrush
    void RemoveBrush(int index)
    {
        if (currentBrush != null)
        {
            currentBrush.GetComponent<DestroyDelayed>().Trigger(this.currentBrush.GetComponentInChildren<TrailRenderer>().time);
        }
        currentBrush = null;
    }
}
