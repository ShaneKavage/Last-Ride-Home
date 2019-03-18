using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : InteractableObject
{
    private Animator _animator;
    public bool interactble;
    public GameObject doorcollider;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        _animator.SetTrigger("Open");
        
    }

    public override void Interact(Vector3 interactSrc)
    {
        Interact();
    }

    private void Update()
    {
        if (interactble)
        {
            doorcollider.layer = LayerMask.NameToLayer("NPC");
        }
        else
        {
            doorcollider.layer = LayerMask.NameToLayer("Default");
        }
    }
}
