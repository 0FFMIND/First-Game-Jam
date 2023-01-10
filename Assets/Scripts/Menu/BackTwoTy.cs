using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BackTwoTy : MonoBehaviour
{
    private Text textPanel;
    public int index;
    public TextAsset egTextLoseRaw;
    public TextAsset chTextLoseRaw;
    public TextAsset egTextWinRaw;
    public TextAsset chTextWinRaw;
    public GameObject winImage;
    public GameObject loseImage;
    public AudioSource Typing;
    public GameObject Shop;
    public float textSpeed;
    public List<string> textList = new List<string>();
    public bool textFinished;
    private bool cancelTyping;
    private JoyStick joyStickIn;
    private LanguageOption infoType;
    private bool Turn = false;
    private void Start()
    {
        joyStickIn = GameObject.FindWithTag("joyStick").GetComponent<JoyStick>();
        textPanel = GameObject.FindWithTag("textP").GetComponent<Text>();
        Typing = GetComponent<AudioSource>();
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "BackTwo")
        {
            if (Language.Instance.nowOption == LanguageOption.Chinese && Fader.Instance.isDefeated)
            {
                textList.Clear();
                winImage.SetActive(false);
                loseImage.SetActive(true);
                textList.Add("���ź����㱻�������ڵ�������˻�����");
                textList.Add("����һЩԭ�������ε���ʱ����Ŀ����������ɶ������͵����һ��");
                textList.Add("��������ʹ�øողɼ��Ŀ���Ϊ��ķ�����������Ȼ�󷵻���ĸ�����");
                textList.Add("���ס�������������㣬�����յ�");
            }
            else if (Language.Instance.nowOption == LanguageOption.English && !Fader.Instance.isDefeated)
            {
                textList.Clear();
                winImage.SetActive(true);
                loseImage.SetActive(false);
                textList.Add("CONGRATULATIONS ON SUCCESSFULLY FENDING OFF THE BAT'S ATTACK AND GUARDING YOUR MINERAL DESPOSITS");
                textList.Add("AS A BONUS, WE'VE INCREASED YOUR MINERAL BY THREE");
                textList.Add("NOW USE THE MINERALS YOU COLLECTED TO UPGRADE YOUR TOWER AND RETURN");
                textList.Add("REMEMBER, THIS IS YOUR STARTING POINT, NOT THE END");
            }
            else if (Language.Instance.nowOption == LanguageOption.Chinese && !Fader.Instance.isDefeated)
            {
                textList.Clear();
                winImage.SetActive(true);
                loseImage.SetActive(false);
                textList.Add("��ϲ��ɹ��ص���������Ĺ���������˳���ػ�����Ŀ��");
                textList.Add("��Ϊ���������ǽ���Ŀ�����������������");
                textList.Add("��������ʹ����ɼ��Ŀ���Ϊ��ķ�����������Ȼ�󷵻���ĸ�����");
                textList.Add("���ס�������������㣬�����յ�");
            }
            else if (Language.Instance.nowOption == LanguageOption.English && Fader.Instance.isDefeated)
            {
                textList.Clear();
                winImage.SetActive(false);
                loseImage.SetActive(true);
                textList.Add("IT'S A PITY THAT YOU WERE DEFEATED BY MEANCING BAT ENEMIES");
                textList.Add("FOR SOME REASON, HALF OF YOUR MINERALS IS STOLEN BY THE ABOMINABLE BATS");
                textList.Add("NOW YOU CAN USE THE MINERALS JUST COLLECTED TO UPGRADE YOUR TOWERS AND RETURN");
                textList.Add("REMEMBER, THIS IS YOUR STARTING POINT, NOT THE END");
            }
            textFinished = true;
            StartCoroutine(SetTextUI());
        }else if(scene.name == "BackThree")
        {
            if (Language.Instance.nowOption == LanguageOption.Chinese)
            {
                textList.Clear();
                winImage.SetActive(false);
                loseImage.SetActive(true);
                textList.Add("���ź����㱻�������ڵ������������˻����ˣ����������Ѿ������˻�ɱ������10ת��Ϊ�㵱ǰ�Ŀ�ʯ����");
                textList.Add("Ϊ�˱��գ������ڷ��������ڵ����ػ��Ŀ󶴣��������Ĳɼ�Ȼ�󷵻ظ��������ɣ�");
                textList.Add("���ס�������������㣬�����յ�");
            }
            else if (Language.Instance.nowOption == LanguageOption.English)
            {
                textList.Clear();
                winImage.SetActive(true);
                loseImage.SetActive(false);
                textList.Add("UNFORTUNATELY, YOU WERE DEFEATED, BUT WE'VE DIVIDED THE NUMBDER OF ENEMY KILLS BY 10 TO FORM YOUR CURRENT MINERALS");
                textList.Add("TO AVOID DANGE, YOU RETURNED TO THE MINE CAVE. PLEASE NOW CONTINUE YOUR COLLECTION AND RETURN TO THE TOWER TO FIGHT BACK!");
                textList.Add("REMEMBER, THIS IS YOUR STARTING POINT, NOT THE END");
            }
            textFinished = true;
            StartCoroutine(SetTextUI());
        }
    }
    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || GameObject.FindWithTag("enterC").GetComponent<Enter>().isEnter) && index == textList.Count)
        {
            winImage.SetActive(false);
            loseImage.SetActive(false);
            Shop.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || GameObject.FindWithTag("enterC").GetComponent<Enter>().isEnter)
        {
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
    private IEnumerator SetTextUI()
    {
        if (index < textList.Count)
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