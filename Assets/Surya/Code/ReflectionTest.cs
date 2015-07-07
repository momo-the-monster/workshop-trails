using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Helios.Prfrmr {

    public class ReflectionTest : MonoBehaviour {

        public ManageGrowth gObject;
        public GameObject container;
        public GameObject prefabSlider;
        internal List<UnityEngine.UI.ICanvasElement> elements;

	    // Use this for initialization
	    void Start () {
            Regenerate();
	    }

        void Regenerate()
        {

#if UNITY_EDITOR
            UnityEditor.SerializedObject so = new UnityEditor.SerializedObject(gObject);
            UnityEditor.SerializedProperty p = so.FindProperty("targetIntensity");
            
            foreach (var item in gObject.GetType().GetFields())
            {
                if (item.IsPublic)
                {
                    if (item.FieldType.Equals(typeof(System.Single))
                        || item.FieldType.Equals(typeof(System.Int32))
                        )
                    {
                        AddSlider(item);
                    }
                }
            }
#endif
        }


        void ClearElements()
        {
            foreach (var item in elements)
            {
                GameObject.Destroy(item.transform.gameObject);
            }
            elements.Clear();
        }

        void AddSlider(System.Reflection.FieldInfo info){
            // listen to Events
            GameObject sliderGameObject = GameObject.Instantiate(prefabSlider);
            sliderGameObject.transform.SetParent(container.transform);
            Slider gSlider = sliderGameObject.GetComponent<Slider>();
            gSlider.transform.localScale = Vector3.one;
            Text labelField = gSlider.gameObject.transform.FindChild("Label").GetComponent<Text>();
            labelField.text = info.Name;
            gSlider.onValueChanged.AddListener(OnTargetIntensityChanged);
        }

        void OnTargetIntensityChanged(float value)
        {
            gObject.targetIntensity = value;
            gObject.UpdateLightIntensity();
        }
	
	    // Update is called once per frame
	    void Update () {
	
	    }
    }

}