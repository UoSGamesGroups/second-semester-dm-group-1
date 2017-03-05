using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandle : MonoBehaviour
{

    public enum eHandleState
    {
        IDLE, // Still at the base
        HELD, // Being moved by the player
        RELEASED, // Player has released the handle, shooting the projectyile
        RETURNING // Handle is returning to the base. Probably not needed unless animation.
    }

    private eHandleState mHandleState;

    #region Properties
    public eHandleState HandleState { get { return mHandleState; } set { mHandleState = value; } }
    #endregion

    // Use this for initialization
    void Start ()
    {
        mHandleState = eHandleState.IDLE;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ReturnHandle()
    {
        mHandleState = eHandleState.IDLE;
        transform.localPosition = Vector2.zero;
    }

    #region Touch Methods
    void OnTouchBegin(Vector2 pos)
    {
        mHandleState = eHandleState.HELD;
    }

    void OnTouchMove(Vector2 pos)
    {
        transform.position = pos;
    }

    void OnTouchExit(Vector2 pos)
    {
        mHandleState = eHandleState.RELEASED;
    }
    #endregion
}
