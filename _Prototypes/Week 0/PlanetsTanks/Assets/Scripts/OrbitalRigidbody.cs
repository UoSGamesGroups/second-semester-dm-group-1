using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class OrbitalRigidbody : MonoBehaviour
{
    public Rigidbody2D mRigid;
    //[SerializeField]
    private PlanetaryObject mGravityBody = null;

    // Use this for initialization
    void Start()
    {
        mRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (mGravityBody)
        {
            float distance;

            Vector2 direction;
            direction = mGravityBody.transform.position - transform.position;
            distance = direction.magnitude;

            direction.Normalize();

            mRigid.AddForce(mRigid.mass * direction * mGravityBody.Gravity * Time.fixedDeltaTime, ForceMode2D.Force);
           // Debug.Log("Gravity");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlanetaryObject other = collision.GetComponent<PlanetaryObject>();
        if (other != null)
        {
            mGravityBody = other;
        }
    }



}
