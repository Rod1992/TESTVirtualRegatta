using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour, IHealthObject
{
    [SerializeField]
    float health = 10f;

    [SerializeField]
    float speed = 10f;

    [SerializeField]
    Projectile prefabProjectile;

    [SerializeField]
    new Rigidbody2D rigidbody2D;

    private void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.rigidbody2D.MovePosition(this.rigidbody2D.position + Vector2.left * Time.fixedDeltaTime * speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.rigidbody2D.MovePosition(this.rigidbody2D.position + Vector2.right * Time.fixedDeltaTime * speed);
        }
    }

    void Fire()
    {
        Projectile newProjectile = Instantiate<Projectile>(prefabProjectile, this.transform.position, this.transform.rotation);
    }

    void IHealthObject.ReceiveDamage(float damage)
    {
        health -= damage;

        if (health == 0)
        {
            Debug.Log("GAME OVER");
            Destroy(this.gameObject);
        }
    }
}
