using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class character : MonoBehaviour
{
    [SerializeField] private LayerMask groundLMask;
    public float velocity = 5;
    public float jumpVelocity = 5;
    private float distanceToJump = .3f;
    private int face = 1;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    private bool isGrounded()
    {
        float extraray = 0.01f;
        Vector3 p1, p2;
        p1 = transform.position + new Vector3(distanceToJump, 0, 0);
        p2 = transform.position + new Vector3(-distanceToJump, 0, 0);
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        Debug.DrawRay(p1, Vector2.down * .8f, Color.green);
        RaycastHit2D r1 = Physics2D.Raycast(p1, Vector2.down * .8f, 1f, groundLMask);
        Debug.DrawRay(p2, Vector2.down * .8f, Color.green);
        RaycastHit2D r2 = Physics2D.Raycast(p2, Vector2.down * .8f, 1f, groundLMask);
        
        return r1.collider || r2.collider;
    }

    private void turnLeft()
    {
        face = -1;
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    private void turnRigth()
    {
        face = 1;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move;
        float horisontalmove;
        horisontalmove = Input.GetAxis("Horizontal")*velocity;
        move = new Vector3(horisontalmove,0,0);
        if (horisontalmove < 0)
        {
            turnLeft();
        }
        if (horisontalmove > 0)
        {
            turnRigth();
        }


        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
        
        transform.position += move * Time.deltaTime;
    }
}
