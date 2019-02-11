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
    public Graph graph;
    public Follower follower;
    public GameObject[] nodes;
    public Node[] allNodes;
    private Node startNode;
    private Node finishNode ;

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
       /* if (objective.getCurrentTarget() != null)
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
        }*/
    }

    public void beginGuidance(GameObject startPosition, GameObject destination)
    {

        /*GameObject beginningNode = GameObject.Find(startPosition.name);
        GameObject finishingNode = GameObject.Find(destination.name);
        Node startPositionNode = GameObject.Find(beginningNode.name).GetComponent<Node>();
        Node finishingPositionNode = GameObject.Find(finishingNode.name).GetComponent<Node>();*/

        
        nodes = GameObject.FindGameObjectsWithTag("Nodes");
        allNodes = new Node[nodes.Length];
        for (int i = 0; i < nodes.Length; i++)
        {
            allNodes[i] = nodes[i].GetComponent<Node>();
        }
        

       

        for( int i = 0; i < allNodes.Length; i++)
        {
            if( allNodes[i].name == startPosition.name)
            {
                setStartNode(allNodes[i]);

            }

            if ( allNodes[i].name == destination.name)
            {
                setDestNode(allNodes[i]);
            }
        }

        print("Start Node: " + getStartNode().name);
        print("Finish Node: " + getDestNode().name);
        
        
        follower.Follow(graph.GetShortestPath(getStartNode(), getDestNode()));
        
    }

    private void setStartNode(Node start)
    {
        startNode = start;
    }

    private void setDestNode(Node dest)
    {
        finishNode = dest;
    }

    private Node getStartNode()
    {
        return startNode;
    }

    private Node getDestNode()
    {
        return finishNode;
    }
}
