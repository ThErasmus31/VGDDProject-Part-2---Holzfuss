using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Approximate amount of damage dealth per fram")]
    private float m_Damage;

    void Awake()
    {

    }

    #region Collision Methods
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().DecreaseHealth(m_Damage);

            Destroy(this.gameObject);
        }
    }
    #endregion
}
