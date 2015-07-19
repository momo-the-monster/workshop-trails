using UnityEngine;
using System.Collections;
using UnityEngine.UI;
    
namespace mmm {

    [RequireComponent(typeof(Text))]
    public class SetLabelFromBlendmode : MonoBehaviour {

        internal Text field;

        void OnEnable()  { MomoMirror.OnSwitched += OnSwitched; }
        void OnDisable() { MomoMirror.OnSwitched -= OnSwitched; }

        void Start() { field = GetComponent<Text>(); }

	    void OnSwitched ( MomoMirror.BlendModes b ) {
            field.text = "Blend: " + b.ToString();
        }
    }

}