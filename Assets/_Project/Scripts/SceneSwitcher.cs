using UnityEngine;
using UnityEngine.SceneManagement;

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
                int nextLevel = SceneManager.GetActiveScene().buildIndex;
                nextLevel++;
                if (nextLevel >= SceneManager.sceneCountInBuildSettings)
                {
                    nextLevel = 0;
                }
                SceneManager.LoadScene(nextLevel);
            }

            if (Input.GetKeyDown(keyPrevious))
            {
                // Decrement Scene
                int nextLevel = SceneManager.GetActiveScene().buildIndex;
                nextLevel--;
                if (nextLevel < 0)
                {
                    nextLevel = SceneManager.sceneCountInBuildSettings - 1;
                }
                SceneManager.LoadScene(nextLevel);
            }

	    }

    }

}