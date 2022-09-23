using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Scene02
{
    public class TriangleMotion : MonoBehaviour
    {
        [SerializeField]
        float easeTime = 0.5f;
        void Awake()
        {
            this.transform.localEulerAngles = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
            float scale = Random.Range(0.0f, 7.5f);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(this.transform.DOScaleZ(scale, Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
            sequence.Join(this.transform.DOScaleX(scale, Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
            sequence.Join(this.transform.DOScaleY(0.1f, Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
            //sequence.Append(this.transform.DOScaleZ(0.0f, Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
            //sequence.Join(this.transform.DOScaleX(0.0f, Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
            //sequence.Join(this.transform.DOScaleY(0.0f, Random.Range(easeTime, easeTime * 2)).SetEase(Ease.OutSine));
            sequence.Play();
            sequence.OnComplete(() =>
            {
                Destroy(this.gameObject);
            });


        }
        void Update()
        {

        }
    }

}
