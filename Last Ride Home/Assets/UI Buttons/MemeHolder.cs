using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemeHolder : MonoBehaviour
{
    public Sprite[] memes = new Sprite[4];
    private int index = 0;

    public void Start()
    {
        setMeme();
    }

    public void nextMeme()
    {
        index++;
        if (index >= memes.Length)
        {
            index = 0;
        }
        setMeme();
    }

    private void setMeme()
    {
        GetComponent<SpriteRenderer>().sprite = memes[index];
    }
}
