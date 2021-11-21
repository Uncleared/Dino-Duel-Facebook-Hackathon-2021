using CMF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadButt : MonoBehaviour
{
    public Transform root;
    public float explosionAmount = 1.5f;
    public float explosionAmountUp = 1f;
    public float radius = 0.2f;
    public AudioClip landClip;
    public AudioClip landClip2;
    AudioSource audioSource;
    public GameObject explosionPrefab;
    public GameObject superExplosionPrefab;
    public Vector3 velocity;
    public AdvancedWalkerController controller;
    Animator animator;
    Transform tr;
    public float landVelocityThreshold = 5f;

    TurnBasedController caster;
    TurnBasedController target;
    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
        caster = root.GetComponent<TurnBasedController>();
        audioSource = gameObject.AddComponent<AudioSource>();
        animator = root.GetComponentInChildren<Animator>();
        controller = root.GetComponent<AdvancedWalkerController>();
        controller.OnLand += OnLand;
    }
    void OnLand(Vector3 _v)
    {		//Only trigger sound if downward velocity exceeds threshold;
		if(VectorMath.GetDotProduct(_v, tr.up) > -landVelocityThreshold)
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

    public void Charge(TurnBasedController target)
    {
        this.target = target;
        StartCoroutine(ChargeCoroutine());
    }
    // Update is called once per frame
    void Update()
    {
        // explosion land
        if(controller.IsGrounded() && charging)
        {
            charging = false;
            //Play land audio clip;
            audioSource.pitch = Random.Range(0.8f, 1f);
            if (target != null)
            {
                if (Mathf.Abs(caster.moraleMeter.morale - 0.5f) < 0.15f)
                {
                    target.Damage(0.6f * (1f - Mathf.Abs(0.5f - caster.moraleMeter.morale)));
                    GameObject explosion = Instantiate(superExplosionPrefab, transform.position, transform.rotation);
                    audioSource.PlayOneShot(landClip2, 0.7f);


                }
                else
                {
                    target.Damage(0.3f * (1f - Mathf.Abs(0.5f - caster.moraleMeter.morale)));
                    GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
                    audioSource.PlayOneShot(landClip, 0.7f);

                }
                target = null;
            }
            //Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            //foreach (var hitCollider in hitColliders)
            //{
            //    if(hitCollider.TryGetComponent(out AdvancedWalkerController enemyController) && hitCollider.transform != transform)
            //    {
            //        enemyController.AddMovement(-enemyController.transform.forward * explosionAmount + Vector3.up * explosionAmountUp);
            //    }
            //}
        }
        //if(Input.GetKeyDown(KeyCode.C))
        //{
        //    Charge();
        //}
    }
}
