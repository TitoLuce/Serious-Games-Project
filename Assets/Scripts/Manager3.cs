using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager2 : MonoBehaviour
{
    public float changeTime2;
    public string sceneName2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        changeTime2 -= Time.deltaTime;
        if (changeTime2 < 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName2);
        }
    }
}
