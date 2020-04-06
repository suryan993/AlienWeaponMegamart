using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    bool firing = false;
    Animator anim;
    public float maxProjectileDuration = 2.0f;
    float currentPorjectileDuration = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 temp = transform.position;
        projectile.transform.position = temp;
        anim = projectile.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!firing)
        {
            Vector3 temp = transform.position;
            projectile.transform.position = temp;
        } else
        {
            if (currentPorjectileDuration < maxProjectileDuration)
            {
                currentPorjectileDuration += Time.deltaTime;
                Vector3 temp = projectile.transform.position;
                temp.x += 0.1f;
                projectile.transform.position = temp;
            } else
            {
                currentPorjectileDuration = 0;
                firing = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!firing)
            {
                firing = true;
                anim.SetBool("Firing", true);
            }
        }
    }
}
