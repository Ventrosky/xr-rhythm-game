using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockColor{
    Green,
    Red
}
public class Block : MonoBehaviour {
    public BlockColor color;

    public GameObject brokenBlockLeft;
    public GameObject brokenBlockRight;
    public float brokenBlockForce;
    public float brokenBlockTorque;
    public float brokenBlockDestroyDelay;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("SwordRed")){
            if(color == BlockColor.Red){
                GameManager.instance.AddScore();
            } else {
                GameManager.instance.HitWrongBlock();
            }
            Hit();
        } else if (other.CompareTag("SwordGreen")){
            if(color == BlockColor.Green){
                GameManager.instance.AddScore();
            } else {
                GameManager.instance.HitWrongBlock();
            }
            Hit();
        }

    }

    void Hit(){
        // enable broken pieces
        brokenBlockLeft.SetActive(true);
        brokenBlockRight.SetActive(true);

        // remove as children
        brokenBlockLeft.transform.parent = null;
        brokenBlockRight.transform.parent = null;
        
        Rigidbody leftRig = brokenBlockLeft.GetComponent<Rigidbody>();
        Rigidbody rigthRig = brokenBlockRight.GetComponent<Rigidbody>();

        leftRig.AddForce(-transform.right * brokenBlockForce, ForceMode.Impulse);
        rigthRig.AddForce(transform.right * brokenBlockForce, ForceMode.Impulse);

        leftRig.AddTorque(-transform.forward * brokenBlockTorque, ForceMode.Impulse);
        rigthRig.AddTorque(transform.forward * brokenBlockTorque, ForceMode.Impulse);

        Destroy(brokenBlockLeft, brokenBlockDestroyDelay);
        Destroy(brokenBlockRight, brokenBlockDestroyDelay);
        Destroy(gameObject);
    }
}
