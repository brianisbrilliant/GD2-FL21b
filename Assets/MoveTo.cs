using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform target;

    public Animator anim;

    NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("I exist!");
    }

   void Update() {
        if(Vector3.Distance(this.transform.position, target.position) < 30) {
           agent.destination = target.position;
        }

       
        anim.SetFloat("Speed", agent.velocity.magnitude);
   }
}
