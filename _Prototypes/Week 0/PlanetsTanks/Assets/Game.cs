using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public static PlanetaryObject[] sBodies;

	// Use this for initialization
	void Start ()
    {
        sBodies = FindObjectsOfType<PlanetaryObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
