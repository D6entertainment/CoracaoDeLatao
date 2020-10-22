using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfPause : MonoBehaviour
{
    public bool m_IsPaused { get; set; }
    public GameObject m_confPanel;
    public void showPanel()
    {
        m_confPanel.SetActive(true);
        m_IsPaused = true;
        Time.timeScale = 0.0f;//todo tempo vai ter multiplicado por zero e vai parar 
        
    }
    public void hidePanel()
    {
        m_confPanel.SetActive(false);
        m_IsPaused = false;
        Time.timeScale = 1.0f;
    }

    private void Update()
    {

    }

}

