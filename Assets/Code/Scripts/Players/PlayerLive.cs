using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{

    public int live = 0;

    [Range(0, 1000)]
    public int maxLive = 100;

    private void Start()
    {
        live = maxLive; 
    }

    public void Damage(int value)
    {
        live -= value;

        if (live < 0)
            live = 0;

        if ( live == 0 )
        {
            // end !
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
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
        if (other.gameObject.CompareTag("FireEnemy"))
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
