using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    public GameObject projectile;
    public LayerMask noCollide;

    public float minForceDistance = 0;
    [Range(0.0f, 4.0f)]
    public float maxForceDistance;
    [Range(0.0f, 10.0f)]
    public float forceMultiplier;

    [SerializeField]
    private PlayerHandle mPlayerHandle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (mPlayerHandle.HandleState)
        {
            case PlayerHandle.eHandleState.IDLE:
                break;
            case PlayerHandle.eHandleState.HELD:
                break;
            case PlayerHandle.eHandleState.RELEASED:
                FireProjectile();
                mPlayerHandle.HandleState = PlayerHandle.eHandleState.IDLE;
                mPlayerHandle.ReturnHandle();
                break;
            case PlayerHandle.eHandleState.RETURNING:
                break;
            default:
                break;
        }
    }

    private void FireProjectile()
    {
        // Direction to launch thing
        // Force to release it
        Vector2 shootLine = mPlayerHandle.transform.position - transform.position;
        float force = shootLine.magnitude;
        Mathf.Clamp(force, minForceDistance, maxForceDistance);
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        proj.GetComponent<Rigidbody2D>().AddForce(-shootLine.normalized * force * forceMultiplier, ForceMode2D.Impulse);
        StartCoroutine(WaitToMakeCollidable(proj));
    }

    private IEnumerator WaitToMakeCollidable(GameObject g)
    {
        LayerMask originalMask = g.layer;
        g.layer = 9;
        yield return new WaitForSeconds(1.0f);
        g.layer = originalMask;
    }
}
