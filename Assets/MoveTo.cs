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
        if(target == null) {
            target = GameObject.Find("RigidbodyFPSController").transform;
        }
    }

   void Update() {
        if(target == null) {
            target = GameObject.Find("RigidbodyFPSController").transform;
        }

        if(Vector3.Distance(this.transform.position, target.position) < 30) {
           agent.destination = target.position;
        }

       
        anim.SetFloat("Speed", agent.velocity.magnitude);
   }
}
