using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class DialogueManager : MonoBehaviour
{
    public Image dialogueBackGround;
    public TextMeshProUGUI speaker;
    public TextMeshProUGUI content;
    public Sprite[] backGroundCollections;
    public Animator[] npcAnimator;
    public DialoguePreset dialogue;
    public AudioSource audioSource;
    public AudioSource twinBGMSource;
    public AudioClip twinBGM;
    public FirstPersonInteractionSystem fpiSystem;
    public LevelManger_01 levelController;
    public LiveTwinController playerController;

    private int dialogueCount;
    private int dialougeCountMax;
    private bool dialougeActive = false;
    private Animator lastAnimator;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireDialogue();
        }
        #if UNITY_EDITOR
        if (Input.GetKeyDown("i"))
        {
            LoadDialogue();
        }
        #endif
    }

    private void FireDialogue()
    {
        if (dialogueCount==dialougeCountMax)
        {
            dialogueBackGround.gameObject.SetActive(false);
            dialougeActive = false;
            fpiSystem.interactLock = false;
            playerController.MovementOn = true;
            
            if (lastAnimator!=null)
            {
                lastAnimator.SetInteger("Stop",1);
                lastAnimator = null;
            }

            if (levelController!=null)
            {
                levelController.DialogueComplete();
            }
        }
        if (dialougeActive)
        {
            
            //npcAnimator[getBackGroundNum(dialogueCount)].SetTrigger(getAnimation(dialogueCount));
            newAnimation();
            newAudioClip(dialogueCount);
            speaker.text = getSpeaker(dialogueCount);
            content.text = getDialogueContent(dialogueCount);
            dialogueBackGround.sprite = backGroundCollections[getBackGroundNum(dialogueCount)];
            
            dialogueCount++;
           
        }
    }

    private void newAudioClip(int index)
    {
        int length = dialogue.audioClips.Length;
        AudioClip result;
        if (index>= length)
        {
            result =  dialogue.audioClips[length - 1];
        }
        else
        {
            result = dialogue.audioClips[index];
        }

        if (result!=null)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(result);
        }

        
    }

    private void newAnimation()
    {
        Animator animator = npcAnimator[getAnimatorNum(dialogueCount)];
        if (animator!=null)
        {
            animator.SetTrigger(getAnimation(dialogueCount));

            animator.SetInteger("Stop",0);   
            
             
            
        }
        if (lastAnimator!=null)
        {
            lastAnimator.SetInteger("Stop",1);   
        }
        lastAnimator = animator;
    }
    
    private int getAnimatorNum(int index)
    {
        int length = dialogue.npcNums.Length;
        if (index>= length)
        {
            return dialogue.npcNums[length - 1];
        }
        else
        {
            return dialogue.npcNums[index];
        }
    }
    private int getBackGroundNum(int index)
    {
        int length = dialogue.npcNums.Length;
        int result;
        if (index>= length)
        {
            result =  dialogue.npcNums[length - 1];
        }
        else
        {
            result = dialogue.npcNums[index];
        }

        if (result<=2)
        {
            return result;
        }

        return 2;
    }
    
    
    
    private string getSpeaker(int index)
    {
        int length = dialogue.speaker.Length;
        if (index>= length)
        {
            return dialogue.speaker[length - 1];
        }
        else
        {
            return dialogue.speaker[index];
        }
    }
    
    private string getDialogueContent(int index)
    {
        int length = dialogue.dialogues.Length;
        if (index>= length)
        {
            return dialogue.dialogues[length - 1];
        }
        else
        {
            return dialogue.dialogues[index];
        }
    }
    
    private string getAnimation(int index)
    {
        int length = dialogue.animations.Length;
        if (index>= length)
        {
            return dialogue.animations[length - 1];
        }
        else
        {
            return dialogue.animations[index];
        }
    }

    public void LoadDialogue()
    {
        playerController.MovementOn = false;
        dialogueBackGround.gameObject.SetActive(true);
        dialougeCountMax = dialogue.dialogues.Length;
        dialogueCount = 0;
        dialougeActive = true;
        fpiSystem.interactLock = true;
        
        if (getBackGroundNum(0)==1)
        {
            twinBGMSource.Stop();
            twinBGMSource.PlayOneShot(twinBGM);
        }
        
        
        FireDialogue();
    }
}
