using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GruzManager : MonoBehaviour
{
    public float allKilos, completedKilos;
    public TextMeshProUGUI remainKilosText, completedKilosText;
    public GameObject winPanel;
    
    void Start()
    {
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        remainKilosText.SetText($"{allKilos - completedKilos} кг");
        completedKilosText.SetText($"{completedKilos} кг");

        if (allKilos <= completedKilos)
        {
            Win();
        }
    }

    private void Win()
    {
        GetComponent<AudioSource>().Play();
        
        Invoke(nameof(ShowWinPanel), 3f);
    }

    private void ShowWinPanel()
    {
        SceneManager.LoadScene("WinScene");
    }
}
