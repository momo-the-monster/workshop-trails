using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace mmm
{

    public class AddForceFromKeyboard : MonoBehaviour {

        public float forceAmount = 1f;
        public ForceMode mode;
        public bool removeForceOnKeyup = true;
        Rigidbody body;


	    // Use this for initialization
	    void Start () {
            body = GetComponent<Rigidbody>();
	    }

        Vector3 GetRandomDirection()
        {
            Dictionary<string, Vector3> directions = new Dictionary<string, Vector3>();
            directions.Add("N", new Vector3(0, 1, 0));
            directions.Add("NE", new Vector3(1, 1, 0));
            directions.Add("E", new Vector3(1, 0, 0));
            directions.Add("SE", new Vector3(1, -1, 0));
            directions.Add("S", new Vector3(0, -1, 0));
            directions.Add("SW", new Vector3(-1, -1, 0));
            directions.Add("W", new Vector3(-1, 0, 0));
            directions.Add("NW", new Vector3(-1, 1, 0));

            List<string> keys = new List<string>(directions.Keys);
            string key = keys[Random.Range(0, keys.Count)];
            Vector3 result = directions[key];
            return result;
        }
	
	    // Update is called once per frame
	    void Update () {
            if (body != null)
            {

                float ogForce = forceAmount;
            //    forceAmount = forceAmount * Mathf.Lerp(1f, 1.1f, Random.value);

                // Mouse Press
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 force = GetRandomDirection() * forceAmount;
                    body.AddForce(force);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    body.velocity = Vector3.zero;
                    body.angularVelocity = Vector3.zero;
                }

                // Key Presses
                if (Input.GetKeyDown(KeyCode.W))
                {
                    body.AddForce(0, forceAmount, 0, mode);
                }                                    
                if (Input.GetKeyDown(KeyCode.S))
                {                                   
                    body.AddForce(0, -forceAmount, 0,mode);
                }                                    
                if (Input.GetKeyDown(KeyCode.A))
                {                                    
                    body.AddForce(-forceAmount, 0, 0,mode);
                }                                    
                if (Input.GetKeyDown(KeyCode.D))
                {                                   
                    body.AddForce(forceAmount, 0, 0, mode);
                }

                // Key Releases
                if (removeForceOnKeyup && Input.GetKeyUp(KeyCode.W))
                {
                    body.AddForce(0, -forceAmount, 0, mode);
                }
                if (removeForceOnKeyup && Input.GetKeyUp(KeyCode.S))
                {
                    body.AddForce(0, forceAmount, 0, mode);
                }
                if (removeForceOnKeyup && Input.GetKeyUp(KeyCode.A))
                {
                    body.AddForce(forceAmount, 0, 0, mode);
                }
                if (removeForceOnKeyup && Input.GetKeyUp(KeyCode.D))
                {
                    body.AddForce(-forceAmount, 0, 0, mode);
                }

                forceAmount = ogForce;
            }
	    }
    }

}