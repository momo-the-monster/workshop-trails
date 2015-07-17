using UnityEngine;

namespace pdxcc
{

    public class FillScreen : MonoBehaviour
    {

        public float aspectRatio = 1f;

        void Update()
        {
            OrthoUpdate();
        }

        void OrthoUpdate()
        {
            Camera cam = Camera.main;
            Vector3 worldMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 worldMax = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));
            float width = worldMax.x - worldMin.x;
            float height = worldMax.y - worldMin.y;
            Vector3 scale = new Vector3(width, height, 0f);

            if (width >= height)
                scale.y = width / aspectRatio;
            else
                scale.x = height * aspectRatio;

            transform.localScale = scale;
        }
    }
}