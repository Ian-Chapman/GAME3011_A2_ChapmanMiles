using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    bool gameStarted = false;

    public GameObject player;
    public GameObject boxTrigger;

    [SerializeField]
    List<AudioClip> melodies;

    [SerializeField]
    private AudioSource soundSource;

    public GameObject instructionsPanel;
    public GameObject difficultyPanel;
    public GameObject pressEPrompt;
    
    public GameObject ball;
    public Rigidbody rigidbody;
    //public Collider playerCollider;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Disable mouse when game is started

        rigidbody = ball.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        instructionsPanel.SetActive(false);
        difficultyPanel.SetActive(false);
        pressEPrompt.SetActive(false);
    }   

    private void Update()
    {
        ListenToMelody();
        OnStartGame();
    }

    private void ListenToMelody()
    {
        if (Input.GetKey("e"))
        {
            soundSource.clip = melodies[0];
            soundSource.Play();
        }
    }


    private void OnStartGame()
    {
        if (Input.GetKey("q"))
        {
            rigidbody.useGravity = true;
        }
    }

}
