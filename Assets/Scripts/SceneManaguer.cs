using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SceneManaguer : MonoBehaviour
{
    public GameObject ivori;
    public GameObject karl;
    public GameObject ming;
    public GameObject kleon;
    public bool startCutscene1;

    private float movementSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        startCutscene1= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCutscene1)
        {
            
            if (karl.transform.position.y >= -4)
            {
                karl.GetComponent<Animator>().SetBool("MovingDown", true);
                karl.transform.Translate(new Vector2(0, -movementSpeed * Time.deltaTime));
            }
        }
    }
}
