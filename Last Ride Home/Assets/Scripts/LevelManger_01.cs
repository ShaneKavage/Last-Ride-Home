using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class LevelManger_01 : LevelManager
{
    [Header("Characters")] 
    public GameObject deadTwin;
    
    public GameObject[] childs;
    public GameObject[] moms;
    public GameObject[] grannys;
    public GameObject[] conductors;
    public GameObject[] bartenders;
    public GameObject[] pointOfIntrests;
    public GameObject finalQuestion;

    public GameObject closingBathRoomDoor;
    public GameObject openBathRoomDoor;
    
    [Header("Dialogues")] 
    public DialoguePreset[] openings;

    public DialoguePreset[] endings;
    public DialoguePreset backupEnding;
    

    [Header("Other Setting")] 
    public DialogueManager dialogueManager;
    public PhoneTimer phoneTimer;
    public LiveTwinController playerController;
    public CameraBlinkingEffect camBlink;
    
    
    private int currentLevel;

    private Vector3 orginalPosition;

    private Quaternion orginalRoation;
    //Blink To Change Level Stuff
    private bool blinking = false;
    private bool closingeye = true;
    private float blinkTime = 0f;

    private bool waitForDialogue = false;
    
    
    public float totalBlinkTime= 3f;
    private void Start()
    {
        //ResetLevel(0);
        orginalPosition = playerController.transform.position;
        orginalRoation = playerController.transform.rotation;
        playerController.enabled = false;
    }

    private void Update()
    {
        if (blinking)
        {
            if (closingeye)
            {
                blinkTime += Time.deltaTime;
                if (blinkTime>=totalBlinkTime/2)
                {
                    
                    closingeye = false;
                    playerController.transform.position = orginalPosition;
                    playerController.transform.rotation = orginalRoation;
                    ResetLevel(currentLevel);
                    deadTwin.SetActive(true);
                }
            }
            else
            {
                blinkTime -= Time.deltaTime;
                if (blinkTime<0)
                {
                    blinking = false;
                    camBlink.enabled = false;
                    playerController.enabled = true;
                }
            }
            camBlink.setBalckFade(blinkTime/(totalBlinkTime/2));
        }
        
        
#if UNITY_EDITOR
        if (Input.GetKeyDown("r"))
        {
            ResetLevelWithEffect(currentLevel);
        }
#endif
    }

    public void ResetLevelWithDialogue(int i)
    {
        waitForDialogue = true;
        dialogueManager.dialogue = endings[i - 1];
        dialogueManager.LoadDialogue();
        currentLevel = i;
    }
    public void ResetLevelWithEffect(int i)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerController.enabled = true;
        camBlink.enabled = true;
        camBlink.setBalckFade(0);
        blinkTime = 0;
        blinking = true;
        closingeye = true;
        currentLevel = i;
    }
    public void ResetLevel(int i)
    {
        currentLevel = i;
        loadAnimator(currentLevel);
        LoadGameObject(currentLevel);
        dialogueManager.dialogue = openings[currentLevel];
        dialogueManager.LoadDialogue();
        switch (currentLevel)
        {
            case 0:
                phoneTimer.ResetTime(6,29);
                break;
                //deadTwin.SetActive(false);
            case 1:
                phoneTimer.ResetTime(6, 27);
                break;
            case 2:
                phoneTimer.ResetTime(6,24);
                break;
            case 3:
                phoneTimer.ResetTime(6,22);
                break;
            case 4:
                phoneTimer.ResetTime(6,20);
                break;
            default:
                break;
        }
    }

    public override int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void DialogueComplete()
    {
        
        if (waitForDialogue)
        {
            waitForDialogue = false;
            if (currentLevel==4)
            {
                finalQuestion.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                playerController.enabled = false;
            }
            else
            {
                ResetLevelWithEffect(currentLevel);
            }
            
        }
    }

    public void fianlSceneWithBackup()
    {
        finalQuestion.SetActive(false);
        openings[3] = backupEnding;
        ResetLevelWithEffect(3);
    }

    public void BeatTheGame()
    {
        SceneManager.LoadScene("WinScene");
    }
    private void loadAnimator(int i)
    {
        dialogueManager.npcAnimator[2] = childs[i].GetComponent<Animator>();
        dialogueManager.npcAnimator[3] = moms[i].GetComponent<Animator>();
        dialogueManager.npcAnimator[4] = grannys[i].GetComponent<Animator>();
        dialogueManager.npcAnimator[5] = conductors[i].GetComponent<Animator>();
        dialogueManager.npcAnimator[6] = bartenders[i].GetComponent<Animator>();
    }

    private void LoadGameObject(int i)
    {
        if (i==0)
        {
            closingBathRoomDoor.SetActive(false);
            openBathRoomDoor.SetActive(true);
        }
        else
        {
            closingBathRoomDoor.SetActive(true);
            openBathRoomDoor.SetActive(false);
        }
        
        for (int j = 0; j < 5; j++)
        {
            childs[j].SetActive(false);
            moms[j].SetActive(false);
            bartenders[j].SetActive(false);
            conductors[j].SetActive(false);
            grannys[j].SetActive(false);       
            pointOfIntrests[j].SetActive(false);
        }
        childs[i].SetActive(true);
        moms[i].SetActive(true);
        bartenders[i].SetActive(true);
        conductors[i].SetActive(true);
        grannys[i].SetActive(true);
        pointOfIntrests[i].SetActive(true);
        
        childs[i].GetComponent<InteractableObject>().readyToIntreacte = true;
        moms[i].GetComponent<InteractableObject>().readyToIntreacte = true;
        bartenders[i].GetComponent<InteractableObject>().readyToIntreacte = true;
        conductors[i].GetComponent<InteractableObject>().readyToIntreacte = true;
        grannys[i].GetComponent<InteractableObject>().readyToIntreacte = true;
        
    }
    
}
