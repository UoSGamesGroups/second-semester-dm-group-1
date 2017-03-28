using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float mShotVariance;

    [Range(0.0f, 15.0f)]
    public float mFireForce;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Vector2 GetBoost()
    {
        Vector2 outVec = new Vector2();
        float theta = Mathf.Deg2Rad * Random.Range(-mShotVariance, mShotVariance);

        float cos = Mathf.Cos(theta);
        float sin = Mathf.Sin(theta);

        outVec.x = transform.up.x * cos - transform.up.y * sin;
        outVec.y = transform.up.x * sin + transform.up.y * cos;

        return outVec * mFireForce;
    }

}
