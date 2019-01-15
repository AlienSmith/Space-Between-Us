using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public ProBar bar;
    public float TimeinSeconds;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = TimeinSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        bar.SetProgress(currentTime / TimeinSeconds);
    }
}
