using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPill : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The amount of Speed that this pill adds")]
    private int m_SpeedGain;
    public int SpeedGain
    {
        get
        {
            return m_SpeedGain;
        }
    }
    #endregion
}
