using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerControl : MonoBehaviour
{
    public GameObject projectile;

    public float speed = 0.2f;
    public float fire_interval = 0.18f;

    private float elapse = 0;

    PlayerInputActions PlayerInput;

    Rect rect;

    private void Start()
    {
        PlayerInput = new PlayerInputActions();
        PlayerInput.Player.Enable();

        rect = CameraUtils.GetRectScreenWorld();
        Debug.Log(rect);

    }

    private void Update()
    {

        if (PlayerInput == null)
            Start();

        Vector2 direction = PlayerInput.Player.Movement.ReadValue<Vector2>() * speed * Time.deltaTime;

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
                GameObject g = Instantiate(projectile, transform.position, transform.rotation);
                Destroy(g, 3);
            }
        }

    }



}
