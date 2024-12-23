using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectManager : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Array prefab karakter
    private int selectedCharacterIndex = 0; // Indeks karakter yang dipilih

    // Fungsi dipanggil saat pemain memilih karakter
    public void SelectCharacter(int characterIndex)
    {
        selectedCharacterIndex = characterIndex;
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex); // Simpan pilihan
    }

    // Fungsi untuk memulai permainan
    public void StartGame()
    {
        SceneManager.LoadScene("inGame"); // Ganti dengan nama scene gameplay Anda
    }
}
