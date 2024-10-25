using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDrawer : AbstractStorage
{
    [SerializeField] private Transform trueSpot;
    [SerializeField] private Transform falseSpot;
    [SerializeField] private GameObject lamp;

    public State state;

    private void Start()
    {
        state = State.FALSE;
        Move();
    }
    public enum State
    {
        TRUE,
        FALSE
    }
    public void Move()
    {
        if (state == State.TRUE)
        {
            transform.DOMove(trueSpot.position, .3f);
            lamp.SetActive(true);
        }
        else
        {
            transform.DOMove(falseSpot.position, .3f);
            lamp.SetActive(false);
        }

    }
}
