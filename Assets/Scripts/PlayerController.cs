using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform rayStart;
    private GameManager gameManager;
    public GameObject diamondEffect;

    private Rigidbody rb;
    private bool walkingRight = true;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.isStarted)
        {
            return;
        }
        else
        {
            animator.SetTrigger("GameStarted");
        }

        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameManager.isStarted)
        {
            SwitchDirection();
        }

        RaycastHit hit;
        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
           // animator.SetTrigger("IsFalling");
        }
        else
        {
            animator.SetTrigger("NotFalling");
        }

        if(transform.position.y < -2)
        {
            gameManager.EndGame();
        }
    }

    private void SwitchDirection()
    {
        walkingRight = !walkingRight;

        if (walkingRight)
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Diamond"))
        {
            gameManager.IncreaseScore();

            GameObject gameObject = Instantiate(diamondEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, 2);
            Destroy(other.gameObject);
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        Destroy(collision.gameObject, 2);
    }
}
