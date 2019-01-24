using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDone : MonoBehaviour
{
    public TaskManager manager1;
    public TaskManager manager2;
    public GameObject Image;
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        done = true;
    }

    // Update is called once per frame
    void Update()
    {
        done = true;
        for (int i = 0; i < manager1.Acomplished.Length; i++) {
            if ((!manager1.Acomplished[i]) || (!manager2.Acomplished[i])) {
                done = false;
                break;
            }
        }
        if (done) {
            Image.SetActive(true);
        }
    }
}
