using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 5;
    public int health = 5;

    public List<Sprite> heartsSprites;
    public Image heartsUI;

    public bool movementLeft = false;

    public Vector2 speed = new Vector2(30, 30);

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    private Animator animator;

    void Awake()
    {
        // Get the animator
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        heartsUI.sprite = heartsSprites[this.health];

        // Get axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Check if object move and flip sprite if it moves to left
        if (inputX != 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = movementLeft = inputX < 0;
        }

        // Movement per direction
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        // Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }

    }

    void FixedUpdate()
    {
        //Get the component and store the reference
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        //Move the game object
        rigidbodyComponent.velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a enemy?
        HealthScript enemy = otherCollider.gameObject.GetComponent<HealthScript>();
        if (enemy != null)
        {
            Damage(1);

            // Destroy the enemy
            Destroy(enemy.gameObject);

            animator.Play("DamagedPlayer");
        }
    }

    private void Damage(int dmg)
    {
        this.health -= dmg;
        if (health <= 0)
        {
            heartsUI.sprite = heartsSprites[this.health];
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        // Game Over.
        var gameOver = GameObject.FindObjectOfType<GameOverScript>();
        if(gameOver != null) gameOver.ShowButtons();
    }

}
