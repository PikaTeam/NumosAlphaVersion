using Assets.Scripts._0_bfs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component moves its object towards a given target position.
 */
public class TargetMover: MonoBehaviour {


    [Tooltip("The speed by which the object moves towards the target, in meters (=grid units) per second")]
    [SerializeField] float speed = 3f;

    [Tooltip("Maximum number of iterations before BFS algorithm gives up on finding a path")]
    [SerializeField] int maxIterations = 1000;

    [Tooltip("The target position in world coordinates")]
    [SerializeField] Vector2 targetInWorld;

    [Tooltip("The target position in grid coordinates")]
    [SerializeField] Vector2 targetInGrid;

    [SerializeField] Vector2 TopLeft,BottomRight;

    protected bool atTarget;  // This property is set to "true" whenever the object has already found the target.

    public void SetTarget(Vector2 newTarget)
    {
        
        if (targetInWorld != newTarget) {
            targetInWorld = newTarget;
            targetInGrid = new Vector2(round(targetInWorld.x), round(targetInWorld.y));
            atTarget = false;
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
        StartCoroutine(MoveTowardsTheTarget());
    }

    IEnumerator MoveTowardsTheTarget() {
        for(;;) {
            yield return new WaitForSeconds(timeBetweenSteps);
            if (enabled && !atTarget)
                MakeOneStepTowardsTheTarget();
        }
    }

 
    private void MakeOneStepTowardsTheTarget() {
        Vector2 startNode = new Vector2(round(transform.position.x), round(transform.position.y));
        Vector2 endNode = targetInGrid;
        List<Vector2> shortestPath = AStar.GetPath(Graph, startNode, endNode, heuristicDistance, maxIterations);
        Debug.Log("shortestPath = " + string.Join(" , ",shortestPath));
        if (shortestPath.Count >= 2) {
            Vector2 nextNode = shortestPath[1];
            transform.position = (Vector2)nextNode;
            timeBetweenSteps = 0.1f;
        } else {
            atTarget = true;
        }
    }

    private static float round (double Num)
    {
        return (float)Math.Round(Num, 1);

    }

    
    private static float heuristicDistance(Vector2 startNode, Vector2 endNode)
    {
        // using menhatten distance
        return Math.Abs(startNode.x - endNode.x)
               + Math.Abs(startNode.y - endNode.y);
    }
}
