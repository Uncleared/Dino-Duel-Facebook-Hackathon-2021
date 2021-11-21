using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoraleMeter : MonoBehaviour
{
    public MoraleBar moraleBar;
    public float morale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(moraleBar != null)
        {
            moraleBar.SetMorale(morale);
        }
    }
}
