using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float JumpHeight = 3f;

    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    [Header("Foot Audio")]
    AudioSource audioSource;

    public float timeBetweenSteps;
    private float timer;
    private bool isMoving;
    public AudioClip[] Sounds;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        #region FootSteps
        if (x != 0 || z != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timeBetweenSteps;

                //     audioSource.clip = stepSounds[Random.Range(0, stepSounds.Length - 1)];
                audioSource.Play();
                //     audioSource.volume = Random.Range(.5f, 1f);
            }
        }
        else
        {
            audioSource.Stop();
            timer = timeBetweenSteps;
        }

        #endregion

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            audioSource.PlayOneShot(Sounds[1]);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        #region DamageTake




        #endregion



    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword"))//Hasar Ald�m
        {
            Debug.Log("K�l�ca  geldik");

            TakeDamage();


            if (ScoreHealt.Healt <= 0)
            {
                GameOver();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            //ToDo ; 

        }
    }

    public void GameOver()
    {
        audioSource.Stop();//ad�m sesi gelmeemsi i�in durdurdum
        audioSource.PlayOneShot(Sounds[0]);

        // Time.timeScale = 0;
        Debug.Log("Oyun bitti");
        // GameOver();
    }

    public void TakeDamage()
    {
        audioSource.PlayOneShot(Sounds[3]);
        ScoreHealt.Healt -= 20;
    }

}
