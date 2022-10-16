using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //extinguish
        if(other.gameObject.GetComponent<Fire>() != null)
        {
            other.gameObject.GetComponent<Fire>().Extinguish();
        }
        else if (other.gameObject.tag == "Wall") {
            gameObject.SetActive(false);
        }
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
