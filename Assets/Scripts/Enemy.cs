using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealthObject
{
    public float health = 1f;

    public float fireRate = 2f;
    public float coolDownTime = 1f;


    [SerializeField]
    Projectile prefabProjectile;


    void Update()
    {
        if(coolDownTime <= 0f)
        {
            coolDownTime = fireRate;
            Fire();
        }
        coolDownTime -= Time.deltaTime;
    }

    void Fire()
    {
        Projectile newProjectile = Instantiate<Projectile>(prefabProjectile, this.transform.position, this.transform.rotation);
    }

    void IHealthObject.ReceiveDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Dead Enemy");
            Destroy(this.gameObject);
        }
    }
}
