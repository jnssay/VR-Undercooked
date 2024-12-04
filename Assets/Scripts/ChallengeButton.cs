using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadStage()
    {
        Debug.Log("loading stage 1");
        SceneManager.LoadScene("XR Interaction");
    }
}
