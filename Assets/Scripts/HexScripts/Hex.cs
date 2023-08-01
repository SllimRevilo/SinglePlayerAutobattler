using UnityEngine;

public class Hex : MonoBehaviour
{
    [SerializeField]
    private float yOffset;

    public GameObject currentObject;

    public void PlaceUnit(GameObject objectToPlace)
    {
        // if there is an object on this hex
        if(currentObject != null)
        {
            // place the current unit onto the held object's previous hex
            Hex otherHex = objectToPlace.GetComponent<MoveableObject>().currentHex;
            otherHex.PlaceUnit(RemoveObject());
        }

        // set the new object to this hex's position
        Vector3 position = transform.position;
        position.y += yOffset;
        objectToPlace.transform.position = position;

        // uopdate the hex and the object
        currentObject = objectToPlace;
        currentObject.GetComponent<MoveableObject>().currentHex = this;
    }

    public GameObject RemoveObject()
    {
        GameObject go = currentObject;
        currentObject = null;
        return go;
    }

    public bool AddMoveableObject()
    {
        if (currentObject == null)
        {
            Vector3 position = transform.position;
            position.y += yOffset;

            currentObject = Instantiate(GameManager.Instance.moveableObjectManager.unitPrefab, position, transform.rotation);
            currentObject.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);

            currentObject.GetComponent<MoveableObject>().currentHex = this;
            return true;
        }
        else
        {
            return false;
        }
    }
}