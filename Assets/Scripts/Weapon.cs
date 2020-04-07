using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public int numProjToBeShot;
    public float timeBetweenShots;
    public bool isPickable = true;
    public string description;
    bool shooting = false;

    int remainingShots;
    Vector3 shootDir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(Vector3 targetDir)
    {
        if (!shooting)
        {
            shooting = true;
            //shootDir = targetDir;
            shootDir = GetNormalizedDirectionToMouse();
            remainingShots = numProjToBeShot;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject proj = Instantiate(projectile, transform.position, transform.rotation);
        proj.GetComponent<Projectile>().firedDirection = shootDir;
        remainingShots--;
        if(remainingShots > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }

        Invoke("disableShooting", timeBetweenShots*numProjToBeShot*2);
    }

    private void disableShooting()
    {
        shooting = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isPickable = true;
            GetComponent<BoxCollider2D>().enabled = true;
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
}
