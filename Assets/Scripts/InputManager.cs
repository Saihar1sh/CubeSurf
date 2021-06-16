using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingletonGeneric<InputManager>
{
    private Vector2 startTouch, swipeDelta;

    private bool isDragging = false;

    public Vector2 SwipeDelta { get => swipeDelta; }


    void Update()
    {
        Inputs();
        CalculateSwipeDistance();

    }

    private void Inputs()
    {
        #region PC Inputs
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }
        #endregion

        #region Touch Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }
        #endregion

    }

    private void Reset()        //Resetting the swipe distance
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }
    private void CalculateSwipeDistance()
    {
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            //calculating the distance of swipe performed
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }


    }
}

