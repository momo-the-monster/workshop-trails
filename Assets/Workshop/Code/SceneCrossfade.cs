using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneCrossfade : MonoBehaviour
{
    public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
    private bool sceneStarting = true;      // Whether or not the scene is still fading in.
    private bool sceneEnding = false;
    public Graphic curtain;
    private int sceneToLoad;

    void Awake()
    {
        sceneStarting = true;
        sceneEnding = false;
    }

    void Update()
    {
        // If the scene is starting...
        if (sceneStarting)
            // ... call the StartScene function.
            StartScene();

        // If the scene is ending...
        if (sceneEnding)
            // ... call the EndScene function.
            EndScene();

        // Trigger EndScene with a Keyboard Shortcut
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals))
        {
            sceneToLoad = GetNextScene();
            sceneEnding = true;
        }

        if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.Underscore))
        {
            sceneToLoad = GetPreviousScene();
            sceneEnding = true;
        }
    }

    // Get the next scene, rolling over to 0 at the end
    int GetNextScene()
    {
        int result = Application.loadedLevel + 1;
        if (result >= Application.levelCount)
        {
            result = 0;
        }
        return result;
    }

    int GetPreviousScene()
    {
        int result = Application.loadedLevel - 1;
        if (result < 0)
        {
            result = Application.levelCount - 1;
        }
        return result;
    }

    void FadeToClear()
    {
        // Lerp the colour of the texture between itself and transparent.
        curtain.color = Color.Lerp(curtain.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        // Lerp the colour of the texture between itself and black.
        curtain.color = Color.Lerp(curtain.color, Color.black, fadeSpeed * Time.deltaTime);
    }


    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if (curtain.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the GUITexture.
            curtain.color = Color.clear;
            curtain.enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
        }
    }


    public void EndScene()
    {
        // Make sure the texture is enabled.
        curtain.enabled = true;

        // Start fading towards black.
        FadeToBlack();

        // If the screen is almost black...
        if (curtain.color.a >= 0.95f)
            // ... reload the level.
            Application.LoadLevel(sceneToLoad);
    }
}