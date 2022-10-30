using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanvasLookAt : MonoBehaviour
{
    [SerializeField]private Transform cam;
    void LateUpdate()
    {
        transform.LookAt(cam);
    }
}
