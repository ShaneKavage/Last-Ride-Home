using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    public int AnomCounter;
    public bool Anom1BartenderTalk, Anom2GrandmaTalk, Anom2BartenderTalk,
        Anom3BartenderTalk, Anom3Childtalk, Anom3GrandmaTalk, BrotherFound, FoundKey;

    // Start is called before the first frame update
    void Start()
    {
        setAnomto0();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Set to this state at the beginning, or if you run out of time during anomaly 1
    public void setAnomto0()
    {
        AnomCounter = 0;
    }

    //Set to this state after the body is scanned or if you run out of time during anomaly 2
    public void setAnomTo1()
    {
        AnomCounter = 1;
        Anom1BartenderTalk = false;
        FoundKey = false;
    }

    //Set to this state after the glove is scanned or if you run out of time during anomaly 3
    public void setAnomTo2()
    {
        AnomCounter = 2;
        Anom3GrandmaTalk = false; Anom3BartenderTalk = false;

    }

    //Set to this state after the knife is scanned or if you run out of time during anomaly 4
    public void setAnomTo3()
    {
        AnomCounter = 3;
        Anom3BartenderTalk = false; Anom3Childtalk = false; Anom3GrandmaTalk = false;
    }

    //Set to this state after the donuts are scanned
    public void setAnomTo4()
    {
        AnomCounter = 4;
        BrotherFound = false;
    }

    /*
     As long as we do the switch approach, we dont need to reset every bool between states.
     Example - if you still have Anom3BartenderTalk set to true, but failed to complete that state and revert to anomaly 2,
     when you scan the glove in anomaly 2 and go back to anomaly 3, you will reset that variable.
     Talking to bartender during state 2 while Anom3BartendereTalk is true will not grab the incorrect dialogue
     */
    
}
