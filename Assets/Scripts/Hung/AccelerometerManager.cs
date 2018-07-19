using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateDirection
{
    NONE = 0,
    LEFT = 1,
    RIGHT = 2,
}

public class AccelerometerManager : MonoBehaviour {

    private static AccelerometerManager  instance;
    public static AccelerometerManager  Instance { get { return instance; } }

    private RotateDirection direction;




    private const float resistanceX = 0.3f;

    private void Start()
    {
        instance = this;
    }


    private void FixedUpdate()
    {
        Vector3 input = Input.acceleration;
        direction = RotateDirection.NONE;

        if (Mathf.Abs(input.x) > resistanceX)
            direction |= (input.x < 0) ? RotateDirection.LEFT : RotateDirection.RIGHT;        
    }


    public bool isRotateTo(RotateDirection dir)
    {
        int t1 = (int)direction;
        int t2 = (int)dir;
        return (t1 & t2) == t2;
    }

}
