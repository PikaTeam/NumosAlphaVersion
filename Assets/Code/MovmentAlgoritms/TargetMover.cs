using Assets.Scripts._0_bfs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component moves its object towards a given target position.
 */
public class TargetMover: MonoBehaviour 
{
    Vector2 NextStep;


    [Tooltip("The speed by which the object moves towards the target, in meters (=grid units) per second")]
    [SerializeField] float speed = 3f;

    [Tooltip("Maximum number of iterations before BFS algorithm gives up on finding a path")]
    [SerializeField] int maxIterations = 1000;

    [Tooltip("The target position in world coordinates")]
    [SerializeField] Vector2 targetInWorld;

    [Tooltip("The target position in grid coordinates")]
    [SerializeField] Vector2 targetInGrid;

    [SerializeField] Vector2 TopLeft,BottomRight;

    //the loader chacekr;
    //PlayerStatusData damage;

    protected bool atTarget;  // This property is set to "true" whenever the object has already found the target.

    public void SetTarget(Vector2 newTarget)
    {
        
        if (targetInWorld != newTarget) {
            targetInWorld = newTarget;
            targetInGrid = new Vector2(round(targetInWorld.x), round(targetInWorld.y));
            atTarget = false;
            Debug.Log("in world is: " + targetInWorld);
            Debug.Log("in grid is: " + targetInGrid);
            Debug.Log("the Next step is: " + NextStep);
            MakeOneStepTowardsTheTarget();
        }
    }

    public Vector2 GetTarget() {
        return targetInWorld;
    }

    private IWeightedGraph<Vector2> Graph = null;
    private float timeBetweenSteps;

    protected virtual void Start() {
        Graph = new BoundedAreaGraph(TopLeft, BottomRight);
        timeBetweenSteps = 1 / speed;
        targetInGrid = transform.position;
        NextStep = transform.position;
        StartCoroutine(MoveTowardsTheTarget());
    }



    IEnumerator MoveTowardsTheTarget() {
        for(;;) {
            yield return new WaitForSeconds(timeBetweenSteps);
            Debug.Log("the transform is: " + transform.position);
            Debug.Log("the next is: " + NextStep);
            if (enabled && !atTarget)
                MakeOneStepTowardNextStep();
            else
                MakeOneStepTowardsTheTarget();

        }
    }



 
    private void MakeOneStepTowardsTheTarget() {
        Vector2 startNode = new Vector2(round(transform.position.x), round(transform.position.y));
        Vector2 endNode = targetInGrid;
        List<Vector2> shortestPath = AStar.GetPath(Graph, startNode, endNode, heuristicDistance,(v1,v2)=>v1==v2, maxIterations);
        Debug.Log("shortestPath = " + string.Join(" , ",shortestPath));
        if (shortestPath.Count >= 2) {
            Debug.Log("the transform is: " + transform.position);
            
            Vector2 nextNode = shortestPath[1];
            Debug.Log("the next is: " + nextNode);
            NextStep = nextNode;
            
            
            
        } else {
            atTarget = true;
            //enable to damge the charcther
            Debug.Log("im here coacht");

            //SingleToon.getInstance().curlife.damage(5);
            
        }
    }

    private void MakeOneStepTowardNextStep()
    {
        if (NextStep == (Vector2)transform.position)
        {
            atTarget = true;
        }
        transform.position = Vector2.MoveTowards(transform.position, NextStep, 0.1f );
        
    }




    private static float round (double Num)
    {
        return (float)Math.Round(Num, 0);

    }



    
    private static float heuristicDistance(Vector2 startNode, Vector2 endNode)
    {
        // using menhatten distance
        return Math.Abs(startNode.x - endNode.x)
               + Math.Abs(startNode.y - endNode.y);
    }
}
