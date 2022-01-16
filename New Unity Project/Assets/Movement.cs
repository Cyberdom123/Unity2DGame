using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private SpriteRenderer mySpriteRender;

    public Rigidbody2D Player;

    Vector2 movement;

    void Start()
    {
        mySpriteRender = GetComponent<SpriteRenderer>();
    }

    void Update() //lustrzane odbice przy poruszaniu w lewo lub prawo
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < 0 && Player.bodyType == RigidbodyType2D.Dynamic)
        {
            mySpriteRender.flipX = true;
        }
        if (movement.x > 0 && Player.bodyType == RigidbodyType2D.Dynamic)
        {
            mySpriteRender.flipX = false;
        }

    }

    void FixedUpdate()
    {
        if (Player.bodyType == RigidbodyType2D.Dynamic)
        {
            Player.MovePosition(Player.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
