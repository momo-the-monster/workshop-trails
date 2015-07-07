using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class ObjectAttacher : MonoBehaviour {

    public List<GameObject> prefabs;
    public List<ObjectAnchor> anchors;

	// Use this for initialization
	void Start () {
	    // Get All Anchors
        anchors = new List<ObjectAnchor>();
        foreach (var item in GetComponentsInChildren<ObjectAnchor>())
        {
            anchors.Add(item);
        }
        
        float range = ManageGrowth.instance.movementRange;
        if (range > 0)
        {
            float moveX = transform.localPosition.x + Random.Range(-range, range);
            float moveY = transform.localPosition.y + Random.Range(-range, range);
            float moveZ = transform.localPosition.z + Random.Range(-range, range);
            transform.DOLocalMove(new Vector3(moveX, moveY, moveZ), 2.5f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetDelay(Random.Range(0, 0.2f));
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject AttachObject(Transform container, int whichAnchor, int whichObject)
    {
        GameObject prefab = prefabs[whichObject % prefabs.Count];
        ObjectAnchor anchor = anchors[whichAnchor % anchors.Count];
        GameObject g = (GameObject)GameObject.Instantiate(prefab, anchor.transform.position, Quaternion.LookRotation(anchor.transform.forward, anchor.transform.up));
        g.transform.SetParent(anchor.transform);

        // Let's do some scale randomization!
        int newScaleIndex = Mathf.RoundToInt(Random.Range(0.5f, 3.5f));
        float newScale = newScaleIndex * 0.33f;
        //  float newScale = Random.Range(0.35f, 0.95f);
        g.name = "MMMObject";
        g.transform.SetParent(container);
        g.transform.localScale = Vector3.zero;
        g.transform.DOScale(new Vector3(newScale, newScale, newScale), ManageGrowth.instance.growSpeed);
        return g;
    }

    public GameObject AttachObject(Transform container)
    {
        int whichAnchor = Random.Range(0, anchors.Count);
        int whichObject = Random.Range(0, prefabs.Count);
        return AttachObject(container, whichAnchor, whichObject);
    }

    public GameObject AttachObject(Transform container, int whichAnchor)
    {
        int whichObject = Random.Range(0, prefabs.Count);
        return AttachObject(container, whichAnchor, whichObject);
    }

    internal bool RandomBool()
    {
        return Random.value > 0.5f;
    }
}
