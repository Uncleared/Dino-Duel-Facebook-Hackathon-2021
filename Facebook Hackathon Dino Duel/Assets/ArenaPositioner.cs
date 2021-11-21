using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPositioner : MonoBehaviour
{
    public AudioClip arenaSpawnedClip;
    public FingerRaycaster leftFinger;
    public FingerRaycaster rightFinger;
    public Transform eye;
    public GameObject arena;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.gameObject.AddComponent<AudioSource>();
        //StartCoroutine(PositionArena());
    }

    public void Reposition(Vector3 position)
    {
        
        audioSource.PlayOneShot(arenaSpawnedClip);
        Vector3 projectedForward = Vector3.ProjectOnPlane(eye.transform.forward, transform.up);
        arena.transform.position = position;
        //arena.transform.position -= Vector3.up * 0.3f;
        arena.transform.rotation = Quaternion.LookRotation(projectedForward, Vector3.up);
    }
    IEnumerator PositionArena()
    {
        yield return new WaitForSeconds(2f);
        Vector3 projectedForward = Vector3.ProjectOnPlane(eye.transform.forward, transform.up);
        arena.transform.position = eye.transform.position + projectedForward * 0.5f;
        arena.transform.position -= Vector3.up * 0.3f;
        arena.transform.rotation = Quaternion.LookRotation(projectedForward, Vector3.up);
        arena.SetActive(true);
    }
    float downFor = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Reposition(eye.transform.position + Vector3.ProjectOnPlane(eye.transform.forward * 0.5f, Vector3.up));
        }
        if(Vector3.Dot(leftFinger.transform.forward, Vector3.down) > 0.8f && Vector3.Dot(rightFinger.transform.forward, Vector3.down) > 0.8f)
        {
            downFor += Time.deltaTime;
        }
        if(downFor > 2.5f)
        {
            downFor = 0f;
            Reposition((rightFinger.transform.position + leftFinger.transform.position)/2f);
        }
    }
}
