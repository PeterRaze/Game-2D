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
    float count;

    public enum walkTypes {Raycast, Straight, Sinusoid, Vertical};
    public walkTypes WalkType;

    public float walkDistance = 6f;
    public float walkSpeed = 1f;

    public float verticalSpeed = 5f;
    public float amplitude = 0.02f;

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
      switch (WalkType) {
          case walkTypes.Raycast:
              raycastBasedWalk();
              break;
          case walkTypes.Straight:
              distanceBasedWalk();
              break;
          case walkTypes.Vertical:
              verticalFloatBaseWalk();
              break;
          default:
              sinusoidBasedWalk();
              break;
       }
    }

    void raycastBasedWalk() {

        Vector3 rayInitPosition = transform.position + Vector3.down * circleCollider.radius;
        RaycastHit2D hit = Physics2D.Raycast(rayInitPosition, Vector2.down, 1);

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
        transform.Translate(direction * Vector3.right * Time.deltaTime * walkSpeed, Camera.main.transform);
        if (distanceTravelled > walkDistance) {
            direction *= -1;
            distanceTravelled = 0;
            sprite.flipX = !sprite.flipX;
        }
    }

    void sinusoidBasedWalk() {
        transform.Translate(direction * Vector3.right * Time.deltaTime, Camera.main.transform);
        transform.Translate(Vector3.up * Mathf.Sin(Time.time * verticalSpeed) * amplitude, Camera.main.transform);
        if (distanceTravelled > walkDistance) {
            direction *= -1;
            distanceTravelled = 0;
            sprite.flipX = !sprite.flipX;
        }
    }

    void verticalFloatBaseWalk() {
        transform.Translate(Vector3.up * Mathf.Sin(Time.time * verticalSpeed) * amplitude, Camera.main.transform);
        int random = Random.Range(3, 8);
        count += Time.deltaTime;
        if(count > random) {
            sprite.flipX = !sprite.flipX;
            count = 0;
        }
    }
}
