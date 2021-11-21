using CMF;
using Oculus.Voice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVoiceInput : CharacterInput
{
	TurnBasedController turnBasedController;
	public AdvancedWalkerController controller;
	FireballShooter shooter;
	HeadButt headButter;
	Dodger dodger;
	public AppVoiceExperience wit;
	public float x;
	public float y;
	public bool jump;

    private void Start()
    {
		turnBasedController = GetComponent<TurnBasedController>();
		dodger = GetComponent<Dodger>();
        shooter = GetComponent<FireballShooter>();
		headButter = GetComponent<HeadButt>();
    }

	float cooldown = 0f;
	public string lastTransc = "";
    public void SubmitTranscription(string transc)
    {
		if(cooldown > 0f || (transc.Contains(lastTransc) && transc.Length == lastTransc.Length + 1))
        {
			return;
        }
		cooldown = 1f;
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
		if(command.Contains("attack"))
        {
			turnBasedController.Attack();
        }
	}
	public void SubmitMoveCommand(string[] entityValues)
    {
		//foreach(string entity in entityValues)
  //      {
		//	print(entity);
  //      }
		//string dir = entityValues[0];
		//print(dir);
		//dir.ToLower();
		//if(dir.Contains("left"))
  //      {
		//	y = -1f;
  //      }
		//else if(dir.Contains("right"))
  //      {
		//	x = 1f;
  //      }
		//else if(dir.Contains("forward"))
  //      {
		//	y = 1f;
  //      }
		//else if(dir.Contains("back"))
  //      {
		//	y = -1f;
  //      }
    }

    private void Update()
    {
		if(cooldown > 0f)
        {
			cooldown -= Time.deltaTime;
			if(cooldown < 0f)
            {
				cooldown = 0f;
            }
        }
  
    }
    public override float GetHorizontalMovementInput()
	{
		return x;
	}

	public override float GetVerticalMovementInput()
	{
		return y;
	}

	public override bool IsJumpKeyPressed()
	{
		if(jump)
        {
			jump = false;
			return true;
        }
		return false;
	}
}
