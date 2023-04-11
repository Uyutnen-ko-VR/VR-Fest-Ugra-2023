using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driverScript : MonoBehaviour
{
    bool entered = false;
    public Transform parent, escapePos, playerHandler;
    public buttonScript exitButton;
    GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = other.gameObject;
            entered = true;
            player.GetComponent<moveScript>().canMove = false;
            player.GetComponent<Collider>().enabled = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.transform.SetParent(parent);
            player.transform.position = playerHandler.position;
        }
    }
    private void Update()
    {
        if(exitButton.value && entered)
        {
            entered = false;
            player.transform.SetParent(null);
            player.transform.position = escapePos.position;
            player.GetComponent<moveScript>().canMove = true;
            player.GetComponent<Collider>().enabled = true;
            player.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}