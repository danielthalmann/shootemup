using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerLive : MonoBehaviour
{

    public int live = 0;

    [Range(0, 1000)]
    public int maxLive = 100;
    public string collisionTagName = "Enemy";
    public string triggerTagName = "FireEnemy";

    public UnityEvent<float> onChangeLive;
    public UnityEvent<int> onDamage;
    public UnityEvent onDeath;


    private void Start()
    {
        live = maxLive; 
    }

    public void Damage(int value)
    {

        if (live > 0) {
            live -= value;
            if (live < 1) {
                live = 0;
                onDeath.Invoke();
            } else {
                onDamage.Invoke(value);
            }
        }

        onChangeLive.Invoke((float)(live) / maxLive);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(collisionTagName))
        {
            Explosion ex = collision.gameObject.GetComponent<Explosion>();
            ex.Explose();
            Damage d = collision.gameObject.GetComponent<Damage>();
            if ( d != null )
            {
                Damage(d.damageValue);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(triggerTagName))
        {
            Damage d = other.gameObject.GetComponent<Damage>();
            if (d != null)
            {
                Damage(d.damageValue);
            }

            Destroy(other.gameObject);
        }
    }

}
