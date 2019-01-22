using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GameObject[] SpritePlane;
    public float[] TimeLimits;
    private bool[] Acomplished;
    private int currentTask;
    public RoundCountTimer my_timer;
    public ProBar progressBar;
    public float currentprogress;
    private int count;
    public bool Transition = true;
    private float delta;
    // Start is called before the first frame update
    void Start()
    {
        currentprogress = 0.0f;
        count = TimeLimits.Length;
        for (int i = 0; i < count; i++) {
            Acomplished[i] = false;
        }
        delta = 1.0f / count;
    }
    private void SetTheTimer(float timer) {
        my_timer.RestTimer(timer);
    }
    private void SetprogressBar(float progress) {
        progressBar.SetProgress(progress);
    }
    private void DetactState() {
        if (Input.GetKey(KeyCode.A)) {
            Acomplished[currentTask] = true;
            currentprogress += delta;
            SetprogressBar(currentprogress);
            Transition = true;
        }
    }
    //SetCurrentTask
    private void FindATask() {
        for (int i = 0; i < count; i++) {
            if (!Acomplished[i]) {
                break;
            }
            if (i == count - 1) {
                currentTask = count - 1;
                return;
            }
        }
        int token = Random.Range(0, count - 2);
        while(Acomplished[token]) {
            token = (token + 1) % (count - 1);
        }
        currentTask = token;
    }
    public void SetTransition() {
        SpritePlane[currentTask].SetActive(false);
        Transition = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Transition) {
            FindATask();
            SetTheTimer(TimeLimits[currentTask]);
            SetprogressBar(currentprogress);
            SpritePlane[currentTask].SetActive(true);
        }
    }
}
