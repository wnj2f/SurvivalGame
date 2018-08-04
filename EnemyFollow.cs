using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour 
{

	public float speed;
	public float stoppingDistance;

	private Transform target;

	Rigidbody2D rb;

	bool facingRight = true;

	Vector3 localScale;

	
	void Start () 
	{
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update()
	{
		if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
		{
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        }
	}

	void LateUpdate()
	{
		CheckWhereToFace();	
	}

	void CheckWhereToFace ()
	{
		// Check where player is relative to Enemy
        if (target.position.x < transform.position.x)
		{
			facingRight = true;
		}
		else if (target.position.x > transform.position.x)
		{
			facingRight = false;
		}

		// Reverse Sprite
		if (((facingRight) && (localScale.x > 0)) || ((!facingRight) && (localScale.x < 0)))
		{
			localScale.x *= -1;
		}

		transform.localScale = localScale;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		switch (col.tag) 
		{
			case "Platform":
				rb.AddForce (Vector2.up * 1000f);
				break;
		}
	}

}
