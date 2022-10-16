using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float hurtDamage;

    //should probably be on the player and water respectively... no time
    private void OnTriggerStay2D(Collider2D collision)
    {
        

        //player hurt
        if(GameManager.instance.players.Count > 0)
        {
            if (collision == GameManager.instance.players[0].gameObject.GetComponent<Collider2D>())
            {
                

                GameManager.instance.players[0].GetComponent<Health>().TakeDamage(hurtDamage);
            }
        }
        
    }

    public void Extinguish()
    {
        GameManager.instance.firesPutOut += 1;

        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
