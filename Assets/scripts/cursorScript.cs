using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{
    private Vector3 position;
    public Vector3 finalPosition;
    public Vector3 originPos;

    float xDif;
    float yDif;

    public float touchRadius = 90.01163f;

    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        // Position used for the cursor.
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        originPos = this.transform.parent.position;


        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Stationary)
            {
                //gets touch pos
                Vector2 pos = touch.position;

                //translates touch pos to unity
                pos = Camera.main.ScreenToWorldPoint (new Vector2 (pos.x, pos.y));
                position = new Vector3(pos.x, pos.y, 0.0f);

                //Debug.Log(Vector3.Distance(this.transform.parent.position, pos));
                if (Vector3.Distance(this.transform.parent.position, pos) < touchRadius)
                {
                    Vector3 vecDif = new Vector3(xDif, yDif, 0.0f);
                    finalPosition = originPos + -vecDif;
                }
            }

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                //gets touch pos
                Vector2 pos = touch.position;

                //translates touch pos to unity
                pos = Camera.main.ScreenToWorldPoint (new Vector2 (pos.x, pos.y));
                position = new Vector3(pos.x, pos.y, 0.0f);

                //checks if its within range of the joystick
                //Debug.Log(Vector3.Distance(this.transform.parent.position, pos));
                if (Vector3.Distance(this.transform.parent.position, pos) < touchRadius)
                {
                    //positions the cursor.
                    transform.position = position;
                    finalPosition = position;

                    xDif = this.transform.parent.position.x - finalPosition.x;
                    yDif = this.transform.parent.position.y - finalPosition.y;
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
