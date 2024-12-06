using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void QuitStage()
    {
        Debug.Log("loading Home Scene");
        SceneManager.LoadScene("HomeScene");
    }
}
