using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieScene : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(ReloadScene), 5f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("FreeTokTest");
    }
}
