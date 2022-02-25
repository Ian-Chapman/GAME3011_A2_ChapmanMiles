using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
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

                Debug.Log(objectHit);

                if (objectHit.gameObject.name.Contains("PianoKey"))
                {
                    Debug.Log("piano key hit");
                    pianoKey = objectHit.gameObject;
                    pianoBehavior = pianoKey.GetComponent<PianoBehavior>();


                    pianoBehavior.playNote(pianoKey.gameObject.tag + "_KeyPressed");
                    Debug.Log(pianoKey.gameObject.tag);

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

    private void OnMouseDown() //Not sure if this should go in the piano keys or the player
    {
       
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
