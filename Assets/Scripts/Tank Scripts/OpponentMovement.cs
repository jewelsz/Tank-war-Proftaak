using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    Vector3 TankPosition;
    Vector3 CannonRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // position from server
    public void incomingPosition()
    {
        transform.position = TankPosition;
    }

    public void incomingCannonRotation()
    {
        transform.forward = CannonRotation;
    }
}
