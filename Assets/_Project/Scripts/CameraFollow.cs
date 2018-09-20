using UnityEngine;
using System.Collections;

/*
 * Smooth Camera Following
 */

namespace mmm
{
    public class CameraFollow : MonoBehaviour
    {
        // Target for the camera to follow
        public Transform target;

        // Distance to maintain between camera and target
        public Vector3 offset;

        // How quickly to follow
        public float speed = 1f;

        // Get offset from current position
        public bool useCurrentOffset = true;

        void Awake()
        {
            // Keep the current position of the camera in relation to the target
            if(useCurrentOffset)
                offset = transform.position - target.position;
        }

        void Update()
        {   
            // Get the position of the target, add the offset
            Vector3 targetPosition = target.position + offset;

            // Lerp between the current position and the target position using deltaTime for consistency
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}