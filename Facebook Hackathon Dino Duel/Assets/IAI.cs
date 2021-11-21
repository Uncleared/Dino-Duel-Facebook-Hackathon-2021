using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAI 
{
    public void Init(TurnBasedController controller);
    public void UpdateCall();
    public void StartCall();
}
