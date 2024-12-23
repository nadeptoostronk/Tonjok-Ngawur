using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingCamera : MonoBehaviour
{
   [SerializeField] private float damping;
   [SerializeField]private Vector3 offset;
   public Transform target;
   public Transform target1;
  private Vector3 vel = Vector3.zero;
   private void Update()
   {
     Vector3 targetPosition = target.position + offset;
    targetPosition.z=transform.position.z;
     transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref
     vel,damping);

     Vector3 target1Position = target1.position + offset;
    target1Position.z=transform.position.z;
     transform.position = Vector3.SmoothDamp(transform.position, target1Position,ref
     vel,damping);
   }
}
