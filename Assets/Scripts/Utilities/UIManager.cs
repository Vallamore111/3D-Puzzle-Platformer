using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image cursor;
    public TextMeshProUGUI popupText;
    private Color defaultCursorColor;
    private Color defaultTextColor;
    private bool coroutineRunning;
    private bool cursorLock;
    public static UIManager instance;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        defaultTextColor = popupText.color;
        defaultCursorColor = cursor.color;
        HidePopupText();
        ShowHideCursorImage();
    }


    private void Update()
    {
        ChangeCursor();
    }


    public void ShowPopupText(string newText)
    {
        if (!coroutineRunning)
        {
            popupText.color = defaultTextColor;
            popupText.text = newText;
        }
    }

    public void HidePopupText()
    {
        if (popupText.color == defaultTextColor && !coroutineRunning)
        { popupText.color = Color.clear; }
    }


    public void ShowHideCursorImage()
    {
        cursor.enabled = !cursor.enabled;
        cursorLock = !cursorLock;

        if (cursorLock)
        { Cursor.lockState = CursorLockMode.Locked; }
        else { Cursor.lockState = CursorLockMode.None; }
    }


    private void ChangeCursor()
    {
        var interaction = PlayerRaycast.currentObject;

        if (interaction == null)
        {
            HidePopupText();
            cursor.color = defaultCursorColor;
            return;
        }

        if (!coroutineRunning) 
        { cursor.color = Color.green; }
    }


    public IEnumerator PopupTextCoroutine(string newText)
    {
        coroutineRunning = true;
        popupText.color = defaultTextColor;
        popupText.text = newText;
        yield return new WaitForSeconds(3f);
        popupText.color = Color.clear;
        coroutineRunning = false;
    }
}
