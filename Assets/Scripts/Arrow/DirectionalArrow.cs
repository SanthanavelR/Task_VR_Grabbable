using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [Header("[Add Target here thambi]")]
    [SerializeField]
    private Transform target;

    private TargetArrow targetArrow;
   
    private GameObject arrow;
   
   
    private float customX= 1.211312f;
    private Transform[] childArrow;
    private ArrowStatus arrowStatus;
  
    //------------------------------
    private float rotationSpeed = 10f;
    private float targetRotation = 90f;
    private float currentRotation = 0f;
    private float currentRotationdown = 0.1f;
    void Start()
    {
        
      //  arrowManager = GameObject.FindGameObjectWithTag("arrow");
        childArrow = gameObject.GetComponentsInChildren<Transform>();
        arrow = childArrow[1].gameObject;
        if (target != null)
        {
            target.AddComponent<TargetArrow>();
            targetArrow= target.GetComponent<TargetArrow>();
            targetArrow.arrow= arrow;
            arrowStatus = ArrowStatus.WeHaveArrow;
        }
        else
        {
            arrowStatus = ArrowStatus.weDontHaveArrow;
            Debug.LogError(" ERROR NAME:'Yousuf saapam' Put Arrow in " + gameObject.name +  " object, enna thambi ipudi ellam.?");
        }
        // childObjects[i] = childTransforms[i].gameObject;
    }

    // Update is called once per frame
    void Update()
    {
     if(arrowStatus==ArrowStatus.WeHaveArrow) 
        {
            Vector3 targetPosition = target.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }
       
    }

    public enum ArrowStatus
    {
        None,
        WeHaveArrow,
        weDontHaveArrow
    }
}
