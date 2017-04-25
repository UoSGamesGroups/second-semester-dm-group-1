using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{

    [Header("Projectile")]
    [Tooltip("Projectile Prefab")]
    public Projectile projectile;
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

    [Header("Gameplay")]
    private float mHP;
    private float mMaxHP = 5.0f;
    [SerializeField, Tooltip("Base's unique PlayerID\n For working with damage and such")]
    private ushort mPlayerID;

    [Header("Debug")]
    public Text mHPText;

    [SerializeField, Tooltip("Collider with \"TouchOnly\" layer")]
    private PlayerHandle mPlayerHandle;

    private SpriteRenderer mSpriteRenderer;
    private LineRenderer mLineRenderer;

    public ushort PlayerID { get { return mPlayerID; } }

    // Use this for initialization
    void Start()
    {
        mLineRenderer = GetComponent<LineRenderer>();
        mLineRenderer.startColor = tintColor;
        mLineRenderer.endColor = Color.white;

        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mSpriteRenderer.color = tintColor;

        mHP = mMaxHP;
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
        DoDebug();
    }

    private void DoDebug()
    {
        mHPText.text = "HP " + mHP.ToString("N0");
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
        float Length = Mathf.Clamp(differance.magnitude, minForceDistance, maxForceDistance);

        Projectile spawnedProjectile = Instantiate<Projectile>(projectile, transform.position, Quaternion.identity);
        spawnedProjectile.Init(mPlayerID);
        spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(direction * Length * forceMultiplier, ForceMode2D.Impulse);
        spawnedProjectile.GetComponent<SpriteRenderer>().color = tintColor;
        StartCoroutine(WaitToMakeCollidable(spawnedProjectile.gameObject));
    }

    private IEnumerator WaitToMakeCollidable(GameObject g)
    {
        LayerMask originalMask = g.layer;
        g.layer = 9;
        yield return new WaitForSeconds(0.3f);
        g.layer = originalMask;
    }

    public void TakeDamage(float damage)
    {
        //Debug.Log("damage");
        mHP -= damage;
        win();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("bullet");
        foreach (GameObject enemy in enemies)
        GameObject.Destroy(enemy);
    }
    public void win()
    {
        if (mHP <= 0 && (PlayerID == 0))
        {
            SceneManager.LoadScene("finalRed");
        }
        else if (mHP <= 0 && (PlayerID == 1))
        {
            SceneManager.LoadScene("finalBlue");
        }
     }
}
