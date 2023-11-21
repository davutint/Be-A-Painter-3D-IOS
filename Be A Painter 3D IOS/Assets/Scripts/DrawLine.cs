using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrawLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    List<Vector2> sayi;









    /*public void UpdadeLine(Vector2 mousepoz)
    {
        if (sayi == null)
        {
            
            sayi = new List<Vector2>();

            SayiKaydet(mousepoz);
        }
        
        if (Vector2.Distance(sayi.Last(), mousepoz) > .1f)
        {
            SayiKaydet(mousepoz);
        }


    }

    public void SayiKaydet(Vector2 sayis)
    {
        sayi.Add(sayis);
        lineRenderer.positionCount = sayi.Count;
        lineRenderer.SetPosition(sayi.Count - 1, sayis);

        if (sayi.Count > 1)
        {
            edgeCollider.points = sayi.ToArray();
        }
    }*/


}
