using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class coiso : MonoBehaviour
{
    [SerializeField] private LayerMask groundLMask;
    public float velocity = 1;
    public float jumpVelocity = 5;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    private bool isGrounded()
    {
        float extraray = 0.01f;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        Debug.DrawRay(transform.position, Vector2.down * .8f, Color.green);
        RaycastHit2D r = Physics2D.Raycast(transform.position, Vector2.down * .8f, 1f, groundLMask);
        Debug.Log(r.collider);
        return r.collider;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move;
        float horisontalmove;
        horisontalmove = Input.GetAxis("Horizontal")*velocity;
        move = new Vector3(horisontalmove,0,0);
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
        
        transform.position += move * Time.deltaTime;
    }
}
