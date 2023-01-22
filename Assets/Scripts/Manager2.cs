using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager3 : MonoBehaviour
{
    public float changeTime3;
    public string sceneName3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        changeTime3 -= Time.deltaTime;
        if (changeTime3 < 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName3);
        }
    }
}
