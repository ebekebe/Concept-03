using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    //DON'T FORGET TO RESET THE VALUES TO DEFAULT WHEN USING THIS CLASS
    //v1.01

    Vector2 startTouch, endTouch, swipeDelta;
    //Use swipeDelta for actual swipe vector, swipeDelta.magnitude for swipe length

    bool isPressing = false;

    public bool swipeLeft, swipeRight, swipeUp, swipeDown, tap, chargedTap = false;
    public float chargeTimer = 0f;

    public float higherSwipeThreshold;
    public float lowerSwipeThreshold;
    //For determining whether the input is a swipe or a tap

    public float chargeTimerThreshold;


#if UNITY_ANDROID || UNITY_IOS

    void Update()
    {
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isPressing = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isPressing = false;
                endTouch = Input.touches[0].position;
                if (swipeDelta.magnitude > higherSwipeThreshold)
                {
                    Debug.Log("Swiped");
                    float x = swipeDelta.x;
                    float y = swipeDelta.y;
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        if (x < 0)
                        {
                            Debug.Log("swipedLeft");
                            swipeLeft = true;
                        }

                        else
                        {
                            Debug.Log("swipedRight");
                            swipeRight = true;
                        }

                    }
                    else
                    {
                        if (y < 0)
                        {
                            Debug.Log("swipedDown");
                            swipeDown = true;
                        }

                        else
                        {
                            Debug.Log("swipedUp");
                            swipeUp = true;
                        }

                    }
                }
                else if (swipeDelta.magnitude < lowerSwipeThreshold)
                {
                    Debug.Log("tapped");
                    tap = true;
                }

            }
            if (isPressing)
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
            else
            {
                startTouch = swipeDelta = Vector2.zero;
            }


        }
    }
}
#endif
#if UNITY_STANDALONE

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressing = true;
            startTouch = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isPressing = false;
            endTouch = Input.mousePosition;

            #region SwipeCheck
            if (swipeDelta.magnitude > higherSwipeThreshold)
            {
                //Debug.Log("Swiped");
                float x = swipeDelta.x;
                float y = swipeDelta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x < 0)
                    {
                        Debug.Log("swipedLeft");
                        swipeLeft = true;
                    }

                    else
                    {
                        Debug.Log("swipedRight");
                        swipeRight = true;
                    }

                }
                else
                {
                    if (y < 0)
                    {
                        Debug.Log("swipedDown");
                        swipeDown = true;
                    }

                    else
                    {
                        Debug.Log("swipedUp");
                        swipeUp = true;
                    }

                }
            }
            #endregion

            else if (swipeDelta.magnitude < lowerSwipeThreshold)
            {
                if (chargeTimer >= chargeTimerThreshold)
                {
                    chargedTap = true;
                    Debug.Log("chargedTapped");
                }
                else
                {


                    tap = true;

                    Debug.Log("tapped");
                }

            }

        }

        if (isPressing)
        {
            swipeDelta = (Vector2)Input.mousePosition - startTouch;
            chargeTimer += Time.deltaTime;
        }
        else
        {
            startTouch = endTouch = swipeDelta = Vector2.zero;
        }
    }
}
#endif

