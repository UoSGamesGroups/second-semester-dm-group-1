using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController mSingleton;
    public static float GravityConstant = 0.01f;

	// Use this for initialization
	void Start ()
    {
        if (mSingleton == null)
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
