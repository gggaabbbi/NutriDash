using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSctive : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    [SerializeField] private float timer;
    void Start()
    {
        StartCoroutine(SetActive());
    }

    private IEnumerator SetActive()
    {
        yield return new WaitForSeconds(timer);
        spawner.SetActive(true);

    }
}
