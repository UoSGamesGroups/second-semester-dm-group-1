using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanet : MonoBehaviour
{
    public float firefloat = 2;
    public OrbitalRigidbody mProjectile;
    public float mSpawnDistance = 1.0f;

    [SerializeField]
    private float mPlayerNumber;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(mPlayerNumber == 0)
        {
            Vector2 direction = -(Input.GetAxis("Horizontal_L") * Vector2.right + Input.GetAxis("Vertical_L") * Vector2.up);
            if (Input.GetKeyUp(KeyCode.Joystick1Button4) && direction.magnitude > 0.1)
            {
                Vector2 spawnPos = (Vector2)transform.position + direction * mSpawnDistance;
                OrbitalRigidbody projectile = Instantiate(mProjectile, spawnPos, Quaternion.identity);
                projectile.mRigid.velocity = direction * firefloat;
            }
        }
        else if (mPlayerNumber == 1)
        {

        }
	}
}
