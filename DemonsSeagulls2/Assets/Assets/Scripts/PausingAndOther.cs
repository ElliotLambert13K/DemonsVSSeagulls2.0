using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingAndOther : MonoBehaviour
{
    public GameObject PauseMenu;
    private bool pauseMenuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseMenuOpen = !pauseMenuOpen;

            if (pauseMenuOpen)
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
            }

            if (!pauseMenuOpen)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
