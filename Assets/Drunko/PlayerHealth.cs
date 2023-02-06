using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    float cd;

    public GameObject hurt;
    private void Update()
    {
        hurt = GameObject.Find("Hurt");
        cd += Time.deltaTime;

        if(health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("GameOver");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("attack") && cd >= 0.5f)
        {
            health -= 1;
            StartCoroutine(hurtPanel());
            
            cd = 0;
        }
    }
    IEnumerator hurtPanel()
    {
        hurt.transform.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(0.15f);
        hurt.transform.GetComponent<Image>().enabled = false;
    }
}
