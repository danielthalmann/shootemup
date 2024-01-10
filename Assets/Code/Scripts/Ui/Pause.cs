using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    public GameObject menuPanel;
    public UnityEvent onExit;
    public UnityEvent onShow;
    public UnityEvent onHide;
    public bool opened = false;

    // Start is called before the first frame update
    void Start()
    {
        if (opened)
            OpenMenu();
        else
            CloseMenu();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Cancel"))
            ToggleMenu();

    }

    /// <summary>
    /// Toggle menu
    /// </summary>
    public void ToggleMenu()
    {
        if (!opened)
            OpenMenu();
        else
            CloseMenu();
    }

    /// <summary>
    /// Open the menu
    /// </summary>
    public void OpenMenu()
    {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
        opened = true;
        onShow.Invoke();
    }

    /// <summary>
    /// Close the menu
    /// </summary>
    public void CloseMenu()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        opened = false;
        onHide.Invoke();
    }

    /// <summary>
    /// Exit scene
    /// </summary>
    public void Exit()
    {
        onExit.Invoke();
    }

}
