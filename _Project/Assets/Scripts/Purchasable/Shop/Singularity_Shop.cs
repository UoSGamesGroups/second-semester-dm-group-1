using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singularity_Shop : Purchasable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTouchBegin(Vector2 pos)
    {
        mFingerOffset = (Vector2)transform.position - pos;
    }

    void OnTouchMove(Vector2 pos)
    {
        transform.position = pos + mFingerOffset;
    }

    void OnTouchExit(Vector2 pos)
    {
        Instantiate(mFieldVersion);
        Destroy(gameObject);
    }
}
