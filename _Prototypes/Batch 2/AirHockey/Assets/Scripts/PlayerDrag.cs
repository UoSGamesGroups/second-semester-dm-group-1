using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrag : MonoBehaviour {

    public float Health = 10;

    void OnMouseDrag()

    {

        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        point.z = gameObject.transform.position.z;

        gameObject.transform.position = point;

        Cursor.visible = false;


    }



    void OnMouseUp()

    {

        Cursor.visible = true;

    }

    void Update()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
}
