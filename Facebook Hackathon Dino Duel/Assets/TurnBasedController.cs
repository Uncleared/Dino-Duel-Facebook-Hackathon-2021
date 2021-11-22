using CMF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedController : MonoBehaviour
{
    public AudioClip fireClip;
    public GameObject fireParticles;
    public SkinnedMeshRenderer meshRenderer;
    public float maxHealth = 2f;
    public float health = 0f;
    public HealthBar healthBar;

    bool dead = false;
    Animator animator;
    public GameManager gameManager;
    public TurnBasedController target;
    public bool defending = false;
    public MoraleMeter moraleMeter;
    public GameObject cylinder;
    public IAI ai;
    [SerializeField]
    bool isCurrentTurn = false;
    TurnBasedManager turnBasedManager;
    public Vector3 initialPosition;
    public Quaternion initialRotation;
    public GameObject defendParticlesPrefab;
    public GameObject moraleParticlesPrefab;

    GameObject currentDefendParticles;

    bool selectedMove = false;
    bool saidEncouragement = false;
    AdvancedWalkerController controller;

    public void Init(TurnBasedManager turnBasedManager, TurnBasedController target)
    {
        controller = GetComponent<AdvancedWalkerController>();
        animator = transform.GetComponentInChildren<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        ai = GetComponent<IAI>();
        this.health = maxHealth;
        this.turnBasedManager = turnBasedManager;
        this.target = target;
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    void PerformMoraleCheck()
    {
        if (Mathf.Abs(moraleMeter.morale - 0.5f) < 1f/7f)
        {
            if(!fireParticles.activeSelf)
            {
                GameObject fireSoundGO = new GameObject();
                AudioSource audioSource = fireSoundGO.AddComponent<AudioSource>();
                audioSource.PlayOneShot(fireClip);
                fireParticles.SetActive(true);

            }
        }
        else
        {
            fireParticles.SetActive(false);
        }
    }

    public void Damage(float damage)
    {
       
        if (defending)
        {
            damage *= 0.5f;
            moraleMeter.morale -= 0.05f;

        }
        else
        {
            moraleMeter.morale -= 0.2f;

        }

        if (moraleMeter.morale < 0f)
        {
            moraleMeter.morale = 0f;
        }
        if (moraleMeter.morale > 1f)
        {
            moraleMeter.morale = 1f;
        }

        PerformMoraleCheck();
      
        animator.SetTrigger("Damaged");
        health -= damage;
        if(health <= 0f)
        {
            health = 0f;
            Die();
        }
    }

    IEnumerator DamageCoroutine()
    {
        //meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        //meshRenderer.material.color = Color.white;
    }
    public void RaiseMorale(float extra)
    {
        if(saidEncouragement)
        {
            return;
        }
        PerformMoraleCheck();
        controller.AddMomentum(Vector3.up * 0.8f);
        saidEncouragement = true;
        GameObject moraleParticles = Instantiate(moraleParticlesPrefab, transform.position, Quaternion.identity);
        moraleParticles.transform.rotation = Quaternion.Euler(-90, 0, 0);
        moraleParticles.transform.position -= transform.up * 0.05f;
        moraleMeter.morale += extra;
        if(moraleMeter.morale > 1f)
        {
            moraleMeter.morale = 1f;
        }
        if(moraleMeter.morale < 0f)
        {
            moraleMeter.morale = 0f;
        }
    }

    public void Die()
    {
        dead = true;
        animator.SetBool("Dead", true);
        gameManager.GameOver(gameObject);
    }
    public HeadButt headButtAttack;
    public void Attack()
    {
        if(selectedMove)
        {
            return;
        }
        selectedMove = true;
        StartCoroutine(AttackCoroutine());
    }

    public void Defend()
    {
        if(selectedMove)
        {
            return;
        }
        selectedMove = true;
        StartCoroutine(DefendCoroutine());

    }

    public IEnumerator DefendCoroutine()
    {
        GameObject defendParticles = Instantiate(defendParticlesPrefab, transform.position, transform.rotation);
        currentDefendParticles = defendParticles;
        defending = true;
        yield return new WaitForSeconds(1f);
        turnBasedManager.NextTurn(this);
    }
    public void Encourage()
    {

    }

    // when turn has arrived
    public void SelectTurn()
    {
        selectedMove = false;
        saidEncouragement = false;
        if (currentDefendParticles != null)
        {
            Destroy(currentDefendParticles);
        }
        defending = false;
        cylinder.SetActive(true);
        ai.Init(this);
        isCurrentTurn = true;
    }

    public void DeactivateTurn()
    {
        cylinder.SetActive(false);
        isCurrentTurn = false;
    }
    public void RestoreTransform()
    {
        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;
    }
    public IEnumerator AttackCoroutine()
    {
   
       
        headButtAttack.Charge(target);
        yield return new WaitForSeconds(1f);
        if (Mathf.Abs(moraleMeter.morale - 0.5f) < 0.15f)
        {
            if (moraleMeter.morale - 0.5f > 0f)
            {
                moraleMeter.morale += Random.Range(0.4f, 0.5f);
            }
            else if (moraleMeter.morale - 0.5f < 0f)
            {
                moraleMeter.morale -= Random.Range(0.4f, 0.5f);

            }
        }
        else
        {
            if (moraleMeter.morale - 0.5f > 0f && moraleMeter.morale < 0.9f)
            {
                moraleMeter.morale += Random.Range(0.05f, 0.15f);
            }
            else if (moraleMeter.morale - 0.5f < 0f && moraleMeter.morale > 0.1f)
            {
                moraleMeter.morale -= Random.Range(0.05f, 0.15f);

            }
        }
        if (moraleMeter.morale < 0f)
        {
            moraleMeter.morale = 0f;
        }
        if (moraleMeter.morale > 1f)
        {
            moraleMeter.morale = 1f;
        }
        PerformMoraleCheck();
        RestoreTransform();
        turnBasedManager.NextTurn(this);
    }

    public void Revive()
    {
        animator = transform.GetComponentInChildren<Animator>();

        dead = false;
        animator.SetBool("Dead", false);
        health = maxHealth;
        moraleMeter.morale = Random.Range(0, 1f);
    }
    // Start is called before the first frame update
    void Awake()
    {
        moraleMeter.morale = Random.Range(0f, 1f);
        PerformMoraleCheck();
        DeactivateTurn();

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health / maxHealth;
        print("updating");
        if(isCurrentTurn && !dead)
        {
            if(ai != null)
            {
                ai.UpdateCall();
            }
            else
            {
                Debug.LogError("No activator found");
            }
        }
    }
}
