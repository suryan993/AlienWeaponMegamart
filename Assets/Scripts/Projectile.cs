using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    public float lifeTime = 5.0f;
    public float speed = 10f;
    public float acceleration = 0f;
    public float explosionLifetime = 1.0f;
    public Vector3 firedDirection = Vector3.zero;
    bool hit = false;
    public int minDamage = 80;
    public int maxDamage = 120;

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
        if (!hit)
        {
            if (firedDirection != Vector3.zero)
            {
                velocity += acceleration * firedDirection * Time.deltaTime;
                transform.position += velocity * Time.deltaTime;
            }
            else
            {
                Debug.Log("Direction of fire is not set");
            }
        }
        else
        {

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Projectile Trigger enter " + collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("targetExplode"))
        {
            Debug.Log("Entering Player");
            anim.SetBool("Hit", true);
            hit = true;
            Destroy(gameObject, explosionLifetime);
            float xOffset = Random.Range(-1.0f, 1.0f);
            float yOffset = Random.Range(-1.0f, 1.0f);
            Vector3 tempPos = new Vector3(collision.gameObject.transform.position.x + xOffset, collision.gameObject.transform.position.y + yOffset, 9.9f);

            int randomInt = Random.Range(minDamage, maxDamage);
            floatingTextPrefab.GetComponent<TextMesh>().text = randomInt.ToString();

            Instantiate(floatingTextPrefab, tempPos, Quaternion.identity, null);

            //Destroy(gameObject);
        }
    }

}
