using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public Renderer render;
    public GameObject End;
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
    public bool IsP1 = false;
    public InstructionManager instructions;
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
        render.material.SetFloat("_Fillpercentage", progress);
    }
    private void DetactState() {
        if (IsP1)
        {
            if (instructions.currentstate[currentTask]) {
                SuccessState();
                instructions.ResetInstructionP1();
            }
        }
        else {
            if (instructions.currentstate[currentTask + count]) {
                SuccessState();
                instructions.ResetInstructionP2();
            }
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
        int token = Random.Range(0, count);
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
        if (Acomplished[0] && Acomplished[1] && Acomplished[2]) {
            End.SetActive(true);
        }
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
