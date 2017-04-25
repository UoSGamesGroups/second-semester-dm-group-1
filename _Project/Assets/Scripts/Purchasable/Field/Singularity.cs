using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singularity : Purchasable_Field
{

    public int Uses = 0;
    private int MaxUses = 4;

    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Uses >= MaxUses)
        {
            Destroy(this);
            Destroy(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject)
        Uses++;
    }
}
