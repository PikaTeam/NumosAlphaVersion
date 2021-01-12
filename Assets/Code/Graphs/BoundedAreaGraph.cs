using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedAreaGraph : MonoBehaviour, IWeightedGraph <Vector2>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 Topleft,BottomRight;

    public BoundedAreaGraph(Vector2 Topleft, Vector2 BottomRight)
    {
        this.Topleft = Topleft;
        this.BottomRight = BottomRight;
    }

    static Vector2[] directions =
    {
        new Vector2(-1f,0),
        new Vector2(1f,0),
        new Vector2(0,-1f),
        new Vector2(0,1f),
        new Vector2(1f,1f),
        new Vector2(-1f,-1f),
        new Vector2(-1f,1f),
        new Vector2(1f,-1f)

        /*new Vector2(-0.2f,0),
        new Vector2(0.2f,0),
        new Vector2(0,-0.2f),
        new Vector2(0,0.2f),
        new Vector2(0.2f,0.2f),
        new Vector2(-0.2f,-0.2f),
        new Vector2(-0.2f,0.2f),
        new Vector2(0.2f,-0.2f)*/


    };


    public IEnumerable<KeyValuePair<Vector2, float>> Neighbors(Vector2 node)
    {
        foreach (var direction in directions)
        {
            Vector2 Newpos = node + direction;
            

            if (!(node.x>Topleft.x && node.x <BottomRight.x))
            {
                continue;
            }

            if (!(node.y < Topleft.y && node.y > BottomRight.y))
            {
                continue;
            }


            
            
                yield return new KeyValuePair<Vector2, float>(Newpos, 1f);
        }
    }
  }


