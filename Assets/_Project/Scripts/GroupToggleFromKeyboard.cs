using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

/*
 * Fades a CanvasGroup Element In and Out via Keyboard Command
 */

namespace mmm
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GroupToggleFromKeyboard : MonoBehaviour
    {
        // Inspectable Properties
        public KeyCode trigger = KeyCode.Space;
        public float speed = 1f;

        // Internal Properties
        bool value = true;
        CanvasGroup group;

        // Cache CanvasGroup on Start
        void Start()
        {
            group = GetComponent<CanvasGroup>();
        }

        // Detect Keyboard Input
        void Update()
        {
            if (Input.GetKeyDown(trigger))
            {
                Toggle();
            }
        }
        
        // Fade alpha of CanvasGroup in/out
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

}