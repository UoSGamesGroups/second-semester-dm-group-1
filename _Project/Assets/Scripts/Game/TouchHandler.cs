using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* https://www.youtube.com/watch?v=SrCUO46jcxk */

public class TouchHandler : MonoBehaviour
{

    public LayerMask touchLayer;

    private List<GameObject> mCurrentTouches;
    private GameObject[] mPreveousTouches;

	// Use this for initialization
	void Start ()
    {
        mCurrentTouches = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update ()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {

            mPreveousTouches = new GameObject[mCurrentTouches.Count];
            mCurrentTouches.CopyTo(mPreveousTouches);
            mCurrentTouches.Clear();

            Vector2 wTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            GameObject overlap;
            Collider2D coll;

            int frame = Time.frameCount;

            if ((coll = Physics2D.OverlapPoint(wTouchPos, touchLayer)) != null)
            {
                overlap = coll.gameObject;
                mCurrentTouches.Add(overlap);

                if (Input.GetMouseButtonDown(0))
                {
                    overlap.SendMessage("OnTouchBegin", wTouchPos, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButton(0))
                {
                    overlap.SendMessage("OnTouchMove", wTouchPos, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    overlap.SendMessage("OnTouchExit", wTouchPos, SendMessageOptions.DontRequireReceiver);
                }
            }

            foreach (GameObject g in mPreveousTouches)
            {
                if (!mCurrentTouches.Contains(g))
                {
                    g.SendMessage("OnTouchCancel", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
#endif
        if (Input.touchCount > 0)
        {

            mPreveousTouches = new GameObject[mCurrentTouches.Count];
            mCurrentTouches.CopyTo(mPreveousTouches);
            mCurrentTouches.Clear();

            foreach (Touch currentTouch in Input.touches)
            {

                GameObject overlap;

                Vector2 wTouchPos = Camera.main.ScreenToWorldPoint(currentTouch.position);

                if (overlap = Physics2D.OverlapPoint(wTouchPos, touchLayer).gameObject)
                {
                    mCurrentTouches.Add(overlap);


                    switch (currentTouch.phase)
                    {
                        case TouchPhase.Began:
                            overlap.SendMessage("OnTouchBegin", wTouchPos, SendMessageOptions.DontRequireReceiver);
                            break;
                        case TouchPhase.Moved:
                            overlap.SendMessage("OnTouchMove", wTouchPos, SendMessageOptions.DontRequireReceiver);
                            break;
                        case TouchPhase.Stationary:
                            overlap.SendMessage("OnTouchStay", wTouchPos, SendMessageOptions.DontRequireReceiver);
                            break;
                        case TouchPhase.Ended:
                            overlap.SendMessage("OnTouchExit", wTouchPos, SendMessageOptions.DontRequireReceiver);
                            break;
                        case TouchPhase.Canceled:
                            overlap.SendMessage("OnTouchCancel", wTouchPos, SendMessageOptions.DontRequireReceiver);
                            break;
                        default:
                            break;
                    }
                }
            }

            foreach (GameObject g in mPreveousTouches)
            {
                if (!mCurrentTouches.Contains(g))
                {
                    g.SendMessage("OnTouchCancel", SendMessageOptions.DontRequireReceiver);
                }
            }

        }
    }
}
