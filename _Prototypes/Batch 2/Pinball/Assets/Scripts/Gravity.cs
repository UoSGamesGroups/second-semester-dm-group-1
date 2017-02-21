using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    private float mBoardLength = 8.0f;
    private Rigidbody2D[] mGravityChildren;

    public Transform mBallTrans;
    public Gradient mGravityScales;

	// Use this for initialization
	void Start ()
    {
        GameObject[] children = GameObject.FindGameObjectsWithTag("GravityChild");
        mGravityChildren = new Rigidbody2D[children.Length];
        for (int i = 0; i < children.Length; i++)
        {
            mGravityChildren[i] = children[i].GetComponent<Rigidbody2D>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        SetGravity();
    }

    private void SetGravity()
    {
        float pos = mBallTrans.position.y;
        pos = Mathf.Clamp(pos, -mBoardLength, mBoardLength);
        pos += mBoardLength;
        pos /= mBoardLength * 2;

        float grav = mGravityScales.Evaluate(pos).grayscale;
        grav *= 2;
        grav -= 1.0f;
        foreach (var child in mGravityChildren)
        {
            child.gravityScale = grav;
        }
    }
}
