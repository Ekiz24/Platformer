using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private WaitForSeconds finishWating;
    public AudioSource bgm;
    public AudioSource wisper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            StartCoroutine(FinishLine());
        }
        
    }

    private IEnumerator FinishLine()
    {
        yield return new WaitForSeconds(0.5f);
        bgm.Stop();
        wisper.Stop();
        SceneManager.LoadScene("EndingScene");
    }
}
