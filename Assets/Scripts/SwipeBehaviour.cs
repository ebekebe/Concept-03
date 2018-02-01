using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeBehaviour : MonoBehaviour
{


    Vector2 startTouch, swipeDelta;

    bool isDragging = false;
    public bool swipeLeft, swipeRight, swipeUp, swipeDown, tap = false;

    public float higherSwipeThreshold;
    public float lowerSwipeThreshold;

    void Update()
    {

#if UNITY_ANDROID
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                if (swipeDelta.magnitude > higherSwipeThreshold)
                {
                    Debug.Log("Swiped");
                    float x = swipeDelta.x;
                    float y = swipeDelta.y;
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        if (x < 0)
                            Debug.Log("swipedLeft");
                        else
                            Debug.Log("swipedRight");
                    }
                    else
                    {
                        if (y < 0)
                            Debug.Log("swipedDown");
                        else
                            Debug.Log("swipedUp");
                    }
                }
                else if (swipeDelta.magnitude < lowerSwipeThreshold)
                {
                    Debug.Log("Tapped");
                }

            }
            if (isDragging)
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
            else
                startTouch = swipeDelta = Vector2.zero;

        }
    }
}
#endif
#if UNITY_STANDALONE_WIN

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            startTouch = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;


            if (swipeDelta.magnitude > higherSwipeThreshold)
            {
                //Debug.Log("Swiped");
                float x = swipeDelta.x;
                float y = swipeDelta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                if (x < 0)
                    Debug.Log("swipedLeft");
                else
                    Debug.Log("swipedRight");
                    swipeRight = true;
                }
                else
                {
                    if (y < 0)
                        Debug.Log("swipedDown");
                    else
                        Debug.Log("swipedUp");
                }
            }
            else if (swipeDelta.magnitude < lowerSwipeThreshold)
            {
                tap = true;
            }

        }

        if (isDragging)
        {
            swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }
        else
            startTouch = swipeDelta = Vector2.zero;

    }
}
#endif

