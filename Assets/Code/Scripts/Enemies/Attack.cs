using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject fire;

    public float interval = 1.0f;

    public GameObject projectile_position = null;
    public bool target_player = false;

    private float time = 0f;

    private void Start()
    {
        if (projectile_position == null)
        {
            projectile_position = this.gameObject;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (fire == null)
            return;


        if (time > interval)
        {
            GameObject obj = Instantiate(fire, projectile_position.transform.position, projectile_position.transform.rotation);
            VectorFollow vectorFollow = obj.GetComponent<VectorFollow>();
            if (vectorFollow != null)
            {
                if (target_player)
                {
                    PlayerTarget target = FindFirstObjectByType<PlayerTarget>();
                    if (target != null)
                    {
                        vectorFollow.direction = target.gameObject.transform.position - projectile_position.transform.position;
                        vectorFollow.direction.Normalize();

                    }
                }

            }
            Destroy(obj, 3);
            time = 0;
        }

        time += Time.deltaTime;
    }
}
