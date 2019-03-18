using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName  ="New Dialogue",menuName = "New Dialogue")]
public class DialoguePreset : ScriptableObject
{
    public string[] speaker;
    [TextArea]
    public string[] dialogues;
    public string[] animations;
    public int[] npcNums;
    public AudioClip[] audioClips;
}
