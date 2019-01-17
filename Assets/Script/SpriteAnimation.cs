using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    public Texture[] textures;
    public float frameTime = 0.03f;
    public bool isAnimated = false;
    public bool isCongratulation = false;
    public bool isSetCongratulationMaterial = false;
    public bool isFinished = false;
    public bool isSetFinishedMaterial = false;
    public bool hasAnimation = false;

    private int frameCounter = 0;
    private int animatedMaterialID = 0;
    private float collapsedTime = 0;

    private Material FinishedMaterial;
    private Material CongratulationMaterial;
    private GameObject congratulationAnimation;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (hasAnimation)
        {

            if (isAnimated)
            {
                collapsedTime += Time.deltaTime;
                if (collapsedTime > frameTime)
                {
                    collapsedTime = 0;
                    StartCoroutine("PlayLoop", 0.04f);
                }
            }
            
        }
        
    }

    //The following methods return a IEnumerator so they can be yielded:  
    //A method to play the animation in a loop  
    IEnumerator PlayLoop(float delay)
    {
        //Wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);

        //Advance one frame  
        frameCounter = (++frameCounter) % textures.Length;
        var newMaterials = this.GetComponentInChildren<Renderer>().materials;
        newMaterials[animatedMaterialID].mainTexture = textures[frameCounter];
        this.GetComponentInChildren<Renderer>().materials = newMaterials;
        //Stop this coroutine  
        StopCoroutine("PlayLoop");
    }

    //A method to play the animation just once  
    IEnumerator Play(float delay)
    {
        //Wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);

        //If the frame counter isn't at the last frame  
        if (frameCounter < textures.Length - 1)
        {
            //Advance one frame  
            ++frameCounter;

        }
        else if (frameCounter >= textures.Length - 1)
        {
            isAnimated = false;
            isCongratulation = true;
        }
        var newMaterials = this.GetComponentInChildren<Renderer>().materials;
        newMaterials[animatedMaterialID].mainTexture = textures[frameCounter];
        this.GetComponentInChildren<Renderer>().materials = newMaterials;
        //Stop this coroutine  
        StopCoroutine("Play");
    }

    IEnumerator PlayBack(float delay)
    {
        //Wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);

        //If the frame counter isn't at the last frame  
        if (frameCounter > 0)
        {
            --frameCounter;

        }
        var newMaterials = this.GetComponentInChildren<Renderer>().materials;
        newMaterials[animatedMaterialID].mainTexture = textures[frameCounter];
        this.GetComponentInChildren<Renderer>().materials = newMaterials;
        StopCoroutine("PlayBack");
    }
}