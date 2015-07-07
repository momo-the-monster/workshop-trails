using UnityEngine;
using System.Collections;
using DG.Tweening;

public class IsometricCameraControl : MonoBehaviour {

    Camera camera;
    public bool userMoved = false;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        bool down = Input.GetKeyDown(KeyCode.DownArrow);
        bool up = Input.GetKeyDown(KeyCode.UpArrow);
        bool upOrDown = up || down;
        if (upOrDown)
        {
            userMoved = true;
            Vector3 currentPosition = camera.transform.position;
            Vector3 newPosition = currentPosition;
            float amountToMove = 0.1f;
            newPosition.y += down ? amountToMove : -amountToMove;
            camera.transform.DOMove(newPosition, 1f);
        }

        bool pageUp = Input.GetKeyDown(KeyCode.PageUp);
        bool pageDown = Input.GetKeyDown(KeyCode.PageDown);
        if (pageUp || pageDown)
        {
            userMoved = true;
            float currentSize = camera.orthographicSize;
            float newSize = currentSize;
            float amountToMove = 0.1f;
            newSize += pageDown ? amountToMove : -amountToMove;

            DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, newSize, 1);
        }

        bool left = Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.RightArrow);
        bool leftOrRight = left || right;
        if (leftOrRight)
        {
            userMoved = true;
            Vector3 currentPosition = camera.transform.position;
            Vector3 newPosition = currentPosition;
            float amountToMove = 0.1f;
            newPosition.x += left ? amountToMove : -amountToMove;
            camera.transform.DOMove(newPosition, 1f);
        }

	}
}
