using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float jump = 9.0f;
    public float speed = 3.0f;
    Rigidbody2D rbody;
    float axisH = 0.0f;
    bool goJump = false;
    public LayerMask ground;
    public static string gameState = "playing";
    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        gameState = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing") { return; }
        axisH = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (gameState != "playing") { return; }
        bool onGround = Physics2D.CircleCast(new Vector2(transform.position.x,transform.position.y-transform.localScale.y*0.5f), 0.2f, Vector2.down, 0.0f, ground);
        if (onGround||axisH != 0.0f)
        {
            rbody.velocity = new Vector2(speed * axisH, rbody.velocity.y);
        }
        if (onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0.0f, jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            GameOver();
            Debug.Log("GameOver");
        }
    }
    public void Jump()
    {
        goJump = true;
    }
    public void GameOver()
    {
        Rigidbody2D rbody = this.GetComponent<Rigidbody2D>();
        rbody.velocity = Vector2.zero;
        gameState = "gameOver";
    }
}
