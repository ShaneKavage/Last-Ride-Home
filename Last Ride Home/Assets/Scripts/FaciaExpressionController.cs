using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaciaExpressionController : MonoBehaviour
{
    public int faceNum=0;
    public MeshRenderer meshRenderer;
    public Texture2D[] expressions;

    private int currentFace=0;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown("1"))
        {
            Laugh();
        }

        if (Input.GetKeyDown("2"))
        {
            Angry();
        }

        if (Input.GetKeyDown("3"))
        {
            PopUP();
        }

        
        
        
        #endif
        ChangeFace();
    }

    private void ChangeFace()
    {
        if (currentFace!=faceNum)
        {
            currentFace = faceNum;
            meshRenderer.material.mainTexture = expressions[currentFace];
        }
    }

//    private void OnValidate()
//    {
//        ChangeFace();
//    }

    public void Laugh()
    {
        animator.SetTrigger("Laugh");
    }

    public void Angry()
    {
        animator.SetTrigger("Angry");
    }

    public void Surprise()
    {
        
    }

    public void PopUP()
    {
        animator.SetTrigger("PopUp");
    }

   
}
