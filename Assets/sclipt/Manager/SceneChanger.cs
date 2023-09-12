using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //パネル消す
    public void PanelDelete(GameObject nowPanel)
    {
        nowPanel.SetActive(false);
    }

    //パネル出す
    public void Panel(GameObject panel)
    {
        panel.SetActive(true);
    }
}
