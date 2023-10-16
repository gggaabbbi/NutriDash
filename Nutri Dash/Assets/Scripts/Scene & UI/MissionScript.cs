using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionScript : MonoBehaviour
{
    [SerializeField] private GameObject missionText;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private TextMeshProUGUI text4;
    [SerializeField] private TextMeshProUGUI text5;

    void Start()
    {
        StartCoroutine(Mission());
    }

    private IEnumerator Mission()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
        text5.gameObject.SetActive(false);
        missionText.SetActive(true);
        yield return new WaitForSeconds(20f);
        missionText.SetActive(false);
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(true);
        text3.gameObject.SetActive(true);
        text4.gameObject.SetActive(true);
        text5.gameObject.SetActive(true);
    }
}
