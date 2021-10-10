using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float startTime = 3.0f;
    public int score;
    public float lifeTime = 1.0f;
    public int hitBlockScore = 10;
    public float missBlockLife = 0.1f;
    public float wrongBlockLife = 0.08f;
    public float lifeRegenRate = 0.1f;

    // instance
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    public void AddScore(){
        score += hitBlockScore;
        GameUI.instance.UpdateScoreText();
    }
    public void MissBlock(){
        lifeTime -= missBlockLife;
    }
    public void HitWrongBlock(){
        lifeTime -= wrongBlockLife;
    }
    private void Update() {
        lifeTime = Mathf.MoveTowards(lifeTime, 1.0f, lifeRegenRate * Time.deltaTime);
        GameUI.instance.UpdateLifetimeBar();
    }
}
