using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using TMPro;

public class Player : MonoBehaviour
{
    public int score;
    public int userId;
    public GameObject highScoreText;
    
    static DatabaseReference dbRef;
    // Start is called before the first frame update
    public Player()
    {

    }

    public Player(int score, int userId)
    {
        this.score = score;
        this.userId = userId;
    }
    
    static public void writeNewScore(int score)
    {
        System.Random random = new System.Random();
        int id = random.Next(1000);

        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        dbRef.Child("player").Child("score").SetValueAsync(score);

    }

    static public int getHighScore()
    {
        FirebaseDatabase.DefaultInstance.GetReference("player").GetValueAsync().ContinueWith(task => {
            DataSnapshot snapshot = task.Result;
            return snapshot.Child("score").Value;
        });

        return 0;
            
    }
    public void DisplayHighScore()
    {
        int skor=getHighScore();
        highScoreText.GetComponent<TextMeshProUGUI>().text = "Skor Tertinggi: " + skor.ToString();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
