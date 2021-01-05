using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsBycoldier : MonoBehaviour
{
    //
    public GameObject Instruction;
    private GameObject instisinateInstruction;
    public string tag;
    bool alredyon = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag && alredyon == false)
        {
            instisinateInstruction = Instantiate(Instruction);
            alredyon = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(instisinateInstruction);
        alredyon = false;
    }
}
