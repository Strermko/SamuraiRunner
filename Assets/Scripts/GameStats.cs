using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameStats : MonoBehaviour
{
    [SerializeField] float scorePerSecond = 1f;

    public UnityEvent onScoreChanged;

    public int Score { get; private set; }

    void Start()
    {
        Score = 0;
        StartCoroutine(AddScore());
    }


    private IEnumerator AddScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / scorePerSecond);
            Score += 1;
            onScoreChanged.Invoke();
        }
    }
}