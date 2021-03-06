using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public float startTime = 3.0f;
    public int score;
    public float lifeTime = 1.0f;
    public int hitBlockScore = 10;
    public float missBlockLife = 0.1f;
    public float wrongBlockLife = 0.08f;
    public float lifeRegenRate = 0.1f;
    public float swordHitVelocityThreshold = 0.5f;

    // instance
    public static GameManager instance;

    public VelocityTracker leftSwordTracker;
    public VelocityTracker rigthSwordTracker;

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

        if(lifeTime <= 0) 
            LoseGame();
        
        GameUI.instance.UpdateLifetimeBar();
    }

    public void WinGame(){
        SceneManager.LoadScene(0);
    }
    public void LoseGame(){
        SceneManager.LoadScene(0);
    }
}
