using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector3 jump;
    public float moveSpeed = 5;
    public float smoothBlend = 0.1f;
    public Rigidbody rb;
    float horizontalInput;
    public float jumpForce = 2.0f;
    public float horizontalMultiplier = 2;
    Animator animator;

    public GameObject[] canvasGameOver;

    float y = 0.5f;
    float x = 1;

    public bool isGrounded;

    void Start() {
        animator = GetComponent<Animator>();   
        animator.SetBool("run", true);
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    private void FixedUpdate() {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("speed", x, smoothBlend, Time.deltaTime);
            moveSpeed = 2;
        } else
        {
            animator.SetFloat("speed", y, smoothBlend, Time.deltaTime);
            if (moveSpeed == 2){
                moveSpeed = Mathf.Lerp(2, 5, 1);
                
            }
            
        }
        Vector3 fowardMove = transform.forward * moveSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * moveSpeed * Time.deltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + fowardMove + horizontalMove);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("space") && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Jump" && !isGrounded)
        {
            animator.SetTrigger("jump");
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = true;
        }
        if(transform.position.y < -5)
        {
            Die();
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
        
        if(col.gameObject.tag == "Obstacle")
        {
            Die();
        }
        
    }

    void Die() 
    {
        Time.timeScale = 0;
        canvasGameOver[0].SetActive(true);
        canvasGameOver[1].SetActive(false);
        
    }

    public void BackToMenu()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(0);
    }
}
