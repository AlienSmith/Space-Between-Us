using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    public bool[] instructions = { false, false, false, false, false, false };
    public bool[] currentstate = { false, false, false, false, false, false };
    public float[] timer = { 3, 3, 7, 3, 3, 3 };
    public float[] currenttime = { 3, 3, 7, 3, 3, 3 };
    // Start is called before the first frame update
    public void ResetInstructionP1() {
        for (int i = 0; i < instructions.Length/2; i++) {
            instructions[i] = false;
        }
    }
    public void ResetInstructionP2()
    {
        for (int i = instructions.Length / 2; i < instructions.Length; i++)
        {
            instructions[i] = false;
        }
    }
    public void DetectInstruction() {
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            instructions[0] = true;
            Debug.Log("S & D pressed");
        }
        if (Input.GetKey(KeyCode.W))
        {
            instructions[1] = true;
            Debug.Log("W pressed");
        }
        if (Input.GetKey(KeyCode.A)) {
            instructions[2] = true;
            Debug.Log("A pressed");
        }
        if (Input.GetMouseButton(0))
        {
            instructions[3] = true;
            Debug.Log("LEFT Button");
        }
        if (Input.GetKey(KeyCode.UpArrow)&& Input.GetKey(KeyCode.DownArrow)&& Input.GetKey(KeyCode.LeftArrow)&& Input.GetKey(KeyCode.RightArrow))
        {
            instructions[4] = true;
            Debug.Log("Arrow Buttons");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            instructions[5] = true;
            Debug.Log("Space Button");
        }
    }
    public void AddInstruction() {
        for (int i = 0; i < currentstate.Length; i++) {
            if (instructions[i]) {
                currenttime[i] -= Time.deltaTime;
                if (currenttime[i] < 0)
                {
                    currentstate[i] = true;
                }
                instructions[i] = false;
            }
            else
            {
                currenttime[i] = timer[i];
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        DetectInstruction();
        AddInstruction();
    }
}
