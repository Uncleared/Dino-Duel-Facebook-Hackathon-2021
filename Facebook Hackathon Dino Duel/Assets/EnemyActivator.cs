using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour, IActivator
{
    bool calledAttack = false;
    public void CallUpdate()
    {
        if(!calledAttack)
        {
            calledAttack = true;

        }
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
