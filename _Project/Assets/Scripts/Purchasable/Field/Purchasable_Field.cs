using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Purchasable_Field : MonoBehaviour
{
    public EPlayer mPlayerColour;

    [Tooltip("Artwork to put on the Artwork Child")]
    public Sprite mBlueArtwork, mRedArtwork;

    public SpriteRenderer mArtworkChild;

	// Use this for initialization
	protected void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init(EPlayer playerColour)
    {
        mPlayerColour = playerColour;
        switch (playerColour)
        {
            case EPlayer.BLUE:
                mArtworkChild.sprite = mBlueArtwork;
                break;
            case EPlayer.RED:
                mArtworkChild.sprite = mRedArtwork;
                break;
            default:
                break;
        }
    }
}
