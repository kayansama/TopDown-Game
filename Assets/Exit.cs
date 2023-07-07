using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : InteractionAbstract
{
    public string sceneName;
    public override void Interact() { }

    public override void Interact2()
    {
        Destroy(GameManager.Instance.gameObject);
        SceneManager.LoadScene(sceneName);
    }
    private void Start()
    {
        Debug.Log("YO");
    }
}
