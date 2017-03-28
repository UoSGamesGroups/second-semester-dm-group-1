using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInstructions_PlayerLineRender : MonoBehaviour
{

    public float mMaxLength = 120f;
    public float mDrawLength;

    LineRenderer mLineRenderer;

	// Use this for initialization
	void Start () {
        mLineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        mLineRenderer.SetPosition(1, new Vector3(0.0f, mMaxLength * mDrawLength, 0.0f));
	}
}
