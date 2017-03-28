using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton that will not destroy on loading.
public class PersistentObject : MonoBehaviour
{
    private static GameObject mSingleton;
	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        if (mSingleton == null)
        {
            mSingleton = gameObject;
        }
        else
        {
            Destroy(gameObject);
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
