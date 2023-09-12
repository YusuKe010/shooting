using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //�p�l������
    public void PanelDelete(GameObject nowPanel)
    {
        nowPanel.SetActive(false);
    }

    //�p�l���o��
    public void Panel(GameObject panel)
    {
        panel.SetActive(true);
    }
}
