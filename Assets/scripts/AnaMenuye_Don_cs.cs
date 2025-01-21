using UnityEngine;
using UnityEngine.SceneManagement;  // SceneManager için gerekli namespace

public class AnaMenuyeDon : MonoBehaviour
{
    // Butona tıklandığında çağrılacak fonksiyon
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        // MainMenu adlı sahneye geçiş yap
        SceneManager.LoadScene("MainMenu");
    }
}
