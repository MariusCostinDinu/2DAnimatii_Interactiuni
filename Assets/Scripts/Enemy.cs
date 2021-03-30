using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;

    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;
   

    Rigidbody2D rigidbody;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            rigidbody.velocity = new Vector2(moveSpeed, 0f);
        }else
        {
            rigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }          
  }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody.velocity.x)), transform.localScale.y);
    }

    private void OnCollisionEnter2D(Collision2D transformCollision)
    {
        if (transformCollision.gameObject.CompareTag("Player"))
        {
            Destroy(transformCollision.gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
