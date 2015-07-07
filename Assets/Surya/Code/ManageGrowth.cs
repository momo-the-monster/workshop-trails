using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class ManageGrowth : MonoBehaviour {

    //We make a static variable to our MusicManager instance
    public static ManageGrowth instance { get; private set; }

    [Range(0,20)]
    public float targetIntensity = 3f;
    public Transform container;
    public ObjectAttacher obj;
    public int numberToGrow = 20;
    private ObjectAttacher ogFirstObject;
    public float movementRange = 0f;
    public Camera camera;
    internal List<Light> lights;
    internal int numberOfObjects = 0;
    public float growSpeed = 1f;
    internal IsometricCameraControl cameraControl;

    public delegate void GameEvent();
    public static GameEvent OnRestart;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        lights = new List<Light>();
        lights.Add(obj.GetComponentsInChildren<Light>()[0]);
        cameraControl = camera.GetComponent<IsometricCameraControl>();
        ogCameraPosition = camera.transform.position;
        ogFirstObject = obj;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Grow();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GrowMany();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            Reset();
            GrowMany();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            RecenterCamera();
        }

        if (Input.GetKeyDown(KeyCode.W))
            GrowInDirection(0);
        if (Input.GetKeyDown(KeyCode.S))
            GrowInDirection(1);
        if (Input.GetKeyDown(KeyCode.A))
            GrowInDirection(2);
        if (Input.GetKeyDown(KeyCode.D))
            GrowInDirection(3);
        if (Input.GetKeyDown(KeyCode.Q))
            GrowInDirection(4);
        if (Input.GetKeyDown(KeyCode.E))
            GrowInDirection(5);


        if (Input.GetMouseButtonDown(0))
        {
            GrowMany();
        }
	}

    void Reset()
    {
        foreach (Transform item in container)
        {
            GameObject.Destroy(item.gameObject);
        }

        if (OnRestart != null)
            OnRestart();

        lights.Clear();
        numberOfObjects = 0;

        cameraControl.userMoved = false;

        obj = ogFirstObject;
    }

    internal Vector3 ogCameraPosition;

    void RecenterCamera()
    {
        List<GameObject> objects = new List<GameObject>();
        foreach (Transform item in container)
        {
            objects.Add(item.gameObject);
        }

        Vector3 newPosition = ogCameraPosition + FindCenterPoint(objects);
        camera.transform.DOMove(newPosition, 2f).SetEase(Ease.OutExpo);
    }

    void Grow()
    {

        ObjectAttacher obj = GrowOne();

        if (obj.anchors.Count > 1)
        {
            if (Random.value > 0.9f)
            {
                GrowOne();
            }
        }

        UpdateLightIntensity();
    }

    ObjectAttacher GrowOne()
    {
        GameObject g = obj.AttachObject(container);
        obj = g.GetComponent<ObjectAttacher>();
        Light light = g.GetComponentsInChildren<Light>()[0];
        light.intensity = 0;
        lights.Add(light);
        if (!cameraControl.userMoved)
            RecenterCamera();
        numberOfObjects++;
        return obj;
    }

    ObjectAttacher GrowInDirection(int direction)
    {
        GameObject g = obj.AttachObject(container, direction);
        obj = g.GetComponent<ObjectAttacher>();
        Light light = g.GetComponentsInChildren<Light>()[0];
        light.intensity = 0;
        lights.Add(light);
        if (!cameraControl.userMoved)
            RecenterCamera();
        numberOfObjects++;
        UpdateLightIntensity();
        return obj;
    }

    void GrowMany()
    {
        Sequence s = DOTween.Sequence();
        for (int i = 0; i < numberToGrow; i++)
        {
            s.AppendCallback(Grow).AppendInterval(growSpeed);
        }
    }

    public void UpdateLightIntensity()
    {
        // Get Target Intensity
        float intensity = targetIntensity / lights.Count;
        // Apply to Each Light
        foreach (Light light in lights)
        {
            float newIntensity = (Random.value > 0.7f) ? intensity * 0.5f : intensity;
            light.DOIntensity(intensity, growSpeed * 10);
        }
    }

    Vector3 FindCenterPoint(List<GameObject> objects) {
        if (objects.Count == 0)
         return Vector3.zero;
        if (objects.Count == 1)
            return objects[0].transform.position;
        var bounds = new Bounds(objects[0].transform.position, Vector3.zero);
        for (var i = 1; i < objects.Count; i++)
            bounds.Encapsulate(objects[i].transform.position); 
     return bounds.center;
    }
}
