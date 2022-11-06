using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{
    private Vector3 position;
    public Vector3 finalPosition;
    public Vector3 originPos;

    public float touchRadius = 90.01163f;

    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        // Position used for the cube.
        position = transform.position;
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                //gets touch pos
                Vector2 pos = touch.position;

                //translates touch pos to unity
                pos = Camera.main.ScreenToWorldPoint (new Vector2 (pos.x, pos.y));
                position = new Vector3(pos.x, pos.y, 0.0f);

                //checks if its within range of the joystick
                if (Vector3.Distance(originPos, pos) < touchRadius)
                {
                    //positions the cursor.
                    transform.position = position;
                    finalPosition = position;
                }
            }
        }
        else
        {
            //if not touching return to origin
            transform.position = originPos;
            position = originPos;
            finalPosition = originPos;
        }
    }
}
