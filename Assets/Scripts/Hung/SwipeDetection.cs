using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection
{
    NONE = 0,
    LEFT = 1,
    RIGHT = 2,
    UP = 4,
    DOWN = 8,
}

public class SwipeDetection : MonoBehaviour {

    private static SwipeDetection instance;
    
    public static SwipeDetection Instance()
    {
        return instance;
    }

    private const float swipeResistanceX = 50.0f;
    private const float swipeResistanceY = 50.0f;
    public SwipeDirection direction;
    private Vector3 touchPosition;


    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        direction = SwipeDirection.NONE;
        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = touchPosition - Input.mousePosition;

            if(Mathf.Abs(deltaSwipe.x) > swipeResistanceX)
            {
                direction |= (deltaSwipe.x < 0) ? SwipeDirection.RIGHT : SwipeDirection.LEFT;
            }
            if(Mathf.Abs(deltaSwipe.y) > swipeResistanceY)
            {
                direction |= (deltaSwipe.y < 0) ? SwipeDirection.UP : SwipeDirection.DOWN;
            }
        }
    }

    public bool isSwiping(SwipeDirection dir)
    {
        int t1 = (int)dir;
        int t2 = (int)direction;
        int a = t1 & t2;
        return a == t1;
    }
}
