using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManagerOfScenes : MonoBehaviour
{
    public float changeTime1;
    public string sceneName1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
            changeTime1 -= Time.deltaTime;
            if (changeTime1 < 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName1);
            }
    }
}
