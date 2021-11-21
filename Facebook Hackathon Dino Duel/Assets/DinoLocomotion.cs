using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoLocomotion : MonoBehaviour
{

    public void Move(Vector2 move)
    {
        
    }

    public void Turn(float angle)
    {
        
    }

    public void Jump()
    {

    }
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //controller.Move
    }
}
