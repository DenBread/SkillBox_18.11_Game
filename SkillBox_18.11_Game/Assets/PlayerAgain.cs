using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAgain : MonoBehaviour
{
    public void RestartLvl()
    {
        SceneManager.LoadScene(0);
    }
}
