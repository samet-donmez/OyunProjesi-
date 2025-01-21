using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Engel_2_cs : MonoBehaviour
{
    Manager_cs manager;
    public float speed = 1.0f;
    bool goRight;
    bool goUp;

    Animator animator;

    void Start()
    {
        manager = FindObjectOfType<Manager_cs>();
        animator = GetComponent<Animator>();

        transform.position = new Vector2(-5.0f, -1.5f);
    }

    void Update()
    {
        // Sahne kontrolü
        if (SceneManager.GetActiveScene().name == "Sahne1")
        {
            // Skor aralıklarına göre bool parametrelerini ayarlayın
            if (manager.score >= 0 && manager.score < 3)
            {
                animator.SetBool("Score_Above_0", true); // Skor 0 ile 3 arasında olduğunda animasyon tetiklenir
                animator.SetBool("Score_Above_3", false);
                animator.SetBool("Score_Above_6", false);
            }
            else if (manager.score >= 3 && manager.score <= 6)
            {
                animator.SetBool("Score_Above_0", false); // Skor 3 ile 6 arasında olduğunda animasyon tetiklenir
                animator.SetBool("Score_Above_3", true);
                animator.SetBool("Score_Above_6", false);
            }
            else if (manager.score > 6)
            {
                animator.SetBool("Score_Above_0", false); // Skor 6'dan büyük olduğunda animasyon tetiklenir
                animator.SetBool("Score_Above_3", false);
                animator.SetBool("Score_Above_6", true);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Sahne2")
        {
            // Skor aralıklarına göre bool parametrelerini ayarlayın
            if (manager.score >= 0 && manager.score < 3)
            {
                animator.SetBool("Score_Above_0", true); // Skor 0 ile 3 arasında olduğunda animasyon tetiklenir
                animator.SetBool("Score_Above_3", false);
                animator.SetBool("Score_Above_6", false);
            }
            else if (manager.score >= 3 && manager.score <= 6)
            {
                animator.SetBool("Score_Above_0", false); // Skor 3 ile 6 arasında olduğunda animasyon tetiklenir
                animator.SetBool("Score_Above_3", true);
                animator.SetBool("Score_Above_6", false);
            }
            else if (manager.score > 6)
            {
                animator.SetBool("Score_Above_0", false); // Skor 6'dan büyük olduğunda animasyon tetiklenir
                animator.SetBool("Score_Above_3", false);
                animator.SetBool("Score_Above_6", true);
            }
        }

        // Hareket işlemleri
        if (manager.oyunuDurdur == false)
        {
            if (transform.position.x >= -2.0f)
            {
                goRight = false;
            }
            else if (transform.position.x <= -5.86f)
            {
                goRight = true;
            }

            if (goRight)
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
            else if (!goRight)
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            }

            if (transform.position.y <= -4.3f)
            {
                goUp = true;
            }
            else if (transform.position.y >= -1.0f)
            {
                goUp = false;
            }

            if (goUp)
            {
                transform.Translate(Vector2.up * Time.deltaTime * speed);
            }
            else if (!goUp)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }
        }
    }
}
