using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDefault : MonoBehaviour
{

    private float speed = 5f, translation;
    private bool jump = false;
    private Rigidbody2D rigibody2D;

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        this.transform.Translate(translation, 0, 0);

        if (jump)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
                jump = false;
            }
        }



    }

    void OnCollisionEnter2D(Collision2D col)
    {
        jump = true;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GroundMove")
        {
            if (collision.gameObject.GetComponent<BlockMovement>().right)
            {
                this.transform.Translate(1f * Time.deltaTime, 0, 0);
            }
            else
            {
                this.transform.Translate(-1f * Time.deltaTime, 0, 0);
            }
        }
    }

}
