using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerJump : MonoBehaviour
{

    [SerializeField]
    private AudioClip jumpClip;

    private float jumpForce = 12f, forwardForce = 0f;

    private Rigidbody2D myBody;

    private bool canJump, onAir;

    private Button jumpBtn;

    void Awake()
    {
        onAir = false;
        myBody = GetComponent<Rigidbody2D>();

        jumpBtn = GameObject.Find("Jump Button").GetComponent<Button>();

        jumpBtn.onClick.AddListener(() => Jump());
    }

    void Update()
    {
        if (Mathf.Abs(myBody.velocity.y) == 0)
        {
            canJump = true;
        }
        if (onAir == true)
        {
            if (transform.localPosition.x < 0)
            {
                if (transform.localPosition.y > -1.0f)
                {
                    myBody.AddForce(new Vector2(125.0f, 0.0f));
                    onAir = false;                  
                }
            }
        }
        if(transform.localPosition.x > 0)
        {
            float tempY = transform.localPosition.y;
            transform.position = new Vector3(0.0f, tempY,-5.0f);
        }
    }

    public void Jump()
    {
        if (canJump)
        {
            canJump = false;
            onAir = true;

            AudioSource.PlayClipAtPoint(jumpClip, transform.position);

            if (transform.position.x < 0)
            {
                forwardForce = 1f;
            }
            else
            {
                forwardForce = 0f;
            }

            //transform.Translate (Vector2.zero);
            myBody.velocity = new Vector2(forwardForce, jumpForce);
        }

    }


} //PlayerJump















































