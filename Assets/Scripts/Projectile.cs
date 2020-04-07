using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 5.0f;
    public float speed = 10f;
    public float acceleration = 0f;
    public Vector3 firedDirection = Vector3.zero;

    Animator anim;

    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        velocity = speed * firedDirection;
        anim = GetComponent<Animator>();
        anim.SetBool("Firing", true);
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(firedDirection != Vector3.zero)
        {
            velocity += acceleration * firedDirection * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
        else
        {
            Debug.Log("Direction of fire is not set");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Projectile Trigger enter " + collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("targetExplode"))
        {
            Debug.Log("Entering Player");

            Destroy(gameObject);
        }
    }

}
