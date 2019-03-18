using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneRotation : MonoBehaviour
{
    // The target marker.
    public Transform target;
    
    
    // Angular speed in radians per sec.
    

    void LateUpdate()
    {
        transform.LookAt(target);
        transform.Rotate(Vector3.up,180f);
//        Vector3 targetDir = target.position - transform.position;
//
//        // The step size is equal to speed times frame time.
//        float step = speed * Time.deltaTime;
//
//        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
//        Debug.DrawRay(transform.position, newDir, Color.red);
//
//        // Move our position a step closer to the target.
//        
//        Vector3 newrotation = Quaternion.LookRotation(newDir).eulerAngles;
//        newrotation.y = newrotation.y-180;
//        transform.rotation = Quaternion.Euler(newrotation);
    }
}
