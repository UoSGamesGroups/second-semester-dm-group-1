using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Purchasable_Shop : MonoBehaviour
{

    protected enum EPurchasableState
    {
        Waiting,
        Moving,
        Placed,
        Active
    }

    private SpriteRenderer mSpriteRenderer;
    [SerializeField]
    private Sprite mBlueArtwork, mRedArtwork;

    protected EPurchasableState mPurchasedState;

    protected Vector2 mStartPos;
    protected Vector2 mFingerOffset;

    [SerializeField]
    protected Purchasable_Field mFieldVersion;

    public EPlayer mPlayerColour;

    // Use this for initialization
    void Start ()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();

        switch (mPlayerColour)
        {
            case EPlayer.BLUE:
                mSpriteRenderer.sprite = mBlueArtwork;
                break;
            case EPlayer.RED:
                mSpriteRenderer.sprite = mRedArtwork;
                break;
            default:
                break;
        }

        mStartPos = transform.position;
        mPurchasedState = EPurchasableState.Waiting;
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    #region Touch Methods
    void OnTouchBegin(Vector2 pos)
    {
        mFingerOffset = (Vector2)transform.position - pos;
    }

    protected void OnTouchMove(Vector2 pos)
    {
        transform.position = pos + mFingerOffset;
    }

    protected void OnTouchExit(Vector2 pos)
    {
        Purchasable_Field fieldObject = Instantiate(mFieldVersion, transform.position, Quaternion.identity);
        mFieldVersion.Init(mPlayerColour);

        transform.position = mStartPos;
        gameObject.SetActive(false);
    }
    #endregion

}
