using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildebel : MonoBehaviour
{
    public string id = "";
    public string[] itemNames = {""};
    public Vector2 placeOffset;
    public Vector3 placeRotationOffset;
    public Vector2[] coverdTiles;
    public bool canBeRemoved = true;

    public void SetID(string _id)
    {
        //print(_id);
        if (_id == "" || _id == null)
            id = Random.Range(100000, 1000000).ToString();
        else
            id = _id;
    }
    //public GetCoverdTile
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + new Vector3(placeOffset.x, 0, placeOffset.y), 0.05f);
        foreach (Vector2 item in coverdTiles)
        {
            Gizmos.DrawWireCube(transform.position + new Vector3(placeOffset.x, 0, placeOffset.y) + new Vector3(item.x / 2, 0, item.y / 2), new Vector3(0.3f, 0, 0.3f));
        }
    }
}
