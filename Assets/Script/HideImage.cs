using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideImage : MonoBehaviour
{
    public SpriteRenderer targetSprite; // Referensi ke SpriteRenderer
    public float waitTime = 3f; // Waktu tunggu sebelum fade out
    public float fadeDuration = 1f; // Durasi fade out

    void Start()
    {
        if (targetSprite != null)
        {
            StartCoroutine(WaitAndFadeOut());
        }
        else
        {
            Debug.LogWarning("Sprite target belum diatur!");
        }
    }

    IEnumerator WaitAndFadeOut()
    {
        // Tunggu selama waktu tertentu
        yield return new WaitForSeconds(waitTime);

        // Simpan warna awal sprite
        Color originalColor = targetSprite.color;

        // Fade out sprite
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            targetSprite.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Set alpha ke 0 untuk memastikan sprite benar-benar transparan
        targetSprite.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        // Opsional: Nonaktifkan SpriteRenderer setelah fade out
        targetSprite.enabled = false;

        // Jika ingin menghancurkan objek setelah fade out
        // Destroy(targetSprite.gameObject);
    }
}

