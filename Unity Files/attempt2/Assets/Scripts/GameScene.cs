using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameScene : MonoBehaviour
{
    public GameObject arrowBackground;
    public Transform arrow;
    private Transform playerTransform;
    public Objective objective;

    // Start is called before the first frame update
    void Start()
    {
        //Find the player transform
        playerTransform = FindObjectOfType<UserMovement>().transform;
        FindObjectOfType<GoGuideScript>().gameScene = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (objective.getCurrentTarget() != null)
        {
            arrowBackground.SetActive(true);


            //if we have an objective
            Vector3 dir = playerTransform.InverseTransformPoint(objective.getCurrentTarget().transform.position);
            float a = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            a += 180;
            arrow.transform.localEulerAngles = new Vector3(0, 180, a);

        }
        else
        {
            arrowBackground.SetActive(false);
        }
    }

    public void beginGuidance()
    {
       
    }
}
