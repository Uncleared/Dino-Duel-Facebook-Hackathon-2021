using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraleBar : MonoBehaviour
{
    public float minX;
    public float maxX;
    public Transform mover;
    float currentMorale = 0f;
    public void SetMorale(float newMorale)
    {
        currentMorale = newMorale;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Lerp(minX, maxX, currentMorale);
        mover.transform.localPosition = Vector3.Lerp(mover.localPosition, new Vector3(x, mover.localPosition.y, mover.localPosition.z), Time.deltaTime * 3f);
    }
}
