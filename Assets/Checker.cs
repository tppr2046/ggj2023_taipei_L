using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{   
    public GameObject withKeyNpc;
    GameObject player;
    GameObject sporePlayer;
    public Animator GameOverPanel;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sporePlayer = GameObject.FindGameObjectWithTag("RootsPlayer");

        if (player.GetComponent<CollectStuff>().IDcard == false && withKeyNpc == null && sporePlayer == null)
        {
            Debug.Log("GameOver");
            GameOverPanel.gameObject.SetActive(true);
            GameOverPanel.Play("GameOver");
        }
        if (player.GetComponent<PlayerHealth>().health <= 0)
        {
            GameOverPanel.gameObject.SetActive(true);
            GameOverPanel.Play("GameOver");
        }
    }


}
