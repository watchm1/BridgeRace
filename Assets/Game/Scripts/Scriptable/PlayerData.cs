using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Player")]
public class PlayerData : ScriptableObject
{
    public float groundRadius;
    public float speed;
    public LayerMask whatIsGround;
}
