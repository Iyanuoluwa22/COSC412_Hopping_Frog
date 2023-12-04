using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartLevel : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); ;       
    }
}
