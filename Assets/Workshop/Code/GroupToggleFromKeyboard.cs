using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class GroupToggleFromKeyboard : MonoBehaviour {

    bool value = true;
    public int offset = -360;
    public float speed = 1f;
    CanvasGroup group;

	void Start () {
        group = GetComponent<CanvasGroup>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Toggle();
        }
	}

    void Toggle()
    {
        value = !value;

        if (!value)
        {
            group.DOFade(0f, speed);
        }
        else
        {
            group.DOFade(1f, speed);
        }
    }
}
