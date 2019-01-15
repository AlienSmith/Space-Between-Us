using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BackGround;
    public GameObject BAR;
    private float SCalex;
    private float currentratio;
    void Start()
    {
        Debug.Log("Started");
        SCalex = BackGround.GetComponent<Transform>().localScale.x;
        currentratio = 1.0f;
    }
    public void SetProgress(float ratio) {
        ratio = Mathf.Clamp(ratio, 0.0f, 1.0f);
        this.currentratio = ratio;
        float oldsize = BAR.GetComponent<Transform>().localScale.x;
        float currentsize = ratio * SCalex;
        float deltaSize = currentsize - oldsize;
        float y = BAR.GetComponent<Transform>().localScale.y;
        float z = BAR.GetComponent<Transform>().localScale.z;
        BAR.GetComponent<Transform>().localScale = new Vector3(currentsize, y, z);
        BAR.GetComponent<Transform>().Translate(new Vector3(-deltaSize*5.0F, 0f,0f));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S)) {
            SetProgress(currentratio + 0.01f);
            Debug.Log("KEY S Pressed");
        }
        else if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.A)){
            SetProgress(currentratio - 0.01f);
            Debug.Log("KEY A and W Pressed");
        }
    }
}
