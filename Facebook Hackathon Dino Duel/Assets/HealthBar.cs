using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scaleValue = 0.2109656f * value;
        bar.localScale = new Vector3(scaleValue, bar.localScale.y, bar.localScale.z);
        bar.localPosition = new Vector3(scaleValue / 2f, bar.localPosition.y, bar.localPosition.z);

    }
}
