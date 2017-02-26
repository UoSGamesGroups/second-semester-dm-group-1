using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAsteroid : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public GameObject objectToInstantiate;
    private GameObject myCurrentObject;
    public Camera camera;
    float defaultZ = 0f;
    float objectMaximumDistance = 0f;
    float objectMinimumDistance = 0f;

    void Update()
    {
        /* if (Input.GetMouseButtonDown(0))
         {
             myCurrentObject = Instantiate(objectToInstantiate, camera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
             myCurrentObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

         }*/
        if (Input.GetMouseButton(0) && myCurrentObject)
        {
            myCurrentObject.transform.position = camera.ScreenToWorldPoint(Input.mousePosition);
            myCurrentObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (Input.GetMouseButtonUp(0) && myCurrentObject)
        {
            myCurrentObject = null;
        }
    }
      void OnMouseDown ()
            {
            if (Input.GetMouseButtonDown(0))
            {
                myCurrentObject = Instantiate(objectToInstantiate, camera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                myCurrentObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            }
        }
    }

