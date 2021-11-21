using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireBallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //characterInput.OnJump += OnJump;
    }

    public void SpawnFireball()
    {
        GameObject fireBall = Instantiate(fireBallPrefab, transform.position+transform.forward * 0.09f + Vector3.up * 0.05f, transform.rotation);
        fireBall.GetComponent<Fireball>().caster = transform;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
