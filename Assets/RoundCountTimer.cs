using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCountTimer : MonoBehaviour
{
    public Renderer render;
    public float time;
    private float currenttime;
    public TaskManager my_manager;
    // Start is called before the first frame update
    void Start()
    {
        currenttime = time;
    }
    public void RestTimer(float tie) {
        time = tie;
        currenttime = tie;
    }
    private void SetPercentage() {
        render.material.SetFloat("_Fillpercentage", currenttime / time);
    }
    // Update is called once per frame
    void Update()
    {
        currenttime -= Time.deltaTime;
        //Time Runs out reset;
        if (currenttime < 0.0f) {
            my_manager.SetTransition();
        }
        currenttime = Mathf.Clamp(currenttime,0.0f,time);
        SetPercentage();
    }
}
