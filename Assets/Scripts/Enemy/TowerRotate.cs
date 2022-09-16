using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    public float Speed = 20f;
    public Transform FollowPos = null;

    private void Update()
    {
        Quaternion rotTarget = Quaternion.LookRotation(FollowPos.position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, Speed * Time.deltaTime);
    }
}
