using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGranny : InteractableObject
{
    public DialoguePreset[] defaultDialogue;
    public DialoguePreset[] essentialDialogue;
    public DialoguePreset[] exausteDialogue;
    public DialogueManager dialogueManager;
    public LevelManager levelmanager;
    public Transform headTransform;
    public bool essentialDialoguePlayed = false;

    public override void Interact(Vector3 interactSrc)
    {
        if (essentialDialogue[levelmanager.GetCurrentLevel()]!=null&& readyToIntreacte)
        {
            if (!essentialDialoguePlayed)
            {
                dialogueManager.dialogue = essentialDialogue[levelmanager.GetCurrentLevel()];
                dialogueManager.LoadDialogue();
                essentialDialoguePlayed = true;
            }
            else
            {
                dialogueManager.dialogue = exausteDialogue[levelmanager.GetCurrentLevel()];
                dialogueManager.LoadDialogue();
            }
            
        }
        else
        {
            dialogueManager.dialogue = defaultDialogue[levelmanager.GetCurrentLevel()];
            dialogueManager.LoadDialogue();
        }
        headTransform.LookAt(interactSrc);
    }
}
