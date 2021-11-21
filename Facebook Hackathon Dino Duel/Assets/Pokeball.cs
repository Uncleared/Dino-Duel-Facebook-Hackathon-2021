using HighlightPlus;
using Oculus.Voice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    TurnBasedManager turnBasedManager;
    public FingerRaycaster rightFinger;
    public AppVoiceExperience wit;
    public HighlightEffect highlight;
    bool lastInput = false;
    public GameObject pokemon1;
    public GameObject pokemon2;

    public GameObject pokeball1;
    public GameObject pokeball2;
    // Start is called before the first frame update
    void Start()
    {
        turnBasedManager = FindObjectOfType<TurnBasedManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rightFinger.hitting != null)
        {
            print("FINGER: " + rightFinger.hitting.name);
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            SpawnPokemon();
        }
        if (Input.GetKey(KeyCode.A) || (rightFinger.hitting != null && rightFinger.hitting.gameObject == gameObject))
        {
            if (!lastInput)
            {
                highlight.highlighted = true;
                wit.Activate();
            }
            lastInput = true;
        }
        else
        {
            if (lastInput)
            {
                highlight.highlighted = false;
                wit.Deactivate();
            }
            lastInput = false;
        }
    }


    void SpawnPokemon()
    {

        turnBasedManager.SpawnPokemon();
        pokeball1.SetActive(false);
        pokeball2.SetActive(false);
    }
    public void SubmitTranscription(string transc)
    {
        if(transc.ToLower() == "i choose you")
        {
            SpawnPokemon();
        }
    }
}
