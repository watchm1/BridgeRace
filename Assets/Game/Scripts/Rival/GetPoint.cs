using System;
using System.Numerics;
using Game.Scripts.Core.Singleton;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;


namespace Game.Scripts.Rival
{
   public class GetPoint : Singleton<GetPoint>
   {
      
      public float Range;
      
      bool RandomPoint(Vector3 center, float range, out Vector3 result)
      {
         for (int i = 0; i < 30; i++)
         {
            Vector3 randomPoint = center + Random.insideUnitSphere *range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
               result = hit.position;
               return true;
            }
         }
         result = Vector3.zero;
         return false;
      }

      public Vector3 GetRandomPoint(Transform point = null, float radius = 0)
      {
         Vector3 _point;
         if (RandomPoint(point == null ? transform.position : point.position, radius == 0 ? Range : radius, out _point))
         {
           Debug.DrawRay(_point, Vector3.up, Color.black, 1);
           return _point;
         }

         return Vector3.zero;
      }
#if UNITY_EDITOR
      private void OnDrawGizmos()
      {
         Gizmos.DrawWireSphere(transform.position, Range);
      }
#endif
   }
}
