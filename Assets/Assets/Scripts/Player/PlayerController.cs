using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float Default_Jump_Force = 1f;

    Vector3 startPos = new Vector3(-8.5f, -3.7f);
    bool isJump = false;
    float prevY = -1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
        if (isJump)
        {
            playJumpAnim();
        }
    }

    void checkInput()
    {
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        if(y > 0)
        {
            moveY(y);
        }

        if( x != 0)
        {
            moveX(x);
        }
    }
    
    void moveY(float y)
    {
        print("Y INPUT : " + y);
        if(isJump == false)
        {
            float yPos = transform.position.y;
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Default_Jump_Force * 200));
            isJump = true;
        }
    }

    void moveX(float x)
    {
        print("X INPUT : " + x);
        float xPos = transform.position.x;
    }
    
    void playJumpAnim()
    {
        if (prevY != -1)
        {
            if(transform.position.y - prevY  > 0)
            {
                gameObject.GetComponent<Animator>().SetBool("isJumpUp", true);
            } else if(transform.position.y - prevY < 0)
            {
                gameObject.GetComponent<Animator>().SetBool("isJumpUp", false);
                gameObject.GetComponent<Animator>().SetBool("isJumpDown", true);
            }

            prevY = transform.position.y;
        } else
        {
            prevY = transform.position.y;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<Animator>().SetBool("isJumpDown", false);
            isJump = false;
            prevY = -1;
        }
    }
  }
