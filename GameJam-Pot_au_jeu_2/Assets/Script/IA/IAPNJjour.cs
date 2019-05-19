using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class IAPNJjour : MonoBehaviour
{
    public GameObject waypoints;
    private Transform[] waypointsArray;
    private Transform target;
    public CharacterAnimationController animationController;
    private Vector3 lastPosition;
    public AIDestinationSetter destinationSetter;
    public AILerp lerp;
    private bool isPlayerNear;
    // Start is called before the first frame update
    void Start()
    {

        if (waypoints)
            waypointsArray = waypoints.GetComponentsInChildren<Transform>();
        pickNewCurrentWaypoint();
        destinationSetter.target = target;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerNear)
        {
            if (lerp.enabled == false)
            {
                lerp.enabled = true;
            }
            if (lerp.reachedDestination)
            {
                pickNewCurrentWaypoint();
                destinationSetter.target = target;
                lerp.enabled = false;
                lerp.enabled = true;
            }

            Vector2 currentInput = new Vector2(0, 0);
            if ((transform.position - lastPosition).x > 0.01)
                currentInput.x = 1;
            if ((transform.position - lastPosition).x < -0.01)
                currentInput.x = -1;
            if ((transform.position - lastPosition).y > 0.01)
                currentInput.y = 1;
            if ((transform.position - lastPosition).y < -0.01)
                currentInput.y = -1;
            animationController.input = currentInput;
            lastPosition = transform.position;
        }
        else
        {
            lerp.enabled = false;
            animationController.input = new Vector2(0, 0);
        }

    }



    public void pickNewCurrentWaypoint()
    {
        Transform newWaypoint = waypointsArray[Random.Range(1, waypointsArray.Length)];
        while (newWaypoint == target)
        {
            newWaypoint = waypointsArray[Random.Range(1, waypointsArray.Length)];
        }
        target = newWaypoint;
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerNear = true;
        }


    }

    public void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.tag == "Player")
        {
            isPlayerNear = false;
        }
    }


}
