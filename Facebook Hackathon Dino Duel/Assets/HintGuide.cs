using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintGuide : MonoBehaviour
{
    bool toggle = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            toggle = !toggle;
            if(toggle)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.SetActive(false);
            }
            
        }
    }
}
