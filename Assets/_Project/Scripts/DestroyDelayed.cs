using UnityEngine;
using System.Collections;

public class DestroyDelayed : MonoBehaviour {

    public void Trigger(float time)
    {
        Invoke("Die", time);
    }

    internal void Die()
    {
        Destroy(gameObject);
    }
}
