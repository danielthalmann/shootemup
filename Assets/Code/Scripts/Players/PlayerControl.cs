using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void FixedUpdate()
    {

        if (PlayerInput == null)
            Start();

        Vector2 direction = PlayerInput.Player.Movement.ReadValue<Vector2>() * speed;

        Vector2 position2D = new Vector2(transform.position.x, transform.position.y);

        if ( rect.Contains(position2D + direction) )
            transform.Translate(direction);

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
