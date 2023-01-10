using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    
    
    [SerializeField] int thisIndex;
    private MenuController menuController;
    private Animator animator;
    private JoyStick joyStickIn;
    public GameObject TowerMiner;
    public GameObject playInfo;
    public TypingInfo typingInfo;
    private void Start()
    {
        menuController = GetComponentInParent<MenuController>();
        animator = GetComponent<Animator>();
        joyStickIn = GameObject.FindWithTag("joyStick").GetComponent<JoyStick>();
    }
    private void PlaySound(AudioClip whichSound)
    {
        if (!menuController.disableOnce)
        {
            menuController.audioSource.PlayOneShot(whichSound);
        }
        else
        {
            menuController.disableOnce = false;
        }
    }
    private void Update()
    {
        bool isEnter = false;
        if (Language.Instance.isMobile)
        {
            isEnter = GameObject.FindWithTag("enter").GetComponentInParent<Enter>().isEnter;
        }
        if(menuController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetKeyDown(KeyCode.Return) || isEnter)
            {
                if (typingInfo.isActiveAndEnabled && !typingInfo.textFinished) return;
                animator.SetBool("pressed", true);
            }else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                menuController.disableOnce = true;
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
        if (animator.GetBool("pressed"))
        {
            switch (thisIndex) {
                case 0:
                    Fader.Instance.ChangeScene("BackOneScene");
                    break;
                case 1:
                    if (Language.Instance.nowOption == LanguageOption.English)
                        Language.Instance.ChangeLanguage(LanguageOption.Chinese);
                    if (Language.Instance.nowOption == LanguageOption.Chinese)
                        Language.Instance.ChangeLanguage(LanguageOption.English);
                    break;
                case 2:
                    if (TowerMiner.activeSelf)
                    {
                        TowerMiner.SetActive(false);
                        playInfo.SetActive(true);
                    }
                    else
                    {
                        TowerMiner.SetActive(true);
                        playInfo.SetActive(false);
                    }
                    break;
                case 3:
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#endif
                    Application.Quit();
                    break;
            }
        }
    }
}
