using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public  Vector3 offset = new Vector3(0f, 3f, -10f);
 public float smoothTime = 0.17f; 
 private Vector3 velocity = Vector3.zero;
 public bool can;
  public bool Cutscene;

 public Transform target;

void Start()
{
   target = GameObject.FindWithTag("Player").transform;
}
 void Update()
 {
   if (can)
   {
      if (!Cutscene)
      {
    target = GameObject.FindWithTag("Player").transform;
      }
    Vector3 targetPos = target.position + offset;
    transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
   }
 }
}
