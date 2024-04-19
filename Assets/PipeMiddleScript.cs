using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        //To find and reference the LogicScript ( cannot be done the drag and drop way, due to instance of script not being on a game object & pipe spawner doesnt exisist until game starts running)
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When invisible middle object is hit, trigger this function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //could use just logic.addScore() BUT we cant to make sure only bird will trigger by using if and it's layer. (Future proofing game, if we add more stuff)
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
        }        
    }
}
