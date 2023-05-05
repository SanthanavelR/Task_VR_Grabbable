using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OneHandGrabSeter;

public class Hand_Find_Objects : MonoBehaviour
{
    OneHandGrabSeter OHGS;

    public GrabHand hand = GrabHand.Left;
    public enum GrabHand
    {
        Left,
        Right
    }

}
