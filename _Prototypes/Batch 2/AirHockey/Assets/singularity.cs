using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singularity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.back);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            //collision.transform.parent = transform;
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            springJoint.connectedAnchor = this gameObject;
            //collision.gameObject.GetComponent<DistanceJoint2D>().connectedBody = collision;
            collision.transform.parent = transform;
            //Release();
        }
    }
   void Release ()
    {
        //yield return new WaitForSeconds(5);
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
