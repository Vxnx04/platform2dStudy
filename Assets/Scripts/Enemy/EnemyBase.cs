using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Vector3 rotateLocation;
    public Rigidbody2D myRigidBody2D;
    public BoxCollider2D boxCollider2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
            boxCollider2D.enabled = false;
            StartCoroutine(DeathAnimation());
        }
    }

    IEnumerator DeathAnimation()
    {
        myRigidBody2D.transform.DORotate(rotateLocation, 0.3f, RotateMode.Fast);
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
