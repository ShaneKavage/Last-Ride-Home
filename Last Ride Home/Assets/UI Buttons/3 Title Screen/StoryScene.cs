using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour
{
    public void loadStory()
    {
        SceneManager.LoadScene("StoryScene");
    }
}
