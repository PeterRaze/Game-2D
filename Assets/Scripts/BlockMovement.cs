using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{

    private float speed = 1f;
    public bool right = true;
    
    void Update()
    {
        float translation = speed * Time.deltaTime;

        if (right)
        {
            this.transform.Translate(translation, 0, 0);
        }
        else
        {
            this.transform.Translate(-translation, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            right = !right;
        }
    }


}
