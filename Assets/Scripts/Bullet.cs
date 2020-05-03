using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float speed = 3f;

    void Update()
    {
        float translation = speed * Time.deltaTime;
        transform.Translate(0, translation, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

}
