using UnityEngine;
using System.Collections;

/**
 * Use Keyboard to switch between all scenes in build
 * Wraps from last Scene back to first and vice versa
 */

namespace mmm {

    public class SceneSwitcher : MonoBehaviour {

        public KeyCode keyNext = KeyCode.Equals;
        public KeyCode keyPrevious = KeyCode.Minus;
	
	    void Update () {

            // Trigger Scene Switch with Keyboard Commands
            if (Input.GetKeyDown(keyNext))
            {
                // Increment Scene
                int nextLevel = Application.loadedLevel;
                nextLevel++;
                if (nextLevel >= Application.levelCount)
                {
                    nextLevel = 0;
                }
                Application.LoadLevel(nextLevel);
            }

            if (Input.GetKeyDown(keyPrevious))
            {
                // Decrement Scene
                int nextLevel = Application.loadedLevel;
                nextLevel--;
                if (nextLevel < 0)
                {
                    nextLevel = Application.levelCount;
                }
                Application.LoadLevel(nextLevel);
            }

	    }

    }

}