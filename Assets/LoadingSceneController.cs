using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadSceneAsync("Project");
    }
}
