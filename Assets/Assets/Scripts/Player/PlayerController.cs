using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float Default_Jump_Force = 1f;

    [SerializeField]
    float Move_Speed = 1f;

    Vector3 startPos = new Vector3(-8.5f, -3.7f);
    bool isJump = false;
    float prevY = -1f;

    bool isRun = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        setRotationDefault();
        checkInput();
        if (isJump)
        {
            playJumpAnim();
        }
    }

    private void LateUpdate()
    {
        if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8f, transform.position.y);
        }
    }

    void setRotationDefault()
    {
        transform.rotation = new Quaternion(0f,0f,0f,0f);
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
        } else
        {
            isRun = false;
            gameObject.GetComponent<Animator>().SetBool("isRun", isRun);
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
        isRun = true;
        float xPos = transform.position.x;
        if (x == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(xPos + Time.deltaTime * Move_Speed, transform.position.y);
            gameObject.GetComponent<Animator>().SetBool("isRun",isRun);

        }
        else if(x == -1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector3(xPos - Time.deltaTime * Move_Speed, transform.position.y);
            gameObject.GetComponent<Animator>().SetBool("isRun", isRun);
        }
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
