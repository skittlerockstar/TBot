using UnityEngine;
using System.Collections;
using System;

public class GridHandler : MonoBehaviour {

    public static int columns =13, rows;
    public static float blockSize;
    static float  VerticalHightSeen;
    static float HorizontalHeightSeen;
    public static float positionUnit;
    static float startingPosition;
    static float startingPositionY;
    static Vector2 screenSize = new Vector2(Screen.width, Screen.height);
    // Use this for initialization
    void Awake()
    {
        VerticalHightSeen = Camera.main.orthographicSize * 2.0f;
        HorizontalHeightSeen = VerticalHightSeen * Screen.width / Screen.height;
        positionUnit = HorizontalHeightSeen / columns;
        startingPosition =( -HorizontalHeightSeen /2 - positionUnit /2);
        startingPositionY = (VerticalHightSeen / 2 + positionUnit / 2) -positionUnit;
    }

    public static void resizeObject(GameObject obj)
    {
        float finalSize = getFinalSize(obj);
        obj.transform.localScale = new Vector3(finalSize, finalSize);
    }

    private static float getFinalSize(GameObject obj)
    {
        Vector2 GOunit = getUnitSize(obj);
        float finalSize = HorizontalHeightSeen / GOunit.x;
        finalSize = finalSize /13;
        return finalSize;
    }

    public static Vector2 getUnitSize(GameObject g)
    {
        SpriteRenderer rend = g.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        Sprite s = rend.sprite;
        float unitWidth = s.textureRect.width / s.pixelsPerUnit;
        float unitHeight = s.textureRect.height / s.pixelsPerUnit;
        return new Vector2(unitWidth, unitHeight);
    }
    public static void placeObjectAt(GameObject g,Vector2 gridPosition,Vector2 size)
    {
        Vector2 u = getUnitSize(g);
        float finalSize = getFinalSize(g);
        float scalingCorrectionY = (positionUnit /2)*(size.y-1);
        float scalingCorrectionX = (positionUnit / 2) * (size.x - 1);
        g.transform.localScale = new Vector3(finalSize * size.x, finalSize * size.y);
        float finalPositionX = startingPosition + (positionUnit * gridPosition.x) + scalingCorrectionX;
        float finalPositionY = startingPositionY - (positionUnit * gridPosition.y) - scalingCorrectionY;
        g.transform.localPosition = new Vector3(finalPositionX, finalPositionY,g.transform.localPosition.z);
        resizeBoxCollider(g);
    }

    private static void resizeBoxCollider(GameObject g)
    {
      
    }

    public static void hasObjectAtLocation()
    {

    }
    public static Vector2 touchToGrid(Vector2 position)
    {
        float step = screenSize.x / columns;
        int coordX = (int)(position.x / step);
        int coordY = (int)(position.y / step);
        float posx = startingPosition + (positionUnit * coordX) + positionUnit;
        float posy = startingPositionY - (positionUnit * coordY) - positionUnit;
        return new Vector2(posx, -posy);
    }
    public static void resetHitBox(GameObject gameObject)
    {
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
    }
}
