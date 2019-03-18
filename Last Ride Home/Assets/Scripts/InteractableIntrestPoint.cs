using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableIntrestPoint : InteractableObject
{
    public LevelManger_01 _levelManger;
    public int targetLevel;
    public override void Interact(Vector3 interactSrc)
    {
        _levelManger.ResetLevelWithDialogue(targetLevel);
    }
}
