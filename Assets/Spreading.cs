using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spreading : MonoBehaviour
{
    public bool canSpread;
    public float timer;

    public GameObject spreadOrNot;

    public Collider2D contect;

    public bool isContecting;

    public CollectStuff collectstuff;

    public List<GameObject> zombieType;
    public int zombie;



 
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(contect);

        if (Input.GetKeyDown(KeyCode.Space) && timer >= 3f && canSpread)
        {
            timer = 0f;
            
            //contect.transform.GetComponent<NPC_MoveAI>().enabled = false;
            Spread();
            

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if(collision.transform.tag == "scientist" || collision.transform.tag == "cleaner" || collision.transform.tag == "guard")
        {
            canSpread = true;

            contect = collision.collider;
            //spreadOrNot.transform.gameObject.SetActive(true);

        }

        if(collision.transform.tag == "scientist")
        {
            zombie = 0;
        }
        if (collision.transform.tag == "cleaner")
        {
            zombie = 1;
        }
        if (collision.transform.tag == "guard")
        {
            zombie = 2;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        contect = null;

        canSpread = false;
        //spreadOrNot.transform.gameObject.SetActive(false);


    }


    void Spread()
    {
        //collectstuff.IDcard = contect.transform.GetComponent<CollectStuff>().IDcard;

        GameObject newPlayer = Instantiate(zombieType[zombie], this.transform.position, this.transform.rotation);

        newPlayer.GetComponent<CollectStuff>().IDcard = contect.transform.GetComponent<CollectStuff>().IDcard;

        Destroy(contect.gameObject);
        Destroy(this.gameObject);

    }

}
