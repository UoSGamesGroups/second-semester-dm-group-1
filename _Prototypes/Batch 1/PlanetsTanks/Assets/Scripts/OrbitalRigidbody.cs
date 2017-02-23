using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class OrbitalRigidbody : MonoBehaviour
{
    private const float GRAVITY_CONSTANT = 80f;

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

    public void Init(PlanetaryObject gravityBody)
    {
        mGravityBody = gravityBody;
    }

    void FixedUpdate()
    {
        if (mGravityBody)
        {
            float distance;
            float forceScalar;
            Vector2 direction;
            Vector2 forceVector = Vector2.zero;

            for (int i = 0; i < Game.sBodies.Length; i++)
            {
                direction = Game.sBodies[i].transform.position - transform.position;
                distance = direction.magnitude;

                direction.Normalize();
                
                forceScalar = (GRAVITY_CONSTANT * mRigid.mass * mGravityBody.Mass) / (distance * distance);

                forceVector += forceScalar * direction;
            }

            mRigid.AddForce(forceVector * Time.fixedDeltaTime, ForceMode2D.Force);
            // Debug.Log("Gravity");
        }
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    PlanetaryObject other = collision.GetComponent<PlanetaryObject>();
    //    if (other != null)
    //    {
    //        mGravityBody = other;
    //    }
    //}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Destroy(this);
    }
}
