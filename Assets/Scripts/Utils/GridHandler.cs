using UnityEngine;
using System.Collections;
using System;

public class GridHandler : MonoBehaviour {

    public int   columns = 5, rows;
    public float blockSize;
    float VerticalHightSeen;
    float HorizontalHeightSeen;
    public float positionUnit;
    float startingPosition;
    float startingPositionY;
    float unitWidth, unitHeight;
    Vector2 screenSize = new Vector2(Screen.width, Screen.height);
    // Use this for initialization
    void Awake()
    {
        VerticalHightSeen = Camera.main.orthographicSize * 2.0f;
        HorizontalHeightSeen = VerticalHightSeen * Screen.width / Screen.height;
        positionUnit = HorizontalHeightSeen / columns;
        startingPosition =( -HorizontalHeightSeen /2 - positionUnit /2);
        startingPositionY = (VerticalHightSeen / 2 + positionUnit / 2) -positionUnit;
    }

    public void resizeObject(GameObject obj)
    {
        float finalSize = getFinalSize(obj);
        obj.transform.localScale = new Vector3(finalSize, finalSize);
        resizeBoxCollider(obj);
    }

    private float getFinalSize(GameObject obj)
    {
        Vector2 GOunit = getUnitSize(obj);
        float finalSize = HorizontalHeightSeen / GOunit.x;
        finalSize = finalSize /columns;
        return finalSize;
    }

    public Vector2 getUnitSize(GameObject g)
    {
        SpriteRenderer rend = g.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        Sprite s = rend.sprite;
        unitWidth = s.texture.width / s.pixelsPerUnit;
        unitHeight = s.texture.height / s.pixelsPerUnit;
        return new Vector2(unitWidth, unitHeight);
    }
    public void placeObjectAt(GameObject g,Vector2 gridPosition,Vector2 size)
    {
        Vector2 u = getUnitSize(g);
        float finalSize = getFinalSize(g);
        float scalingCorrectionY = (positionUnit /2)*(size.y-1);
        float scalingCorrectionX = (positionUnit / 2) * (size.x - 1);
        g.transform.localScale = new Vector3(finalSize * size.x, finalSize * size.y);
        float finalPositionX = startingPosition + (positionUnit * gridPosition.x) + scalingCorrectionX;
        float finalPositionY = startingPositionY - (positionUnit * gridPosition.y) - scalingCorrectionY;
        g.transform.localPosition = new Vector3(finalPositionX, finalPositionY,1);
        resizeBoxCollider(g);
    }

    private void resizeBoxCollider(GameObject g)
    {
      
    }

    public void hasObjectAtLocation()
    {

    }
    public Vector2 touchToGrid(Vector2 position)
    {
        
        float step = screenSize.x / columns;
        int coordX = (int)(position.x / step);
        int coordY = (int)(position.y / step);
        float posx = startingPosition + (positionUnit * coordX) + positionUnit;
        float posy = startingPositionY - (positionUnit * coordY) - positionUnit;
     
        return new Vector2(coordX+positionUnit*2f, (coordY + positionUnit)*-1+20f);
    }
    public void resetHitBox(GameObject gameObject)
    {
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
    }
    public void resetHitBox(GameObject gameObject,Vector2 percentage)
    {
        
        gameObject.GetComponent<BoxCollider2D>().size =new Vector2(unitWidth*percentage.x,unitHeight* percentage.y);
    }
}
