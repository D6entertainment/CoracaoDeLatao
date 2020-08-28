using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public bool m_IsPaused { get; set; }
    public GameObject m_PausePanel;
    public void showPanel()
    {
        m_PausePanel.SetActive(true);
        m_IsPaused = true;
        Time.timeScale = 0.0f;//todo tempo vai ter multiplicado por zero e vai parar 
    }
   public void hidePanel()
    {
        m_PausePanel.SetActive(false);
        m_IsPaused = false;
        Time.timeScale = 1.0f;
    }
    public void toogle()
    {
        if (m_IsPaused) 
        {
            hidePanel();
        }
        else
        {
            showPanel();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toogle();
        }
    }
}
