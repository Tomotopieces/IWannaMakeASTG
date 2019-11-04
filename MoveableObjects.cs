using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    [Header("Component")]
    protected Animator objectAnimator;
    protected Rigidbody2D objectBody;
    protected BoxCollider2D objectCollider;

    [Header("Boundary")]
    protected Transform upperLeft;
    protected Transform bottomRight;

    virtual protected void Start()
    {
        gameObject.TryGetComponent<Animator>(out objectAnimator);
        objectBody = gameObject.GetComponent<Rigidbody2D>();
        objectCollider = gameObject.GetComponent<BoxCollider2D>();
    }
}
