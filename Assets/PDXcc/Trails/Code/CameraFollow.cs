using UnityEngine;
using System.Collections;

namespace pdxcc
{
    public class CameraFollow : MonoBehaviour
    {
        // Target for the camera to follow
        public Transform target;
        // Distance to maintain between camera and target
        public Vector3 offset;
        // How quickly to follow
        public float speed = 1f;

        void Update()
        {   
            // Get the position of the target, add the offset
            Vector3 targetPosition = target.position + offset;
            // Lerp between the current position and the target position using deltaTime for consistency
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}