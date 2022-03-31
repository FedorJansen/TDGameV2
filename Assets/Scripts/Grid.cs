using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject[,] GridField;

    public int targetX;
    public int targetZ;
    public int oldTargetX;
    public int oldTargetZ;

    private int maxX;
    private int maxZ;

    public GameObject Tower1;
    private Vector3 offset = new Vector3(0, 0.7f, 0);

    public GameObject currentTile;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] Temp;
        Temp = GameObject.FindGameObjectsWithTag("GridTile");
        foreach (GameObject Tile in Temp)
        {
            if (Tile.transform.position.x > maxX)
            {
                maxX = (int)Tile.transform.position.x;
            }
            if (Tile.transform.position.z > maxZ)
            {
                maxZ = (int)Tile.transform.position.z;
            }
        }

        GridField = new GameObject[maxX + 1, maxZ+ 1];
        foreach (GameObject Tile in Temp)
        {
            GridField[(int) Tile.transform.position.x, (int)Tile.transform.position.z] = Tile;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStats.game == true)
        {
            MouseInformation();
            if (GridField[targetX, targetZ] != null)
            {
                Vector3 currentPos = GridField[targetX, targetZ].transform.position;
                GridField[targetX, targetZ].transform.position = new Vector3(currentPos.x, -0.1f, currentPos.z);
                HighlightTile();

                if (targetX != oldTargetX || targetZ != oldTargetZ)
                {
                    Vector3 oldPos = GridField[oldTargetX, oldTargetZ].transform.position;
                    GridField[oldTargetX, oldTargetZ].transform.position = new Vector3(oldPos.x, 0, oldPos.z);
                }

                oldTargetX = targetX;
                oldTargetZ = targetZ;

                if (Input.GetMouseButtonDown(0))
                {
                    if (GridField[targetX, targetZ].transform.childCount == 0)
                    {
                        Instantiate(Tower1, currentPos + offset, Quaternion.identity, GridField[targetX, targetZ].transform);
                    }
                }
                if (Input.GetMouseButtonDown(1) && GridField[targetX, targetZ].transform.childCount == 1)
                {
                    Destroy(GridField[targetX, targetZ].transform.GetChild(0).gameObject);

                }
            }
        }
    }

    public void HighlightTile()
    {
        //if (currentTile == GridField[targetX,targetZ])
        //{
            
        //}
        //currentTile = GridField[targetX, targetZ];
    }

    void MouseInformation()
    {
        Plane plane = new Plane(Vector3.up, 0);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 tempTarget = ray.GetPoint(distance);
            targetX = (int)Mathf.Round(tempTarget.x);
            targetZ = (int)Mathf.Round(tempTarget.z);
        }
        //Safeguard system (out of bounds error)
        if (targetX < 0)
        {
            targetX = 0;
        }
        if (targetZ < 0)
        {
            targetZ = 0;
        }
        if (targetX > maxX)
        {
            targetX = maxX;
        }
        if (targetZ > maxZ)
        {
            targetZ = maxZ;
        }
    }
}
