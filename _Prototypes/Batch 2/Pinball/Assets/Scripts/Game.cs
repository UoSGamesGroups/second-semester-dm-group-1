using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    [Header("Player paddles")]
    public Paddle p1Left;
    public Paddle p1Right;
    public Paddle p2Left;
    public Paddle p2Right;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            p1Left.Trigger();
        }
        else
        {
            p1Left.Idle();
        }
        if (Input.GetKey(KeyCode.X))
        {
            p1Right.Trigger();
        }
        else
        {
            p1Right.Idle();
        }


        if (Input.GetKey(KeyCode.Comma))
        {
            p2Left.Trigger();
        }
        else
        {
            p2Left.Idle();
        }
        if (Input.GetKey(KeyCode.Period))
        {
            p2Right.Trigger();
        }
        else
        {
            p2Right.Idle();
        }
    }
}
