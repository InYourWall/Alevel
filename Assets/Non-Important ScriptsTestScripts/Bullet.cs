using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bullet : MonoBehaviour
{
    public float life = 3;
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
 
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void start()
    {
        rb.linearVelocity = transform.right * speed;
    }
 
    void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("Player"))
		{
			Debug.Log("Damage Taken");
		}
        
        Destroy(gameObject);
    }
}
