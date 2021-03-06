﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IS_Death_zone : MonoBehaviour
{
private bool respawn;
private GameObject collidingPlayerCharater;
private GameObject levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update()
    { 
        if(respawn)
       { //grab the last good checkpoint
        Transform respawnPoint = levelManager.GetComponent<IS_LevelManager>().lastGoodCheckpoint;

        collidingPlayerCharater.transform.position = respawnPoint.transform.position;
        //its done now turn it off
        respawn = false;}
        
    }

private void OnTriggerEnter(Collider other)
{

    if(other.gameObject.tag == "Player" || other.gameObject.tag == "Box")
    {
        //this doesnt work with cc as it would need to happen in
        // other.gameObject.transform.position = respawnPoint.transform.position;

        //turn on respawn
        respawn = true;
        collidingPlayerCharater = other.gameObject;
    }



}
}