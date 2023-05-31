using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

int score=0;

public class DynamicPlayerController : MonoBehaviour
{
    public float JumpFactor = 0;
    public Rigidbody2D Rb;
    public Color Pink;
    public Color Blue;
    public Color Yellow;
    public Color Green;
    public SpriteRenderer Sr;
    string PlayerColor;
    
    [SerializeField] DynamicLevelController DC;
    [SerializeField] int NoOfObjects;
    int CreatedObj = 1;
    // Start is called before the first frame update
    public int GetScore()
    {
        return score;
    }
    void Start()
    {
        SetColor();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChange")
        {
            Destroy(collision.gameObject);
            string PrevColor = PlayerColor;
            while (PlayerColor == PrevColor)
            {
                SetColor();
            }
            DC.DeletePrev();
            if (CreatedObj < NoOfObjects)
                DC.Spawner();
            CreatedObj++;
        }
        else if (collision.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            score += 10;
            Debug.Log("Score: " + score);
        }
        else if (collision.tag == "End")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.tag != PlayerColor)
        {
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetButtonDown("Jump"))
        {
            Rb.velocity = Vector2.up * JumpFactor;
        }
    }
    void SetColor()
    {
        int Rn = Random.Range(0, 4);
        switch (Rn)
        {
            case 0:
                Sr.color = Pink;
                PlayerColor = "Pink";
                break;
            case 1:
                Sr.color = Blue;
                PlayerColor = "Blue";
                break;
            case 2:
                Sr.color = Yellow;
                PlayerColor = "Yellow";
                break;
            case 3:
                Sr.color = Green;
                PlayerColor = "Green";
                break;
            default:
                break;
        }
    }
}
