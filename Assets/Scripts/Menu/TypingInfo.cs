using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingInfo : MonoBehaviour
{
    public Text textPanel;
    public int index;
    public TextAsset egTextRaw;
    public TextAsset chTextRaw;
    public AudioSource Typing;
    public float textSpeed;
    public List<string> textList = new List<string>();
    public bool textFinished;
    private bool cancelTyping;
    [SerializeField] bool isMenu;
    private JoyStick joyStickIn;
    private LanguageOption infoType;
    public GameObject enterC;
    public GameObject enter;
    private void Start()
    {

        joyStickIn = GameObject.FindWithTag("joyStick").GetComponent<JoyStick>();
        if (Language.Instance.isMobile)
        {
            enterC = GameObject.FindWithTag("enterC");
        }else if (!Language.Instance.isMobile)
        {
            enterC = GameObject.FindWithTag("enterC");
            enter = GameObject.FindWithTag("enter"); 
            if(enter != null)
            {
                enter.gameObject.SetActive(false);
            }
        }
        if (Language.Instance.nowOption == LanguageOption.Chinese)
        {
            infoType = LanguageOption.Chinese;
            GetTextFromFile(chTextRaw);
        }
        if (Language.Instance.nowOption == LanguageOption.English)
        {
            infoType = LanguageOption.English;
            GetTextFromFile(egTextRaw);
        }

        textFinished = true;
        StartCoroutine(SetTextUI());
    }
    private void Update()
    {

            if ((infoType != Language.Instance.nowOption) && isMenu)
        {
            if(Language.Instance.nowOption == LanguageOption.Chinese)
            {
                GetTextFromFile(chTextRaw);
                textPanel.text = textList[0];
                infoType = LanguageOption.Chinese;
            }
            else if(Language.Instance.nowOption == LanguageOption.English)
            {
                GetTextFromFile(egTextRaw);
                textPanel.text = textList[0];
                infoType = LanguageOption.English;
            }
        }
        if (Language.Instance.isMobile)
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || enterC.GetComponent<Enter>().isEnter) && index == textList.Count)
            {
                if (isMenu) return;
                Fader.Instance.ChangeScene("GroundScene");
            }
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || enterC.GetComponent<Enter>().isEnter)
            {
                if (isMenu) return;
                if (textFinished && !cancelTyping)
                {
                    StartCoroutine(SetTextUI());
                }
                else if (!textFinished)
                {
                    cancelTyping = !cancelTyping;
                }
            }
        }else if (!Language.Instance.isMobile)
        {

            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)) && index == textList.Count)
            {
                if (isMenu) return;
                Fader.Instance.ChangeScene("GroundScene");
            }
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
            {
                if (isMenu) return;
                if (textFinished && !cancelTyping)
                {
                    StartCoroutine(SetTextUI());
                }
                else if (!textFinished)
                {
                    cancelTyping = !cancelTyping;
                }
            }
        }
        
    }
    private IEnumerator SetTextUI()
    {
        if(index < textList.Count)
        {
            textFinished = false;
            textPanel.text = "";
            int i = 0;
            while (!cancelTyping && i < textList[index].Length)
            {
                textPanel.text += textList[index][i];
                i++;
                Typing.Play();
                yield return new WaitForSeconds(textSpeed);
            }
            textPanel.text = textList[index];
            cancelTyping = false;
            textFinished = true;
            index++;

        }
    }
    private void GetTextFromFile(TextAsset textRaw)
    {
        textList.Clear();
        index = 0;
        var lineData = textRaw.text.Split('\n');
        foreach (var line in lineData)
        {
            textList.Add(line);
        }
        
    }

}
