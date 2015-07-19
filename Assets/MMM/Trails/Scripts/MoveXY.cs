using UnityEngine;
using System.Collections;

/**
 * Move the Transform of this object in X and Y
 * Via Keyboard Commands
 */
namespace mmm
{
    public class MoveXY : MonoBehaviour
    {

        public float speed = 100;
        public Vector3 velocity = Vector3.zero;

        // Input Keys - easy to switch via Inspector
        public KeyCode KeyUp = KeyCode.W;
        public KeyCode KeyDown = KeyCode.S;
        public KeyCode KeyLeft = KeyCode.A;
        public KeyCode KeyRight = KeyCode.D;

        void Update()
        {

            // Key Down Handlers - Add Velocities
            if (Input.GetKeyDown(KeyUp))
                velocity.y = speed;
            else if (Input.GetKeyDown(KeyDown))
                velocity.y = -speed;
            else if (Input.GetKeyDown(KeyLeft))
                velocity.x = -speed;
            else if (Input.GetKeyDown(KeyRight))
                velocity.x = speed;

            // Key Up Handlers - Zero Velocities
            if ((Input.GetKeyUp(KeyUp)) || Input.GetKeyUp(KeyDown))
                velocity.y = 0;
            if ((Input.GetKeyUp(KeyLeft)) || Input.GetKeyUp(KeyRight))
                velocity.x = 0;

            // Mouse Handler - Set / Zero Velocities
            if (Input.GetMouseButtonUp(0))
                velocity = Vector3.zero;
            if (Input.GetMouseButtonDown(0))
            {
                // set random velocity
                velocity.x = Random.value > 0.5 ? speed : -speed;
                velocity.y = Random.value > 0.5 ? speed : -speed;
            }

            // Move Transform with velocity
            transform.position += (velocity * Time.deltaTime);
        }
    }

}