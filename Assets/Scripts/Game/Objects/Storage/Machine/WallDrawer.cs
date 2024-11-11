using DG.Tweening;
using System;
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
        StartCoroutine(Move());
    }
    public enum State
    {
        TRUE,
        FALSE
    }
    public IEnumerator Move()
    {
        if (state == State.TRUE)
        {
            yield return new WaitForSeconds(.4f);

            transform.DOMove(trueSpot.position, .4f);
            lamp.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(.4f);

            transform.DOMove(falseSpot.position, .4f);
            lamp.SetActive(false);
        }

    }
}
