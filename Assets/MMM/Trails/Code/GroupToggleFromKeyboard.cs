using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

namespace pdxcc
{
    public class GroupToggleFromKeyboard : MonoBehaviour
    {

        public KeyCode trigger = KeyCode.Space;
        public float speed = 1f;
        bool value = true;
        CanvasGroup group;

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