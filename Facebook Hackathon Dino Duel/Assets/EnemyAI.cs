using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IAI
{
    TurnBasedController controller;
    public void Init(TurnBasedController controller)
    {
        this.controller = controller;
        StartCall();
    }

    public void StartCall()
    {
        StartCoroutine(DecisionCoroutine());
    }
    
    IEnumerator DecisionCoroutine()
    {
        bool adjustedMorale = false;
        if (controller.moraleMeter.morale < 0.2f)
        {
            adjustedMorale = true;
        }
        else if (controller.moraleMeter.morale < 0.35f)
        {
            adjustedMorale = true;

        }

        if (controller.moraleMeter.morale > 0.9f)
        {
            adjustedMorale = true;

        }
        else if (controller.moraleMeter.morale > 0.6f)
        {
            adjustedMorale = true;

        }
        if (adjustedMorale)
        {
            yield return new WaitForSeconds(1.5f);
        }

        if (controller.moraleMeter.morale < 0.2f)
        {
            adjustedMorale = true;
            controller.RaiseMorale(2 / 7f);
        }
        else if(controller.moraleMeter.morale < 0.35f)
        {
            adjustedMorale = true;

            controller.RaiseMorale(1 / 7f);
        }

        if (controller.moraleMeter.morale > 0.9f)
        {
            adjustedMorale = true;

            controller.RaiseMorale(-2 / 7f);
        }
        else if (controller.moraleMeter.morale > 0.6f)
        {
            adjustedMorale = true;

            controller.RaiseMorale(-1 / 7f);
        }


        yield return new WaitForSeconds(1.5f);
        controller.Attack();

    }
    public void UpdateCall()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
