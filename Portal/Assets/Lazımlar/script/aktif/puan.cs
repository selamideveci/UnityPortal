using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class puan : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private TextMeshProUGUI timesure;

    private void Start()
    {
        InvokeRepeating("sure_azalt", 0.0f, 1.0f);
        scoretext.text = score.totalscore.ToString();
        timesure.text = time.times.ToString();

    }


    void sure_azalt()
    {
        time.times--;
        timesure.text = time.times.ToString();

        if (time.times == 0)
        {
            CancelInvoke("sure_azalt");
            Debug.Log("Oyun bitti");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("elmas"))
        {
            Destroy(other.gameObject);
            score.totalscore++;
            scoretext.text = score.totalscore.ToString();

        }
    }
}