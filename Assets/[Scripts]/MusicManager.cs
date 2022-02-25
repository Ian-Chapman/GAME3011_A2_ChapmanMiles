using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    [SerializeField]
    List<AudioClip> pianoNotes;

    [SerializeField]
    private AudioSource soundSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //------------------------------------------------------------- Music notes played - attached to Piano Key animation events -----------------------------------------------
    public void notePressedC()
    {
        soundSource.clip = pianoNotes[0];
        soundSource.Play();
    }

    public void notePressedCSharp()
    {
        soundSource.clip = pianoNotes[1];
        soundSource.Play();
    }

    public void notePressedD()
    {
        soundSource.clip = pianoNotes[2];
        soundSource.Play();
    }

    public void notePressedDSharp()
    {
        soundSource.clip = pianoNotes[3];
        soundSource.Play();
    }

    public void notePressedE()
    {
        soundSource.clip = pianoNotes[4];
        soundSource.Play();
    }

    public void notePressedF()
    {
        soundSource.clip = pianoNotes[5];
        soundSource.Play();
    }

    public void notePressedFSharp()
    {
        soundSource.clip = pianoNotes[6];
        soundSource.Play();
    }

    public void notePressedG()
    {
        soundSource.clip = pianoNotes[7];
        soundSource.Play();
    }

    public void notePressedGSharp()
    {
        soundSource.clip = pianoNotes[8];
        soundSource.Play();
    }

    public void notePressedA()
    {
        soundSource.clip = pianoNotes[9];
        soundSource.Play();
    }

    public void notePressedASharp()
    {
        soundSource.clip = pianoNotes[10];
        soundSource.Play();
    }

    public void notePressedB()
    {
        soundSource.clip = pianoNotes[11];
        soundSource.Play();
    }

    public void notePressedHighC()
    {
        soundSource.clip = pianoNotes[12];
        soundSource.Play();
    }


}
