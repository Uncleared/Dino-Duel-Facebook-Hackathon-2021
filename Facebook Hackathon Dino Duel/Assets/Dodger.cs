using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;


public class Dodger : MonoBehaviour
{

    public AudioClip landClip;
    AudioSource audioSource;
    public GameObject explosionPrefab;
    public Vector3 velocity;
    AdvancedWalkerController controller;
    Animator animator;
    Transform tr;
    public float landVelocityThreshold = 5f;
    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
        audioSource = gameObject.AddComponent<AudioSource>();
        animator = transform.GetComponentInChildren<Animator>();
        controller = GetComponent<AdvancedWalkerController>();
        controller.OnLand += OnLand;
    }
    void OnLand(Vector3 _v)
    {       //Only trigger sound if downward velocity exceeds threshold;
        if (VectorMath.GetDotProduct(_v, tr.up) > -landVelocityThreshold)
            return;
        //Only trigger sound if downward velocity exceeds threshold;
        //if (VectorMath.GetDotProduct(_v, transform.up) > -landVelocityThreshold)
        //    return;

    }
    bool charging = false;
    public IEnumerator ChargeCoroutine()
    {

        animator.SetTrigger("Charge");
        yield return new WaitForSeconds(0.02f);
        controller.AddMovement(transform.TransformDirection(velocity));
        yield return new WaitForSeconds(0.1f);
        charging = true;
    }

    public void Dodge(float x)
    {
        controller.AddMovement(transform.TransformDirection(new Vector3(x, 0.5f, 0)));
        if(x < 0f)
        {
            animator.SetTrigger("DashLeft");
        }
        else if(x > 0f)
        {
            animator.SetTrigger("DashRight");
        }
    }
    // Update is called once per frame
    void Update()
    {
        // explosion land
     
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Dodge(-1.5f);
        //}
        //if(Input.GetKeyDown(KeyCode.D))
        //{
        //    Dodge(1.5f);
        //}
    }
}
