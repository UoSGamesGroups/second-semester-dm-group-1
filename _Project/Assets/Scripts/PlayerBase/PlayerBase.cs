using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    [Header("Projectile")]
    [Tooltip("Projectile Prefab")]
    public GameObject projectile;
    [Tooltip("Should be set to \"NoCollide\", Used for letting the projectile ignore the base on spawning.")]
    public LayerMask noCollide;
    public Color tintColor = new Color( 1.0f, 1.0f, 1.0f, 1.0f );

    [Header("Touch Firing")]
    [Range(0.0f, 1.0f)]
    public float minForceDistance = 0;
    [Range(1.0f, 4.0f)]
    public float maxForceDistance;
    [Range(0.0f, 10.0f)]
    public float forceMultiplier;

    [SerializeField, Tooltip("Collider with \"TouchOnly\" layer")]
    private PlayerHandle mPlayerHandle;

    private LineRenderer mLineRenderer;

    // Use this for initialization
    void Start()
    {
        mLineRenderer = GetComponent<LineRenderer>();
        mLineRenderer.startColor = tintColor;
        mLineRenderer.endColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        switch (mPlayerHandle.HandleState)
        {
            case PlayerHandle.eHandleState.IDLE:
                mLineRenderer.enabled = false;
                break;
            case PlayerHandle.eHandleState.HELD:
                mLineRenderer.enabled = true;
                DrawFireLine();
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

    private void DrawFireLine()
    {
        Vector2 differance = transform.position - mPlayerHandle.transform.position;

        float length = differance.magnitude;
        Vector2 direction = differance.normalized;

        length = Mathf.Clamp(length, minForceDistance, maxForceDistance);
        mLineRenderer.SetPosition(0, transform.position);
        mLineRenderer.SetPosition(1, transform.position + (Vector3)(direction * length));
    }

    private void FireProjectile()
    {
        // Direction to launch thing
        // Force to release it
        Vector2 differance = transform.position - mPlayerHandle.transform.position;

        Vector2 direction = differance.normalized;
        float Length = Length = Mathf.Clamp(differance.magnitude, minForceDistance, maxForceDistance);

        GameObject spawnedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(direction * Length * forceMultiplier, ForceMode2D.Impulse);
        spawnedProjectile.GetComponent<SpriteRenderer>().color = tintColor;
        StartCoroutine(WaitToMakeCollidable(spawnedProjectile));
    }

    private IEnumerator WaitToMakeCollidable(GameObject g)
    {
        LayerMask originalMask = g.layer;
        g.layer = 9;
        yield return new WaitForSeconds(1.0f);
        g.layer = originalMask;
    }
}
