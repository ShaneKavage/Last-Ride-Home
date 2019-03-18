using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUIStartGame : MonoBehaviour
{
    public LevelManger_01 levelmanager;
    public GameObject[] disableList;

    public GameObject[] enableList;

    public void Work()
    {
        levelmanager.ResetLevelWithEffect(0);
        for (int i = 0; i < disableList.Length; i++)
        {
            disableList[i].SetActive(false);
        }
        
        for (int i = 0; i < enableList.Length; i++)
        {
            enableList[i].SetActive(true);
        }
        
    }
}
