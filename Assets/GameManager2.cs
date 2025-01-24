using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public void StartNormalMode()
    {
         Invoke("Scene", 2f);
    }
    
    
    public void Scene()
    {
        SceneManager.LoadScene("Scene");
    }



 public void StartRaceMode()
    {
        Invoke("enes", 2f);
    }



    public void enes()
    {
        SceneManager.LoadScene("enes");
    }



    public void StartmeNlMode()
    {
        Invoke("Menu", 2f);
    }



    public void Menu()
    {
        SceneManager.LoadScene("Menu"); 
    }
}
