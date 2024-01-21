using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerControl : MonoBehaviour
{
    public GameObject projectile;
    public GameObject projectile_position;
    public GameObject prefab_starship;

    public float speed = 0.2f;
    public float fire_interval = 0.18f;

    private float elapse = 0;

    PlayerInputActions PlayerInput;

    Rect rect;

    Vector2 last_rotation;

    private void Start()
    {
        PlayerInput = new PlayerInputActions();
        PlayerInput.Player.Enable();

        rect = CameraUtils.GetRectScreenWorld();
        
        if (!projectile_position)
        {
            projectile_position = gameObject;
        }
        last_rotation = Vector2.zero;

    }

    private void Update()
    {

        if (PlayerInput == null)
            Start();

        Vector2 direction = PlayerInput.Player.Movement.ReadValue<Vector2>() * speed * Time.deltaTime;
        applyRotation(direction);

        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + direction;

        if ( !rect.Contains(newPosition) )
        {
            if (newPosition.y < rect.y)
            {
                newPosition.y = rect.y;
            }
            if (newPosition.y > rect.y + rect.height)
            {
                newPosition.y = rect.y + rect.height;
            }
            if (newPosition.x < rect.x)
            {
                newPosition.x = rect.x;
            }
            if (newPosition.x > rect.x + rect.width)
            {
                newPosition.x = rect.x + rect.width;
            }
        }
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

        elapse += Time.deltaTime;

        if (PlayerInput.Player.Fire.IsPressed())
        {
            if (elapse > fire_interval) {
                elapse = 0;
                GameObject g = Instantiate(projectile, projectile_position.transform.position, projectile_position.transform.rotation);
                Destroy(g, 3);
            }
        }

    }

    public void applyRotation(Vector2 direction)
    {
        Vector2 rotation_anim = Vector2.zero;

        float angle_anim = 20;
        float speed_rotation = 8;

        if (direction.x > 0)
        {
            rotation_anim.x = -angle_anim;
        }
        else if (direction.x < 0)
        {
            rotation_anim.x = angle_anim;
        }
        if (direction.y > 0)
        {
            rotation_anim.y = angle_anim;
        }
        else if (direction.y < 0)
        {
            rotation_anim.y = -angle_anim;
        }

        last_rotation = Vector2.Lerp(last_rotation, rotation_anim, Time.deltaTime * speed_rotation);

        prefab_starship.transform.rotation = Quaternion.Euler(last_rotation.y, last_rotation.x, 0);
    }


}
