using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTowardsTarget : MonoBehaviour
{
    public float rotSpeed = 2f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = target.position - transform.position;
        delta = Vector3.Scale(delta, new Vector3(1f, 0, 1f));
        Quaternion rotation = Quaternion.LookRotation(delta);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);
    }
}
