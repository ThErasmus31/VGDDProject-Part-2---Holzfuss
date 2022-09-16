using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("How much health this enemy has")]
    private int m_MaxHealth;

    [SerializeField]
    [Tooltip("Approximate amount of damage dealth per fram")]
    private float m_Damage;

    [SerializeField]
    [Tooltip("How many points killing this enemy provides")]
    private int m_Score;

    [SerializeField]
    [Tooltip("The probability that this enemy drops a health pill")]
    private float m_SpeedPillDropRate;

    [SerializeField]
    [Tooltip("The type of health pill this enemy drops")]
    private GameObject m_SpeedPill;
    #endregion

    #region Private Variables
    private float p_curHealth;
    #endregion

    #region Cached Components
    private Rigidbody cc_Rb;
    #endregion

    #region Cached References
    private Transform cr_Player;
    #endregion

    #region Initialization
    private void Awake()
    {
        p_curHealth = m_MaxHealth;

        cc_Rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        cr_Player = FindObjectOfType<PlayerController>().transform;
    }
    #endregion

    #region Main Updates

    #endregion

    #region Collision Methods
    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().DecreaseHealth(m_Damage);
        }
    }
    #endregion

    #region Health Methods
    public void DecreaseHealth(float amount)
    {
        p_curHealth -= amount;
        if (p_curHealth <= 0)
        {
            ScoreManager.singleton.IncreaseScore(m_Score);

            if (Random.value < m_SpeedPillDropRate)
            {
                Instantiate(m_SpeedPill, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
    #endregion
}
