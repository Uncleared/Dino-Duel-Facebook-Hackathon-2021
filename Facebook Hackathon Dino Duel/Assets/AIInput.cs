using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;
public class AIInput : CharacterInput
{
    FireballShooter shooter;
    HeadButt headButter;
    Dodger dodger;
    float x = 0f;
    float y = 0f;
    bool jump = false;
    public GameObject player;
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

    // Start is called before the first frame update
    void Start()
    {
        dodger = GetComponent<Dodger>();
        shooter = GetComponent<FireballShooter>();
        headButter = GetComponent<HeadButt>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //jump = true;
    }
    float chargeTimer = 0f;
    // Update is called once per frame
    void Update()
    {
        //chargeTimer += Time.deltaTime;
        //if(chargeTimer > 3f && Vector3.Distance(transform.position, player.transform.position) > 0.4f)
        //{
        //    chargeTimer = 0f;
        //    headButter.Charge();

        //}
      
        //Vector3 dest = player.transform.position + player.transform.forward * 0.01f;
        //x = dest.x - transform.position.x;
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit,0.03f,1))
        //{
        //    print("got hti by: " + hit.transform.name);
        //    //x += 0.2f;
        //}
        //y = dest.z - transform.position.z;
        //y = -y;
    }
}
