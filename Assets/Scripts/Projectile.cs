using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    float dmg = 1f;

    [SerializeField]
    float lifeTime = 5f;
    float timeLived = 0f;

    new Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        this.StartCoroutine(MoveProjectile());
    }

    IEnumerator MoveProjectile()
    {
        while (timeLived < lifeTime)
        {
            yield return new WaitForFixedUpdate();
            Vector3 vec3 = this.transform.up * speed * Time.fixedDeltaTime;
            Vector2 dir = new Vector2(vec3.x, vec3.y);
            this.rigidbody.MovePosition(this.rigidbody.position + dir);

            timeLived += Time.fixedDeltaTime;
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealthObject healthObject = null;
        if (collision.gameObject.TryGetComponent<IHealthObject>(out healthObject))
        {
            healthObject.ReceiveDamage(dmg);
        }

        Destroy(this.gameObject);
    }
}
