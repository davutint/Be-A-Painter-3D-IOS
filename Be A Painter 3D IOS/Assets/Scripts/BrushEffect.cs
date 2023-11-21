using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrushEffect : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;

     LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider2D;

    public List<Vector2> fingerPositions;

    int layerarttır = 0;
    public void CreateLine()//onmousedown ile çalışmalı ayrıca boya vuruncada bu çalışmalı
    {
        
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider2D = currentLine.GetComponent<EdgeCollider2D>();

        fingerPositions.Clear();
        

        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgeCollider2D.points = fingerPositions.ToArray();

        //currentLine.GetComponent<LineRenderer>().material.DOFade(0, 10f);
        

        
        switch (GameManager.renkdegis)
        {
            case 1:
                currentLine.GetComponent<LineRenderer>().material.color = Color.red;
                break;
            case 2:
                currentLine.GetComponent<LineRenderer>().material.color = Color.blue;
                break;
            case 3:
                currentLine.GetComponent<LineRenderer>().material.color = Color.black;
                
                break;
            case 4:
                currentLine.GetComponent<LineRenderer>().material.color = new Color32(111, 45, 189, 255);//mor
                break;
            case 5:
                currentLine.GetComponent<LineRenderer>().material.color = new Color32(106, 153, 76, 255); //yesil

                break;
            case 6:
                currentLine.GetComponent<LineRenderer>().material.color = new Color32(127, 85, 57, 255); //kahverengi
                break;
            default:
                break;
        }
        

        layerarttır++;
        currentLine.GetComponent<LineRenderer>().sortingOrder=layerarttır;

        
    }

    public void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider2D.points = fingerPositions.ToArray();
    }


    public void CızgıCek()//basılı tuttuğun zaman çalışmalı,fire1
    {
        Vector2 tempFingerpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(tempFingerpos, fingerPositions[fingerPositions.Count - 1]) > .1f)
        {
            UpdateLine(tempFingerpos);
        }
    }

    
}
