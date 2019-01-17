using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCountTimer : MonoBehaviour
{
    public Renderer render;
    public float time;
    public float currenttime;
    // Start is called before the first frame update
    void Start()
    {
        currenttime = time;
    }
    private void SetPercentage() {
        render.material.SetFloat("_Fillpercentage", currenttime / time);
    }
    // Update is called once per frame
    void Update()
    {
        currenttime -= Time.deltaTime;
        currenttime = Mathf.Clamp(currenttime,0.0f,time);
        SetPercentage();
    }
}
