using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanet : MonoBehaviour
{
    public float mFireForce = 5;
    public OrbitalRigidbody mProjectile;
    public float mSpawnDistance = 1.0f;

    [SerializeField]
    private float mPlayerNumber;
    private PlanetaryObject mPlanetaryObject;

	// Use this for initialization
	void Start ()
    {
        mPlanetaryObject = GetComponent<PlanetaryObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        Vector2 direction;
        if (mPlayerNumber == 0)
        {
            direction = -(Input.GetAxis("Horizontal_L") * Vector2.right + Input.GetAxis("Vertical_L") * Vector2.up);
            if (Input.GetKeyUp(KeyCode.Joystick1Button4) && direction.magnitude > 0.1)
            {
                Vector2 spawnPos = (Vector2)transform.position + direction * mSpawnDistance;
                OrbitalRigidbody projectile = Instantiate(mProjectile, spawnPos, Quaternion.identity);
                projectile.Init(mPlanetaryObject);
                projectile.mRigid.velocity = direction * mFireForce;
            }
        }
        else if (mPlayerNumber == 1)
        {

            direction = -(Input.GetAxis("Horizontal_R") * Vector2.right + Input.GetAxis("Vertical_R") * Vector2.up);
            if (Input.GetKeyUp(KeyCode.Joystick1Button5) && direction.magnitude > 0.1)
            {
                Vector2 spawnPos = (Vector2)transform.position + direction * mSpawnDistance;
                OrbitalRigidbody projectile = Instantiate(mProjectile, spawnPos, Quaternion.identity);
                projectile.Init(mPlanetaryObject);
                projectile.mRigid.velocity = direction * mFireForce;
            }
        }
	}
}
