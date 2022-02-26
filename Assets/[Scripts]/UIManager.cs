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
    public GameObject pressEPrompt;
    public GameObject gameOverCanvas;
    public GameObject winCanvas;

    public GameObject ball;
    public Rigidbody rigidbody;
    public GameManager gameManager;
    //public Collider playerCollider;

    bool isPlaying = false;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Disable mouse when game is started

        rigidbody = ball.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        instructionsPanel.SetActive(false);
        pressEPrompt.SetActive(false);
        gameOverCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }   

    private void Update()
    {
        ListenToMelody();
    }

    private void ListenToMelody()
    {
        if (!isPlaying)
        {
            if (Input.GetKey("e"))
            {
                if(gameManager.numOfNotes == 4 && player.GetComponent<PlayerBehaviour>().difficultySelected == true)
                {
                    isPlaying = true;

                    soundSource.clip = melodies[0];
                    soundSource.Play();
                    StartCoroutine(enableMusic());
                }

                if (gameManager.numOfNotes == 8 && player.GetComponent<PlayerBehaviour>().difficultySelected == true)
                {
                    isPlaying = true;

                    soundSource.clip = melodies[1];
                    soundSource.Play();
                    StartCoroutine(enableMusic());
                }

                if (gameManager.numOfNotes == 13 && player.GetComponent<PlayerBehaviour>().difficultySelected == true)
                {
                    isPlaying = true;

                    soundSource.clip = melodies[2];
                    soundSource.Play();
                    StartCoroutine(enableMusic());
                }

            }
        }

    }

    IEnumerator enableMusic()
    {
        yield return new WaitForSeconds(9f);
        isPlaying = false;
    }


    public void OnStartGame()
    {
        rigidbody.useGravity = true;
        pressEPrompt.SetActive(true);
    }

    public void WinGame()
    {
        rigidbody.useGravity = false;
        instructionsPanel.SetActive(false);
        pressEPrompt.SetActive(false);
        winCanvas.SetActive(true);
    }

    public void LoseGame()
    {
        instructionsPanel.SetActive(false);
        pressEPrompt.SetActive(false);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

  

}
