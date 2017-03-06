using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController mSingleton;

	// Use this for initialization
	void Start ()
    {
        if (mSingleton = null)
        {
            mSingleton = this;
        }
        else
        {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
