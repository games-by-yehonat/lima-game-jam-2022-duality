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

    [SerializeField]
    private AudioClip[] clips;

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
        if (Input.GetKeyDown(KeyCode.J))
            CharacterChange();
    }
    private bool isChild;
    public void CharacterChange()
    {
        if (childMap && adultMap)
        {
            isChild = !isChild;
            GetComponent<AudioSource>().clip = clips[isChild ? 1 : 0];

            GetComponent<AudioSource>().Play();
            childMap.SetActive(characterChange);
            adultMap.SetActive(!characterChange);
            GameObject.Find("PlayerPrefab").GetComponent<NewPlayer>().CharacterChange();
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
