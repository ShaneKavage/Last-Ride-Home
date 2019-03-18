using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneCredits : MonoBehaviour
{
    public void loadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void loadTitle()
    {
        SceneManager.LoadScene("StoryScene");
    }
}
