using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CohenHoverPad : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject panel;
    public Material material;
    //HEX CODE FOR RED COLOR FF5A58


    private void OnTriggerEnter(Collider other)
    {
        //panel.SetActive(true);
        //Debug.Log("Player Entered trigger");
        //material.color = Color.green;
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Player is within trigger");
        //material.color = Color.green;
        //panel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Player Left trigger");
        //panel.SetActive(false);
        //material.color = Color.red;
    }
}
