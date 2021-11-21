using Oculus.Voice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyActivator : MonoBehaviour
{
    public AppVoiceExperience voice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            voice.Activate();
        }
    }
}
