using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class HealthBase : MonoBehaviour
{
    public int startLife = 10;
    public bool destroyOnKill = false;
    public Rigidbody2D myRigidBody2D;
    public Vector3 rotateLocation;

    [SerializeField]private float _currentLife;
    
    private bool _isDead;


    void Awake()
    {
       Init();
    }

    private void Init()
    {
         _currentLife = startLife;
        _isDead = false;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }
    
    }

    private void Kill ()
    {
        _isDead = true;

        if(destroyOnKill)
        {
            StartCoroutine(DeathAnimation());
        }
    }
    IEnumerator DeathAnimation()
    {
        myRigidBody2D.transform.DORotate(rotateLocation, 1f, RotateMode.Fast);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
