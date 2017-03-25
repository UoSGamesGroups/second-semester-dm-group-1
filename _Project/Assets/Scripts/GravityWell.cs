using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{

    [Tooltip("Attenuation of the gravity well.")]
    public Vector3 mAttn = new Vector3(0.0f, 0.0f, 2.0f);
    public float mMass = 50.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Vector2 GetAttraction(GameObject other)
    {
        Vector2 direction = transform.position - other.transform.position;
        float r = direction.magnitude;
        direction.Normalize();

        float top = GameController.GravityConstant * mMass;
        float bottom = mAttn.x + mAttn.y * r + mAttn.z * r * r;

        float force = top / bottom;

        //float force = GameController.GravityConstant * mMass / mAttn.x + mAttn.y * r + r * r * mAttn.z;
        return force * direction;
    }
}
