using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextAsset textJSON;
    public TextMeshProUGUI textComponent;
    public GameObject Imagen;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public float textSpeed;

    private int index;
    void Start()
    {
        myLines = JsonUtility.FromJson<LinesList>(textJSON.text);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == myLines.lines[index].text)
            {
                NextLine();
            } else
            {
                StopAllCoroutines();
                textComponent.text = myLines.lines[index].text;
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (myLines.lines[index].person == "Viejo")
        {
            Imagen.GetComponent<UnityEngine.UI.Image>().sprite = Sprite1;
        } else if (myLines.lines[index].person == "Chico")
        {
            Imagen.GetComponent<UnityEngine.UI.Image>().sprite = Sprite2;
        }
        foreach (char c in myLines.lines[index].text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < myLines.lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else
        {
            gameObject.SetActive(false);
            Imagen.SetActive(false);
        }
    }
    [System.Serializable]
    public class Lines
    {
        public string person;
        public string text;
    }
    [System.Serializable]
    public class LinesList
    {
        public Lines[] lines;
    }
    public LinesList myLines = new LinesList();
}
