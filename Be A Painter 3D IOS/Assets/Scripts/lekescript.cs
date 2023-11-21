using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class lekescript: MonoBehaviour
{
    Color color;
    Vector3 boyutlandır = new Vector3(.2f, .2f, 1f);
    private void Start()
    {

        this.transform.DOScale(boyutlandır, .25f);
        this.GetComponent<SpriteRenderer>().DOFade(0, 5).OnComplete(() =>
        {
            Destroy(this.gameObject);
        });
        /*color=new Color(0,0,0,0);
        this.GetComponent<SpriteRenderer>().DOColor(color,5).OnComplete(() =>
        {
            Destroy(this.gameObject);
        });*/
        
        /*this.transform.DOScale(new Vector3(0.05f, 0.05f, 0.05f), 5f).OnComplete(() =>
        {
            Destroy(this.gameObject);
        });*/
    }
}
    