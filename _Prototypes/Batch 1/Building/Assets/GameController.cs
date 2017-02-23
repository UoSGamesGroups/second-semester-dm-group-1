using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Camera mBottomCamera, mTopCamera;
    public StackingObject mCratePrefab;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))//create cube and drag at mouse's location
        {
            bool isBottom;
            Vector2 mousePos = Input.mousePosition;
            Vector2 spawnPos = new Vector2();
            if (mousePos.y > Screen.height / 2)
            {
                spawnPos = mTopCamera.ScreenToWorldPoint(mousePos);
                isBottom = false;
            }
            else
            {
                spawnPos = mBottomCamera.ScreenToWorldPoint(mousePos);
                isBottom = true;
            }
            StackingObject newCrate = Instantiate(mCratePrefab, spawnPos, Quaternion.identity);
            newCrate.Init(isBottom);

            Debug.Log(mousePos);

        }
	}
}
