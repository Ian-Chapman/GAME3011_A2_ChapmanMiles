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

    private void Update()
    {
        if (Input.GetKey("e"))
        {
            soundSource.clip = melodies[0];
            soundSource.Play();
        }
    }


    public void OnStartGameButtonPressed()
    {
        rigidbody.useGravity = true;
        playMelodiesButton.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked; //Disable mouse when game is started
    }

    //public void OnPlayMelodyButtonPressed()
    //{
    //    if (Input.GetKey("e"))
    //    {
    //        soundSource.clip = melodies[0];
    //        soundSource.Play();
    //    }
       
    //}

}
