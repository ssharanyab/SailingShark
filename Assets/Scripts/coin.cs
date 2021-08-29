using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(20*Time.deltaTime,0,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.numberOfcoins += 1;
            Debug.Log(PlayerManager.numberOfcoins);
            FindObjectOfType<AudioManager>().PlaySound("Pickcoin");
            Destroy(gameObject);
        }
    }
}
