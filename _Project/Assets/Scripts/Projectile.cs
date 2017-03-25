﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float mDamage = 1.0f;
    private ushort mPlayerID;

    private Rigidbody2D mRigidbody;

    public void Start()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBase>() != null)
        {
            PlayerBase playerBase = collision.gameObject.GetComponent<PlayerBase>();
            if (playerBase.PlayerID != mPlayerID)
            {
                playerBase.TakeDamage(mDamage);
                Destroy(gameObject);
                Destroy(this);
            }
        }
    }

    public void Init(ushort playerID)
    {
        mPlayerID = playerID;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Gravity":
                mRigidbody.AddForce(collision.GetComponent<GravityWell>().GetAttraction(gameObject) * mRigidbody.mass);
                break;
            default:
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Gravity":
                // do the shootey thing
                break;
            default:
                break;
        }
    }
}