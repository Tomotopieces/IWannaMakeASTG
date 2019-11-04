using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Score { get; set; }
    [SerializeField]
    private GameObject currentAero;
    void Awake()
    {
        Instantiate<GameObject>(currentAero);
    }
}
