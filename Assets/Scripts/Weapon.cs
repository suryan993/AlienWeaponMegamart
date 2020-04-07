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
        shootDir = targetDir;
        remainingShots = numProjToBeShot;
        Shoot();
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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isPickable = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
