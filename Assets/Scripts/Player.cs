using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce;
    Rigidbody2D rb;
    // Start is called before the first frame update
    bool holdingWeapon;
    GameObject weapon;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 force = Vector2.ClampMagnitude(new Vector2(x, y), 1); //"Normalise" the vector made from input axis value

        force *= moveForce;
        //Debug.Log(transform.position.y + moveY);

        rb.AddForce(force);

        if (holdingWeapon)
        {
            weapon.transform.position = transform.position;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Weapon"))  //get bread, reduce cleanliness
        {
            holdingWeapon = true;
            weapon = collision.gameObject;
            //gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
