using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;
using static Hand_Find_Objects;
using UnityEngine.UI;


public class OneHandGrabSeter : MonoBehaviour
{
    public GrabHandPos hand = GrabHandPos.Left;
    public bool oneHand;
    public GameObject canvas;
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
        if(!oneHand)
        {
            canvas.SetActive(false);
        }
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
                    if (!canvas.activeInHierarchy)
                    {
                        canvas.SetActive(true);

                    }

                    Debug.Log("Disabled");
                    
                }
                else if (hand == GrabHandPos.Left && hand_.hand == GrabHand.Left || hand == GrabHandPos.Right && hand_.hand == GrabHand.Right)
                {
                    Grabbable.enabled = true;
                    interactable.enabled = true;
                    canvas.SetActive(false);
                    Debug.Log("enabled");

                }
            }
        }
        

    }
    private void OnTriggerExit(Collider other)
    {

        if ( hand_.hand == GrabHand.Left || hand_.hand == GrabHand.Right)
        {
            if(!canvas.activeInHierarchy)
            {
                canvas.SetActive(true);

            }

        }
    }
}
