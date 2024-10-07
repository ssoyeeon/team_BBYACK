using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public string[] SceneList = new string[20];     //string ����Ʈ�� ����ϴ�.
    
     public void StageMain(int number)              //�ѹ��� �����Ϳ�
    {
        SceneManager.LoadScene(SceneList[number]);  //����Ʈ�� �� �̸��� ���� �����ɴϴ�.
    }

    public void NextStage()
    {
        Scene scene = SceneManager.GetActiveScene();
        int curScene = scene.buildIndex;
        int nextScene = curScene + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void RetryStage()
    {
        Scene scene = SceneManager.GetActiveScene();
        int curScene = scene.buildIndex;
        SceneManager.LoadScene(curScene);
    }
}
