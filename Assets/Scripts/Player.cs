using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce;
    Rigidbody2D rb;
    // Start is called before the first frame update
    bool holdingWeapon;
    GameObject currWeapon;
    GameObject prevWeapon;
    public GameObject shopText1;
    public GameObject shopText2;
    Animator anim;


    Transform mTransform;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 force = Vector2.ClampMagnitude(new Vector2(x, y), 1); //"Normalise" the vector made from input axis value

        force *= moveForce;
        //Debug.Log(transform.position.y + moveY);
        Vector3 mouseDir = GetNormalizedDirectionToMouse();
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, mouseDir);

        rb.AddForce(force);

        if (holdingWeapon)
        {
            currWeapon.transform.position = transform.position;
            currWeapon.transform.rotation = Quaternion.LookRotation(Vector3.forward, mouseDir);
        }

        if(Input.GetMouseButtonDown(0))// If left button is pressed
        {
            if (holdingWeapon)
            {
                currWeapon.GetComponent<Weapon>().Fire(mouseDir);
            }
        }
    }

   
    public Vector3 GetNormalizedDirectionToMouse()
    {
        Vector3 viewPortActual, viewPortDelta, directionToMouse;

        // Calculate a direction based on the Mouse Position (using Viewport)
        viewPortActual = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        viewPortDelta = new Vector3(0.5f, 0.5f, 0); // Detract Half the screen
        directionToMouse = viewPortActual - viewPortDelta; // Caculate Direction
        return directionToMouse.normalized; // Return normalized Direction
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Trigger enter " + collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("Weapon"))  //get bread, reduce cleanliness
        {
            anim.SetBool("WeaponPicked", true);
            shopText2.GetComponent<TextMesh>().text = "Target dummies are in the back";
            if (!collision.gameObject.GetComponent<Weapon>().isPickable)
                return;

            holdingWeapon = true;

            if (currWeapon)
            {
                currWeapon.GetComponent<Weapon>().isPickable = false;
                currWeapon.GetComponent<BoxCollider2D>().enabled = true;
            }

            prevWeapon = currWeapon;
            currWeapon = collision.gameObject;

            currWeapon.GetComponent<BoxCollider2D>().enabled = false;

            shopText1.GetComponent<TextMesh>().text = currWeapon.GetComponent<Weapon>().description;
            //gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
        }
    }

}