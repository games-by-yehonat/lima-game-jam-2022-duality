using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager singleton;

    [SerializeField]
    private GameObject childMap;

    [SerializeField]
    private GameObject adultMap;

    [SerializeField]
    private bool characterChange;

    [SerializeField]
    private int nexLevel;

    void Awake()
    {
        if (singleton != null)
        {
            return;
        }
        singleton = this;
        // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {       
        childMap = GameObject.Find("Child");
        adultMap = GameObject.Find("Adult");
        CharacterChange();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
            CharacterChange();
    }

    public void CharacterChange()
    {
        if (childMap && adultMap)
        {
            childMap.SetActive(characterChange);
            adultMap.SetActive(!characterChange);
        }
        characterChange = !characterChange;

    }

    public void FinishedLevel()
    {
        SceneManager.LoadScene(nexLevel);

    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
