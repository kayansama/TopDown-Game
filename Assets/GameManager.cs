using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float FireCooldown = 0.3f;
    public GameObject playerObject;
    private int Score;
    public TextMeshProUGUI Scoretext;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = Score.ToString();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int score)
    {
        Score = Score + score;
    }
    public void ShootingSpeedBoost()
    {
        StartCoroutine(BoostShootingSpeed());
    }
    public IEnumerator BoostShootingSpeed()
    {
        FireCooldown = 0.15f;
        yield return new WaitForSeconds(5f);

        FireCooldown = 0.3f;

    }
}
