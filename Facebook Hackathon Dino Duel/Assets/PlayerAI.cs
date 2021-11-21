using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour, IAI
{
    TurnBasedController controller;
    public IActivator activator;
    public void Init(TurnBasedController controller)
    {
        this.controller = controller;
        StartCall();
    }

    public void StartCall()
    {

    }
    public void UpdateCall()
    {
        activator.CallUpdate();
    }

    // Start is called before the first frame update
    void Start()
    {
        activator = GetComponent<IActivator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
