using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Steamworks;

public class PaueMenu : MonoBehaviour
{
    public GameObject Menu;
    public bool canQuit = false;
    void Start()
    {
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveManager.loaded)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !InventoryManager.MainInstance.InventoryIsVisibel)
            {
                Menu.SetActive(!Menu.activeSelf);

                if (Menu.activeSelf)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            }
            if (SteamManager.Initialized && SteamAPI.IsSteamRunning())
            {
                //print(SteamUtils.IsOverlayEnabled());
                //if (SteamUtils.IsOverlayEnabled())
                //    Time.timeScale = 0;
                //else
                //    Time.timeScale = 1;
            }
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void showMenu()
    {
        InventoryManager.MainInstance.InventoryIsVisibel = false;
        Menu.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnStuck()
    {
        
        PlayerMovement.PlayerInstance.Teleport(new Vector3(7, 0, 19.25f));
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        canQuit = true;
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
