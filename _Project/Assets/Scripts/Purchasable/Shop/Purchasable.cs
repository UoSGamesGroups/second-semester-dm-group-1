using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchasable : MonoBehaviour
{

    protected enum EPurchasableState
    {
        Waiting,
        Moving,
        Placed,
        Active
    }

    protected EPurchasableState mPurchasedState;

    protected Vector2 mStartPos;
    protected Vector2 mFingerOffset;

    [SerializeField]
    protected GameObject mFieldVersion; 

    // Use this for initialization
    void Start ()
    {
        mStartPos = transform.position;
        mPurchasedState = EPurchasableState.Waiting;
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    #region Touch Methods
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
        var fieldObject = Instantiate(mFieldVersion, transform.position, Quaternion.identity);
        transform.position = mStartPos;
        gameObject.SetActive(false);
    }
    #endregion

}
