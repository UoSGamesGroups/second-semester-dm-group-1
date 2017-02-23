using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class destructable : MonoBehaviour
{
    public int health = 3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet(clone)")
        {
            Destroy(gameObject);
        }
    }
}
