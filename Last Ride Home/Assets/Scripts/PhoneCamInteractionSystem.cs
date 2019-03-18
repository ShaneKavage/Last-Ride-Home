using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCamInteractionSystem : MonoBehaviour
{
    public Transform cam;
    public LayerMask targetLayer;
    public float castDistance = 1.4f;
    public GameObject interactLable;
    
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position,cam.forward,out hit,castDistance,targetLayer))
        {
            interactLable.SetActive(true);
//            interactLable.transform.position =
//                hit.point - cam.forward * Vector3.Distance(hit.point, cam.position) * 0.2f;
//            interactLable.transform.LookAt(cam.position);
            
        }
        else
        {
            interactLable.SetActive(false);
        }
        
        
    }
}
