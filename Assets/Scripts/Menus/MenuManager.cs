using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] m_menus;
    [SerializeField]
    private int m_defaultMenu = 0;
    private int m_currentMenu;
    [SerializeField]
    private bool m_showMenus = true;

    [SerializeField]
    private int m_currentlySelectedOption = 0;
    [SerializeField]
    private float m_navigationDelay = 0.5f;
    private float m_navigationWaitTime = 0;

    [SerializeField]
    private int[] m_parentMenus;

    private MenuAudioManager m_menuAudio;
    private bool m_accessingDropDown = false;

    void Start()
    {
        m_currentMenu = m_defaultMenu;

        if (m_showMenus)
            ShowCurrentMenu();

        m_navigationWaitTime = m_navigationDelay;

        m_menuAudio = GetComponentInChildren<MenuAudioManager>();

        // ✅ If we're in gameplay, lock the cursor
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "SurvivalGameScene" || currentScene == "TrainingGameScene")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Update()
    {
        // If needed, menu navigation logic can go here
    }

    public void Button_GoToMenu(int menuIndex)
    {
        m_currentMenu = menuIndex;
        ShowCurrentMenu();

        // ✅ Unlock and show cursor when switching to menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Button_GoToScene(int sceneIndex)
    {
        // ✅ Optionally lock cursor if going to gameplay scene
        LockCursorIfGameplay(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

    public void Button_GoToScene(string sceneName)
    {
        // ✅ Optionally lock cursor if going to gameplay scene
        LockCursorIfGameplay(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void Button_QuitGame()
    {
        Application.Quit();
    }

    public void ShowMenus(bool b)
    {
        m_showMenus = b;

        if (b == false)
        {
            m_menus[m_currentMenu].SetActive(false);
            m_currentMenu = m_defaultMenu;
        }

        ShowCurrentMenu();
    }

    private void ShowCurrentMenu()
    {
        for (int i = 0; i < m_menus.Length; i++)
        {
            m_menus[i].SetActive(i == m_currentMenu);
        }
    }

    private void LockCursorIfGameplay(int sceneIndex)
    {
        // If you want to lock the cursor automatically when loading gameplay scenes by index, handle it here.
        // Optional: Based on index logic (e.g., scene 1 is gameplay)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LockCursorIfGameplay(string sceneName)
    {
        if (sceneName == "SurvivalGameScene" || sceneName == "TrainingGameScene")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

