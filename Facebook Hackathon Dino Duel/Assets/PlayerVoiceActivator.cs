using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;
using Oculus.Voice;
using CMF;

public class PlayerVoiceActivator : MonoBehaviour, IActivator
{
    ArenaPositioner arenaPositioner;
    GameManager gameManager;
    public Transform rightHand;
    public AppVoiceExperience wit;
    bool lastInput = false;
    public HighlightEffect highlight;

    TurnBasedController turnBasedController;
    TurnBasedManager turnBasedManager;
    public AdvancedWalkerController controller;
    FireballShooter shooter;
    HeadButt headButter;
    Dodger dodger;
    public float x;
    public float y;
    public bool jump;

    public FingerRaycaster leftFinger;
    public FingerRaycaster rightFinger;
    private void Start()
    {
        turnBasedManager = FindObjectOfType<TurnBasedManager>();
        gameManager = FindObjectOfType<GameManager>();
        turnBasedController = GetComponent<TurnBasedController>();
        dodger = GetComponent<Dodger>();
        shooter = GetComponent<FireballShooter>();
        headButter = GetComponent<HeadButt>();
        arenaPositioner = FindObjectOfType<ArenaPositioner>();
    }

    float cooldown = 0f;
    public string lastTransc = "";
    public void SubmitTranscription(string transc)
    {
        lastTransc = transc;
        string command = transc.ToLower();

        //if (command.Contains("left") || command.Contains("lift"))
        //{
        //	dodger.Dodge(-1f);
        //}
        //else if (command.Contains("right"))
        //{
        //	dodger.Dodge(1f);
        //}
        //else if (command.Contains("forward"))
        //{
        //	y = 1f;
        //	x = 0f;
        //}
        //else if (command.Contains("back") || command.Contains("run"))
        //{
        //	y = -1f;
        //}
        //else if(command.Contains("stop"))
        //      {
        //	x = 0f;
        //	y = 0f;
        //      }
        //else if(command.Contains("jump"))
        //      {
        //	jump = true;
        //      }
        //else if(command.Contains("attack"))
        //      {
        //	shooter.SpawnFireball();

        //}
        //else if (command.Contains("you can do it"))
        //{
        //	controller.movementSpeed += 1f;

        //}
        //else if(command.Contains("charge"))
        //      {
        //	headButter.Charge();
        //      }
        if (command.Contains("attack"))
        {
            turnBasedController.Attack();
        }

        if (command.Contains("defend"))
        {
            turnBasedController.Defend();
        }

        if (command.Contains("restart"))
        {
            gameManager.Restart();
        }
        if (command.Contains("not bad"))
        {
            turnBasedController.RaiseMorale(3f / 7f);
        }

        if (command.Contains("great"))
        {
            turnBasedController.RaiseMorale(3f / 7f);
        }
        if (command.Contains("doing good"))
        {
            turnBasedController.RaiseMorale(3f / 7f);
        }


        if (command.Contains("amazing"))
        {
            turnBasedController.RaiseMorale(5f / 7f);
        }

        if (command.Contains("not good enough"))
        {
            turnBasedController.RaiseMorale(-3f / 7f);
        }

        if (command.Contains("too excited"))
        {
            turnBasedController.RaiseMorale(-3f / 7f);
        }
        if (command.Contains("idiot sandwich"))
        {
            turnBasedController.RaiseMorale(-5f / 7f);
        }

        if (command.Contains("you suck"))
        {
            turnBasedController.RaiseMorale(-5f / 7f);
        }
    }
    // Update is called once per frame
    public void CallUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SubmitTranscription("attack");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SubmitTranscription("defend");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            turnBasedController.RaiseMorale(1f / 7f);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            turnBasedController.RaiseMorale(-1f / 7f);
        }


        if (!wit.Active || !wit.MicActive)
        {
            highlight.highlighted = false;
        }
        print("I'm active");
        if(rightFinger.hitting != null)
        {
            print("FINGER: " + rightFinger.hitting.name);
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
}
