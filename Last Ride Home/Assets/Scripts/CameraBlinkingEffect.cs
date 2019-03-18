using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class CameraBlinkingEffect : MonoBehaviour
{
//    public Shader replacementShader;
//
//    private void OnEnable()
//    {
//        if (replacementShader!=null)
//        {
//            GetComponent<Camera>().SetReplacementShader(replacementShader,"RenderType");
//        }
//    }
//
//    private void OnDisable()
//    {
//        GetComponent<Camera>().ResetReplacementShader();
//    }

    public Material eyeBlink;

    public void setBalckFade(float blackValue)
    {
        eyeBlink.SetFloat("_BlackFade",blackValue);
    }
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        //throw new System.NotImplementedException();
        Graphics.Blit(src, dest, eyeBlink);
        
    }
}
