using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float FireCooldown = 0.3f;
    public GameObject playerObject;
    private int Score;
    public TextMeshProUGUI Scoretext;
    public ProgressBar progressbar;
    public float bumpamount;
    public GameObject startPanel;
    public GameObject ExitPanel;

    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject Exit;
    public string loseScene;
    public Health health;
    void Start()
    {
        Score = 0;
        ExitPanel.SetActive(false);
    }

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
        health = playerObject.GetComponent<Health>();
    }
    public void AddScore(int score)
    {
        Score = Score + score;
        progressbar.BumpProgress(bumpamount);
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
    private IEnumerator TakeDamageCoroutine(SpriteRenderer sprite, Color damageColor)
    {
        Color originalColor = sprite.color;
        damageColor.a = 1f;
        sprite.color = damageColor;
        yield return new WaitForSeconds(0.3f);
        if (sprite != null)
        {
            sprite.color = originalColor;
        }
    }
    public void TakeDamage(SpriteRenderer sprite, Color damageColor)
    {
        StartCoroutine(TakeDamageCoroutine(sprite, damageColor));

    }
    public void ExitOpened()
    {
        ExitPanel.SetActive(true);
        StartCoroutine(DesactivateObject(ExitPanel, 3f));
        
    }
    public IEnumerator DesactivateObject(GameObject gameObject, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
        //activate panel
        Exit.gameObject.SetActive(true);
    }
    public void LostGame()
    {

        LosePanel.gameObject.SetActive(true);
        Debug.Log(Time.timeScale);
        Time.timeScale = .1f;
    }
    private IEnumerator LostGameCoroutine()
    {
        yield return new WaitForSeconds(2f);
    }
    public void LoadScene(string SceneToLoad)
    {
        Time.timeScale= 1f;
        Destroy(Instance.gameObject);
        SceneManager.LoadScene(SceneToLoad);

    }
    public void HealPlayer(float playerHealing)
    {
        health.IncreaseHP(playerHealing);
    }
}
