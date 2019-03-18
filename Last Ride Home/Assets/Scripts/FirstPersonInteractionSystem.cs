using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonInteractionSystem : MonoBehaviour
{
    public Transform fisrtPersonCam;
    public LayerMask firstPersonTargetLayer;
    public float castDistance = 1.4f;
    public GameObject firstpersonInteractLable;
    [Header("PhoneCam")]
    public Transform cam;
    public LayerMask targetLayer;
    public GameObject interactLable;
    [Header("Others")] public bool interactLock;

    private InteractableObject _interactableObject;
    private Vector3 interactionSource;
    void LateUpdate()
    {
        if (interactLock)
        {
            return;
        }
        RaycastHit hit;
//        if (Physics.CapsuleCast(cam.position, Vector3.up * capsuleCastDistance + cam.position, capsuleCastRaduise,
//            cam.forward, out hit, capsuleCastDistance, targetLayer))
//        {
//            Debug.Log(hit.point);
//        }

        if (Physics.Raycast(fisrtPersonCam.position,fisrtPersonCam.forward,out hit,castDistance,firstPersonTargetLayer))
        {
            firstpersonInteractLable.SetActive(true);
            firstpersonInteractLable.transform.position =
                hit.point - fisrtPersonCam.forward * Vector3.Distance(hit.point, fisrtPersonCam.position) * 0.2f;
            firstpersonInteractLable.transform.LookAt(fisrtPersonCam.position);
            _interactableObject = hit.collider.GetComponent<InteractableObject>();
            //Get interact script
            if (_interactableObject==null)
            {
                _interactableObject = hit.collider.transform.parent.GetComponent<InteractableObject>();
                interactionSource = fisrtPersonCam.position;
            }

        }
        else
        {
            firstpersonInteractLable.SetActive(false);
            if (Physics.Raycast(cam.position,cam.forward,out hit,castDistance,targetLayer))
            {
                interactLable.SetActive(true);
                
                _interactableObject = hit.collider.GetComponent<InteractableObject>();
                if (_interactableObject==null)
                {
                    _interactableObject = hit.collider.transform.parent.GetComponent<InteractableObject>();
                    interactionSource = cam.position;
                }
            
            }
            else
            {
                interactLable.SetActive(false);
                _interactableObject = null;
            }
            
        }
        
        if (Input.GetKeyDown("e"))
        {
            if (_interactableObject!=null)
            {
                _interactableObject.Interact(interactionSource);
            }
        }
        
        
    }
}
