using UnityEngine;
using TMPro;


public class TopDownPlayerController: MonoBehaviour
    {
    public float moveSpeed = 5f;
    public TMP_Text playerSpeedText;
    private Rigidbody2D rb;
    public UIController controller;
    public AudioClip winSound;
    bool finished;
    void Start ( )
        {
        finished = false;
        // Get the Rigidbody2D component on the same GameObject
        rb = GetComponent<Rigidbody2D> ( );
        //controller = GetComponent<UIController> ( );
        moveSpeed =  PlayerPrefs.GetFloat ( "moveSpeed",3.69f );
        playerSpeedText.text = moveSpeed.ToString("00.00");
        }

    void Update ( )
        {
        // Input handling for movement
        if (GameManager.gameover != true)
            {
            if (!finished)
                {
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");


            Vector2 movement = new Vector2(horizontalInput, verticalInput);

            // Apply force for physics-based movement
            rb.velocity = movement * moveSpeed;
                }
            }
        else
            {
            rb.velocity = Vector3.zero;
            }

        
        }

        private void OnTriggerEnter2D ( Collider2D other )
            {
            // Check if the collided object has the tag "win"
            if (other.CompareTag ( "win" ))
                {

            // Perform actions when the collision with a "win" object occurs
            if (!finished)
                {
                Debug.Log ( "You win!" );
                controller.win ( );
                GetComponent<AudioSource> ( ).Stop ( );
                GetComponent<AudioSource> ( ).PlayOneShot ( winSound );
                }

            finished = true;
            // Add any other logic or actions you want to perform on collision with a "win" object
            }
            }
      

    public void ChangePlayerSpeed ( float playerSpeed )
        {
        moveSpeed = playerSpeed;
        playerSpeedText.text = moveSpeed.ToString("00.00");
        PlayerPrefs.SetFloat ( "moveSpeed",playerSpeed );
        print ( moveSpeed + " saved." );
        }
    }
