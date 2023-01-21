using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    //Movement speed
    private float movementSpeed = 5;
    public GameObject interactionPoint;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<DialogueManager>().animator.GetBool("ChatOpen"))
        {
            //Movement
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("MovingRight", true);
                transform.Translate(new Vector2(movementSpeed * Time.deltaTime, 0));
                interactionPoint.transform.position = new Vector2(transform.position.x + 0.6f, transform.position.y);
            }
            else { animator.SetBool("MovingRight", false); }
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("MovingLeft", true);
                transform.Translate(new Vector2(-movementSpeed * Time.deltaTime, 0));
                interactionPoint.transform.position = new Vector2(transform.position.x + -0.6f, transform.position.y);
            }
            else { animator.SetBool("MovingLeft", false); }
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("MovingUp", true);
                interactionPoint.transform.position = new Vector2(transform.position.x, transform.position.y + 0.6f);
                transform.Translate(new Vector2(0, movementSpeed * Time.deltaTime));
            }
            else { animator.SetBool("MovingUp", false); }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("MovingDown", true);
                transform.Translate(new Vector2(0, -movementSpeed * Time.deltaTime));
                interactionPoint.transform.position = new Vector2(transform.position.x, transform.position.y - 0.6f);
            }
            else { animator.SetBool("MovingDown", false); }
        }
       
    }
}
