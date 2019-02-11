using UnityEngine;
using UnityEngine.AI;

public class PlayerNavController : MonoBehaviour
{
    public Objective objective;
    public Camera cam;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        /*
        if(objective.getCurrentTarget() != null)
        {
            Ray ray = cam.ScreenPointToRay(objective.getCurrentTarget().transform.position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //MOVE AGENT
                agent.SetDestination(hit.point);
            }
        }
        */
    }
}
