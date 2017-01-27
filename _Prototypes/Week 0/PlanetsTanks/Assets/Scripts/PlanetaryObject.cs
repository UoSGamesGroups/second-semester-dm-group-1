using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryObject : MonoBehaviour {

    [SerializeField]
    private float mGravity;

    public float Gravity { get { return mGravity; ; } set { mGravity = value; } }

    // Use this for initialization
    void Start ()
    {
        
    }
    
    // Update is called once per frame
    void Update ()
    {
        
    }
}
