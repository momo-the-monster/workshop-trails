using UnityEngine;
using System.Collections;
using UnityEngine.UI;
    
/*
 * Listen for MomoMirror.OnSwitched Event
 * Update Text Component with new Blend Mode
 */
namespace mmm {

    [RequireComponent(typeof(Text))]
    public class SetLabelFromBlendmode : MonoBehaviour {

        internal Text field;

        // Add and Remove the Event Listener
        void OnEnable()  { Symmetry.OnSwitched += OnSwitched; }
        void OnDisable() { Symmetry.OnSwitched -= OnSwitched; }

        // Cache the Text Component
        void Start() { field = GetComponent<Text>(); }

        // Set Text on Event Trigger
        void OnSwitched(Symmetry.BlendModes b)
        {
            field.text = "Blend: " + b.ToString();
        }
    }

}