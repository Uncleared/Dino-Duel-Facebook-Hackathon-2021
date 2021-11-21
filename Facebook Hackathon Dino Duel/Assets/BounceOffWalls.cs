using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;
public class BounceOffWalls : MonoBehaviour
{
    AdvancedWalkerController controller;
    private void Start()
    {
        controller = GetComponent<AdvancedWalkerController>();
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Wall"))
        {
            print ("colleided with wall");
            controller.AddMovement(collision.contacts[0].normal * 2f);
        }
    }
}
