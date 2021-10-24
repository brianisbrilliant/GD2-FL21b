using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
   public Transform target;

    NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

   void Update() {
       if(Vector3.Distance(this.transform.position, target.position) < 20) {
           agent.destination = target.position;
       }
       
   }
}
