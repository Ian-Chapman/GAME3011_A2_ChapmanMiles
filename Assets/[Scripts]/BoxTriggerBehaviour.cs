using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerBehaviour : MonoBehaviour
{
    public UIManager uIManager;
    
    public GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uIManager.instructionsPanel.SetActive(true);
            uIManager.difficultyPanel.SetActive(true);
        }
    }
}
