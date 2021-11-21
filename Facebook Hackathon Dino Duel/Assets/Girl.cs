using Oculus.Voice;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Girl : MonoBehaviour
{
    public AppVoiceExperience wit;
    public Dictionary<string, VoiceLine> lines;
    AudioSource audioSource;
    public async void SayDialogue(string dialogue)
    {
  
        AudioClip clip = lines[dialogue.GetHashCode().ToString()].audioClip;
        if(clip == null)
        {
            Debug.LogError("No dialogue clip found");
        }
        Task audioTask = PlayAudio(clip);
        await Task.WhenAll(audioTask);
        print("Done!");
        wit.Activate();
    }

    async Task PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);

        await Task.Delay((int)clip.length*1000);
    }
    // Start is called before the first frame update
    void Start()
    {
        Object[] linesO = Resources.LoadAll("VoiceLines", typeof(VoiceLine));
        lines = new Dictionary<string, VoiceLine>();
        foreach(Object lineO in linesO)
        {
            VoiceLine voiceLine = (VoiceLine)lineO;
            
            lines.Add(voiceLine.text.GetHashCode().ToString(), (VoiceLine)lineO);
        }
        
        audioSource = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
