using UnityEngine;

/*
 * Scale a Quad to fill an Orthographic Camera's Field of View
 * */

namespace mmm
{
    public class FillScreen : MonoBehaviour
    {
        // Change for non-square textures
        public float aspectRatio = 1f;

        // This class could be expanded to work for Perspective & Ortho cameras
        void Update()
        {
            OrthoUpdate();
        }

        void OrthoUpdate()
        {
            Camera cam = Camera.main;
            // Use the Viewport bounds as the target scale by converting it to World Space
            Vector3 worldMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 worldMax = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));
            float width = worldMax.x - worldMin.x;
            float height = worldMax.y - worldMin.y;
            Vector3 scale = new Vector3(width, height, 0f);

            // Find smaller dimension and scale it down proportionally to larger one
            if (width >= height)
                scale.y = width / aspectRatio;
            else
                scale.x = height * aspectRatio;

            // Apply new scale
            transform.localScale = scale;
        }
    }
}