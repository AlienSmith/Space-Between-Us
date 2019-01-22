using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GameObject[] SpritePlane;
    public float[] TimeLimits;
    public bool[] Acomplished;
    public int currentTask;
    public RoundCountTimer my_timer;
    public ProBar progressBar;
    public float currentprogress;
    public int count;
    public bool Transition = true;
    public float delta;
    // Start is called before the first frame update
    void Start()
    {
        currentTask = 0;
        currentprogress = 0.0f;
        count = TimeLimits.Length;
        delta = 1.0f / count;
    }
    private void SetTheTimer(float timer) {
        my_timer.RestTimer(timer);
    }
    private void SetprogressBar(float progress) {
        progressBar.SetProgress(progress);
    }
    private void DetactState() {
        if (Input.GetKey(KeyCode.A) && currentTask == 0)
        {
            SuccessState();
        }
        else if (Input.GetKey(KeyCode.S) && currentTask == 1) {
            SuccessState();
        }
        else if (Input.GetKey(KeyCode.D) && currentTask == 2)
        {
            SuccessState();
        }
        else if (Input.GetKey(KeyCode.F) && currentTask == 3)
        {
            SuccessState();
        }
    }
    private void SuccessState() {
        Acomplished[currentTask] = true;
        currentprogress += delta;
        SetprogressBar(currentprogress);
        SetTransition();
    }
    //SetCurrentTask
    private void FindATask() {
        int firsttoken = 0;
        while (Acomplished[firsttoken]) {
            firsttoken++;
            if (firsttoken == (count - 1)) {
                currentTask = firsttoken;
                return;
            }
        }
        int token = Random.Range(0, (count - 2));
        while (Acomplished[token]) {
            token = (token + 1) % (count - 1);
        }
        currentTask = token;
        return;
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
            Transition = false;
        }
        DetactState();
    }
}
