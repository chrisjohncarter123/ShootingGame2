using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour {


    public Text txt;
    string story;
    public float delay;
    public float newLineDelay;

    public AudioSource sound;
    public AudioSource nextLineSound;

    public bool nextStateOnFinish = false;

    void StartText()
    {
        story = txt.text;
        txt.text = "";

        // TODO: add optional delay when to start
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            float wait = 0;

            if (c.Equals('\n')) 
            { 
                nextLineSound.Play();
                wait = newLineDelay;
            }
            else 
            { 
                sound.Play();
                wait = delay;
            
            }
            if(txt.text.Equals(story)){
                if(nextStateOnFinish){
                    GetComponent<State>().SendMessageToBranch("NextState");
                    EndState();
                }
            }


            yield return new WaitForSeconds(wait);
        }
    }

    public void StartState()
    {
        StartText();
    }
    public void EndState()
    {

    }
}
