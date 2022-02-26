using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Animator animator;
    public GameObject piano;

    public Animator doorAnimator;


    public Camera camera;
    private CharacterController controller;

    [Header("Movement Properties")]
    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;
    public Vector3 velocity;

    [Header("Ground Detection Properties")]
    public Transform groundCheck;
    public float groundRadius = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    GameObject pianoKey;
    PianoBehavior pianoBehavior;

    public GameObject gameManagerGO;
    GameManager gameManager;

    List<string> notesPressed = new List<string>();

    public bool difficultySelected = false;

    [SerializeField]
    GameObject easyButton;
    [SerializeField]
    GameObject medButton;
    [SerializeField]
    GameObject hardButton;
    [SerializeField]
    GameObject clearButton;

    [SerializeField]
    GameObject easyText;
    [SerializeField]
    GameObject medText;
    [SerializeField]
    GameObject hardText;
    [SerializeField]
    GameObject clearText;

    int correctNotes = 0;

    public UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        animator = piano.GetComponent<Animator>();
        gameManager = gameManagerGO.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * maxSpeed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity); //creates a positive number for jumping or "falling upwards"
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray2 = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray2, out hit))
            {
                Transform objectHit = hit.transform;

                //Debug.Log(objectHit);

                if (objectHit.gameObject.name.Contains("PianoKey") && difficultySelected == true)
                {
                    //Debug.Log("piano key hit");
                    pianoKey = objectHit.gameObject;
                    pianoBehavior = pianoKey.GetComponent<PianoBehavior>();


                    pianoBehavior.playNote(pianoKey.gameObject.tag + "_KeyPressed");
                    


                    if(notesPressed.Capacity < gameManager.noteList.Capacity)
                    {
                        notesPressed.Capacity += 1;
                        notesPressed.Add(pianoKey.gameObject.tag);
                        Debug.Log("added: " + pianoKey.gameObject.tag);
                        Debug.Log("capacity: " + notesPressed.Capacity);
                    }
                    
                    if(notesPressed.Capacity == gameManager.noteList.Capacity)
                    {
                        Debug.Log("capacity reached");
                        
                        string[] playerNotes;
                        string[] gameNotes;

                        playerNotes = notesPressed.ToArray();
                        gameNotes = gameManager.noteList.ToArray();

                        for (int i = 0; i < notesPressed.Capacity; i++)
                        { 

                            if(playerNotes[i].Equals(gameNotes[i]))
                            {
                                correctNotes++;
                            }
                        }

                        if (correctNotes == gameManager.noteList.Capacity)
                        {
                            Debug.Log("you win bruv");
                            animator.SetBool("isMelodyCorrect", true);
                            StartCoroutine(OpenDoor());
                        }
                        else
                        {
                            notesPressed.Clear();
                            notesPressed.Capacity = 0;
                            correctNotes = 0;
                        }
                    }


                }else if(objectHit.gameObject == easyButton)
                {
                    Debug.Log("easy");
                    gameManager.setDifficulty((int)Difficulty.EASY);
                    difficultySelected = true;

                    medButton.SetActive(false);
                    medText.SetActive(false);

                    hardButton.SetActive(false);
                    hardText.SetActive(false);

                    clearButton.SetActive(true);
                    clearText.SetActive(true);

                    uiManager.OnStartGame();
                }
                else if (objectHit.gameObject == medButton)
                {
                    Debug.Log("med");
                    gameManager.setDifficulty((int)Difficulty.MEDIUM);
                    difficultySelected = true;

                    easyButton.SetActive(false);
                    easyText.SetActive(false);

                    hardButton.SetActive(false);
                    hardText.SetActive(false);

                    clearButton.SetActive(true);
                    clearText.SetActive(true);
                    uiManager.OnStartGame();
                }

                else if (objectHit.gameObject == hardButton)
                {
                    Debug.Log("hard");
                    gameManager.setDifficulty((int)Difficulty.HARD);
                    difficultySelected = true;

                    easyButton.SetActive(false);
                    easyText.SetActive(false);

                    medButton.SetActive(false);
                    medText.SetActive(false);

                    clearButton.SetActive(true);
                    clearText.SetActive(true);
                    uiManager.OnStartGame();
                }
                else if (objectHit.gameObject == clearButton)
                {
                    Debug.Log("Attempt Cleared");
                    notesPressed.Clear();
                    notesPressed.Capacity = 0;
                    correctNotes = 0;
                }
                else
                {
                    Debug.Log("no");
                }

            }
        }

        //apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BoxTrigger")
        {
            animator.SetBool("isPianoLifted", true);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(2.7f);
        doorAnimator.SetBool("isMelodyCorrect", true);
        yield return new WaitForSeconds(1.3f);
        uiManager.WinGame();
        Time.timeScale = 0;
    }
}
