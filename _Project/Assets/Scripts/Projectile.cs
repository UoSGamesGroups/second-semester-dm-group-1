using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float mDamage = 1.0f;
    private ushort mPlayerID;
    

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
}
