using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArrow : MonoBehaviour
{
    private Camera CenterEyeAnchor;
    [HideInInspector]
    public GameObject arrow;
   
    private GameObject[] cameras;
   

    private void Start()
    {

        cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        foreach (GameObject cam in cameras)
        {

            if (cam.name == "CenterEyeAnchor")
            {

                CenterEyeAnchor = cam.GetComponent<Camera>();
                
            }

        }
    }
    private void Update()
    {
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform == target)
            {
                arrow.SetActive(false);
            }
            else
            {
                arrow.SetActive(true);
            }
        }*/
       

        if (CenterEyeAnchor != null)
        {
            Vector3 viewportPoint = CenterEyeAnchor.WorldToViewportPoint(transform.position);
            
            if (viewportPoint.x >= 0.4 && viewportPoint.x <= 0.6 &&
                viewportPoint.y >= 0.2 && viewportPoint.y <= 0.9 &&
                viewportPoint.z > 0.4)
            {
                arrow.SetActive(false);
            }
            else
            {
                arrow.SetActive(true);
            }
        }
    }
}
