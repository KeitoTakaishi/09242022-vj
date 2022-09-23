using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMotion : MonoBehaviour
{
    [SerializeField]
    float easeTime = 0.1f;
    void Awake()
    {
        this.transform.localEulerAngles = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
        Sequence sequence = DOTween.Sequence();
        
        //Bigger
        sequence.Append(this.transform.DOScaleZ(Random.Range(0.0f, 100.0f), Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
        sequence.Join(this.transform.DOScaleX(Random.Range(0.0f, 0.2f), Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
        sequence.Join(this.transform.DOScaleY(Random.Range(0.0f, 0.2f), Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
        
        //Smaller
        sequence.Append(this.transform.DOScaleZ(Random.Range(0.0f, 0.0f), Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
        sequence.Join(this.transform.DOScaleX(Random.Range(0.0f, 0.0f), Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
        sequence.Join(this.transform.DOScaleY(Random.Range(0.0f, 0.0f), Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
        
        sequence.Play();
        sequence.OnComplete(() =>
        {
            Destroy(this.gameObject);
        });
    }
}