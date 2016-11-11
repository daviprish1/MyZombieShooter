using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveScript : MonoBehaviour {

    public bool foeMovement = false;

    public Vector2 speed = new Vector2(10, 10);

    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Direction for foe movement
        if (foeMovement && GameObject.Find("Player") != null)
        {
            Transform plTransform = GameObject.Find("Player").GetComponent<Transform>();
            Transform oTransform = gameObject.GetComponent<Transform>();
            direction.x = plTransform.position.x < oTransform.position.x ? -1 : 1;
            direction.y = plTransform.position.y < oTransform.position.y ? -1 : 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = direction.x > 0;
        }

        // Movement
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // Apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }
}
