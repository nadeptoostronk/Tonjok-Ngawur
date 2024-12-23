using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Prefab karakter
    public Transform spawnPoint; // Lokasi spawn karakter

    void Start()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0); // Ambil pilihan
        Instantiate(characterPrefabs[selectedCharacterIndex], spawnPoint.position, spawnPoint.rotation);
    }
}
