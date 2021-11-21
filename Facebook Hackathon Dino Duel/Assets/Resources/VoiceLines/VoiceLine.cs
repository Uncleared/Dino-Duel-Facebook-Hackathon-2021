using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VoiceLine", menuName = "ScriptableObjects/VoiceLine", order = 1)]
public class VoiceLine : ScriptableObject
{
    public AudioClip audioClip;
    public string text;
}
