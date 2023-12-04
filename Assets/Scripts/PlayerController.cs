using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;

    bool walking, jumped, jumping, grounded = false;
    float speed = 30f, height = 90f, jumpTime, walkTime;
    int moveState;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        State();
    }

    private void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.RightArrow) || !(Input.GetKey(KeyCode.UpArrow))
            || Input.GetKey(KeyCode.LeftArrow))
        {
            moveState = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
            moveState = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveState = 2;

        Jump();
    }

    void Move(Vector3 dir)
    {
        //AudioManager.instance.PlaySound(AudioManager.instance.pipe, 1f);
        walking = true;
        speed = Mathf.Clamp(speed, speed, 30f);
        walkTime += Time.deltaTime;

        transform.Translate(dir * speed * Time.fixedDeltaTime);
        if (walkTime < 3f && walking)
        {
            speed += .020f;
        }
        else if (walkTime > 3f)
        {
            speed = 25f;
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.jump, 1f);

                anim.SetBool("Jump", true);
                rbody.velocity = new Vector2(rbody.velocity.x, height);
            }
        }
        if (jumping && jumped)
        {
            rbody.gravityScale -= (0.1f * Time.fixedDeltaTime);
            
        }

        if (jumpTime > 1f)
            jumping = false;
        if (!jumping && jumped)
            rbody.gravityScale += .2f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            AudioManager.instance.PlaySound(AudioManager.instance.death, 1f);

            gameObject.SetActive(false);

            GameController.instance.GameOver();
            Time.timeScale = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumped = false;
            jumping = false;

            anim.SetBool("Jump", false);
            jumpTime = 0;
            rbody.gravityScale = 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            AudioManager.instance.PlaySound(AudioManager.instance.death, 1f);
            gameObject.SetActive(false);
            GameController.instance.GameOver();
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "up")
        {
            //nấm die
            AudioManager.instance.PlaySound(AudioManager.instance.pipe, 1f);
            var name_monster = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name_monster));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    void State()
    {
        switch (moveState)
        {
            case 1:
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),
                    transform.localScale.y, transform.localScale.z);
                Move(Vector3.right);
                break;
            case 2:
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),
                    transform.localScale.y, transform.localScale.z);
                Move(Vector3.left);
                break;
            default:
                walking = false;
                walkTime = 0;
                speed = 30f;
                anim.SetBool("Run", false);
                //AudioManager.instance.StopSound(AudioManager.instance.pipe);
                break;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            jumped = true; jumping = true;
            jumpTime += Time.fixedDeltaTime;
        }
        else jumping = false;
    }
}
