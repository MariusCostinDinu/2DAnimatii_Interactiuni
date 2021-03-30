using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float projectileSpeed = 0.00001f;


    // Update is called once per frame
    void Update()
    {
        shootUp();
    }

    private void shootUp()
    {
        transform.Translate(projectileSpeed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D transformCollision)
    {
        if (transformCollision.gameObject.CompareTag("Enemy"))
        {
            Destroy(transformCollision.gameObject);
   
        }
    }

}
