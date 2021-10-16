using TMPro;
using UnityEngine;

public class OnClickEvent : MonoBehaviour
{
    public TextMeshProUGUI soundsText;

    void Start() {
       if(GameManager.mute)
          soundsText.text = "/";
       else
          soundsText.text = "";
    }
    // mute sound
    public void ToogleMute()
    {
        if(GameManager.mute) {
            GameManager.mute = false;
            soundsText.text = "";
        }
        else 
        {
            GameManager.mute = true;
            soundsText.text = "/";
        }
    }

    //Quit game via button
    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
