using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    int direction = 1;
    Vector3 lastPosition;
    float distanceTravelled;
    SpriteRenderer sprite;
    CircleCollider2D circleCollider;

    public bool enableWalkDistance = false;
    public int walkDistance = 6;

    void Start()
    {
        lastPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
        circleCollider =  GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
    }

    void FixedUpdate() {

        if(enableWalkDistance) {
          distanceBasedWalk();
        }else {
          raycastBasedWalk();
        }
    }

    void raycastBasedWalk() {

        Vector3 rayInitPosition = transform.position + Vector3.down * circleCollider.radius;
        RaycastHit2D hit = Physics2D.Raycast(rayInitPosition, Vector2.down, 2);

        if (hit.collider != null)
        {
            transform.Translate(direction * Vector3.right * Time.deltaTime, Camera.main.transform);
        }else {
            direction *= -1;
            sprite.flipX = !sprite.flipX;
            transform.Translate(direction * Vector3.right * Time.deltaTime, Camera.main.transform);
        }
    }

    void distanceBasedWalk() {
        transform.Translate(direction * Vector3.right * Time.deltaTime, Camera.main.transform);
        if (distanceTravelled > walkDistance) {
            direction *= -1;
            distanceTravelled = 0;
            sprite.flipX = !sprite.flipX;
        }
    }
}
