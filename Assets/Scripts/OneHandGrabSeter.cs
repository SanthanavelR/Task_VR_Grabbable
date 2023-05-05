using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;
using static Hand_Find_Objects;
using UnityEngine.UI;


public class OneHandGrabSeter : MonoBehaviour
{
    public GrabHandPos hand = GrabHandPos.Left;
    public bool oneHand;
    Grabbable Grabbable;
    HandGrabInteractable interactable;
    Hand_Find_Objects hand_;
    public enum GrabHandPos
    {
        Left,
        Right
    }
    private void Start()
    {
        Grabbable = GetComponent<Grabbable>();
        interactable = GetComponent<HandGrabInteractable>();
       
    }
  
    private void OnTriggerEnter(Collider other)
    {
        hand_ = other.GetComponent<Hand_Find_Objects>();

        if (oneHand)
        {
            if (hand_ != null)
            {
                if (hand == GrabHandPos.Left && hand_.hand == GrabHand.Right || hand == GrabHandPos.Right && hand_.hand == GrabHand.Left)
                {
                    Grabbable.enabled = false;
                    interactable.enabled = false;
                   
                    Debug.Log("Disabled");
                    
                }
                else if (hand == GrabHandPos.Left && hand_.hand == GrabHand.Left || hand == GrabHandPos.Right && hand_.hand == GrabHand.Right)
                {
                    Grabbable.enabled = true;
                    interactable.enabled = true;
                    Debug.Log("enabled");

                }
            }
        }
        

    }
  
}
