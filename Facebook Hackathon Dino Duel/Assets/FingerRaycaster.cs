using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerRaycaster : MonoBehaviour
{
    public Transform hitting;
    public LayerMask lm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 2f, lm))
        {
            hitting = hit.transform;
        }
        else
        {
            hitting = null;
        }
    }
}
