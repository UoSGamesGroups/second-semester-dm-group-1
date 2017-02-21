using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    private Animator mAnim;

	// Use this for initialization
	void Start ()
    {
        mAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void Trigger()
    {
        mAnim.SetBool("isTriggered", true);
    }

    public void Idle()
    {
        mAnim.SetBool("isTriggered", false);
    }
}
