using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    [SerializeField]
    List<AudioClip> melodies;

    [SerializeField]
    private AudioSource soundSource;


    public GameObject playMelodiesButton;
    public GameObject ball;
    public Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = ball.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        playMelodiesButton.SetActive(false);
    }

    public void OnStartGameButtonPressed()
    {
        rigidbody.useGravity = true;
        playMelodiesButton.SetActive(true);
    }

    public void OnPlayMelodyButtonPressed()
    {
        soundSource.clip = melodies[0];
        soundSource.Play();
    }

}
