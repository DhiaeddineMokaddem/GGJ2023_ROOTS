using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI description;
    public GameObject modesHolder;
    public GameObject otherButtonHolder;
    public void Play()
    {
        modesHolder.SetActive(true);
        otherButtonHolder.SetActive(false);
    }
    public void Back()
    {
        modesHolder.SetActive(false);
        otherButtonHolder.SetActive(true);
    }
    public void loadScene(int sceneId)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
    }
    public void ChangeDescriptionBack()
    {
        description.text = "• HOW TO WIN :\r\n- Reach 5000L Water\r\n- Don't let your base tree die\r\n\r\n• HOW TO PLAY :\r\nClick on tiles to spawn units or upgrade them.\r\n- attack tree only attacks.\r\n- roots only produce water when planted on water borders\r\n- defence tree have LOTS of health";
    }
    public void ChangeDescription(string descrription)
    {
        description.text = descrription;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
