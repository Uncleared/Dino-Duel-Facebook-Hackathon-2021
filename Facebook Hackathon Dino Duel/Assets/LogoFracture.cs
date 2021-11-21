using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoFracture : MonoBehaviour
{
    public Dictionary<Transform, Vector3> originalPos;
    public Dictionary<Transform, Vector3> dir;
    public List<Transform> fractureParts;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Dictionary<Transform, Vector3>();
        foreach (Transform part in fractureParts)
        {
            originalPos.Add(part, part.position);
        }
    }

    public bool explode = false;
    public void Explode()
    {
        explode = true;
        dir = new Dictionary<Transform, Vector3>();
        foreach(Transform part in fractureParts)
        {
            dir.Add(part, Random.insideUnitSphere);
        }
    }

    public void Together()
    {
        explode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Explode();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Together();
        }
        if (explode)
        {
            foreach (Transform part in fractureParts)
            {
                part.position += dir[part] * Time.deltaTime + Vector3.down * 0.5f * Time.deltaTime;
            }
        }
        if(!explode)
        {

            foreach (Transform part in fractureParts)
            {
                ///part.position = originalPos[part];
                part.position = Vector3.Lerp(part.position, originalPos[part], Time.deltaTime * 3f);
            }
        }
    }
}
