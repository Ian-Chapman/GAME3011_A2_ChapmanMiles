using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoBehavior : MonoBehaviour
{ 

    [SerializeField]
    GameObject Piano;

    Animation pianoAnimation;


    // Start is called before the first frame update
    void Start()
    {
        pianoAnimation = Piano.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playNote(string note)
    {
        pianoAnimation.Play(note);
        //Debug.Log(note);
    }
}
