using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool readyToIntreacte;
     public virtual void Interact()
    {
        
    }

     public virtual void Interact(Vector3 interactSrc)
     {
         
     }
}
