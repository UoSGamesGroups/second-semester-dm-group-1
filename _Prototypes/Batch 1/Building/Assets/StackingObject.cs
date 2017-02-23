using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StackingObject : MonoBehaviour
{

    private const float GRAVITY_SCALE = 1;
    private Rigidbody2D mRigid;

    void Awake()
    {
        mRigid = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init (bool isGravityDown)
    {
        mRigid.gravityScale = isGravityDown ? GRAVITY_SCALE : -GRAVITY_SCALE;
    }
}
