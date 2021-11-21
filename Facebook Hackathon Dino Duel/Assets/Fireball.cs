using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Transform caster;
    public GameObject explosionPrefab;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(caster == collision.transform)
        {
            return;
        }
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        //Destroy(collision.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;       
    }
}
