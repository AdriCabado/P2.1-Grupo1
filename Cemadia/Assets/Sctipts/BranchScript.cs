using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class BranchScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isCut=false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; 
    }

    public void Detach(Vector2 impactDirection, float force, float torque)
    {
        isCut=true;
        rb.isKinematic = false; 
        rb.AddForce(impactDirection.normalized * force, ForceMode2D.Impulse); 
        rb.AddTorque(torque, ForceMode2D.Impulse);
    }
}
