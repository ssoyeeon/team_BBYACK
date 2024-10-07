using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public string[] SceneList = new string[20];     //string 리스트를 만듭니다.
    
     public void StageMain(int number)              //넘버로 가져와요
    {
        SceneManager.LoadScene(SceneList[number]);  //리스트에 쓴 이름의 씬을 가져옵니다.
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
