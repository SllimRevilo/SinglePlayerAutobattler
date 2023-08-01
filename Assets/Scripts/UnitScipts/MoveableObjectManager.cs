using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveableObjectManager : MonoBehaviour
{
    public GameObject unitPrefab;

    public MoveableObject heldMoveableObject;

    public Vector3 mouseOffest;
    public float mouseZCoordinate;
    public float yPosition;

    [SerializeField]
    private LayerMask movementLayer;
    [SerializeField]
    private LayerMask hexLayer;
    [SerializeField]
    private LayerMask moveableObjectLayer;

    private void Awake()
    {
        mouseOffest = Vector3.zero;
        mouseZCoordinate = 0;
    }

    private void Start()
    {
        GameManager.Instance.hexGrid.hexes[0].AddMoveableObject();
        GameManager.Instance.hexGrid.hexes.Last().AddMoveableObject();
    }

    private void Update()
    {
        UpdatePosition();
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(heldMoveableObject == null)
            {
                if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, moveableObjectLayer))
                {
                    MoveableObject moveableObject = raycastHit.collider.GetComponent<MoveableObject>();
                    moveableObject.currentHex.RemoveObject();
                    heldMoveableObject = moveableObject;
                    Debug.LogWarning("Pick up: " + heldMoveableObject);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(heldMoveableObject != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, hexLayer))
                {
                    Debug.LogWarning("Place: " + raycastHit.collider.gameObject);
                    raycastHit.collider.GetComponent<Hex>().PlaceUnit(heldMoveableObject.gameObject);
                    heldMoveableObject = null;
                }
            }
        }
    }

    public void PlaceObject()
    {

    }

    public void UpdatePosition()
    {
        if(heldMoveableObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, movementLayer))
            {
                Vector3 pos = raycastHit.point;
                pos.y = heldMoveableObject.transform.position.y;
                heldMoveableObject.transform.position = pos;
            }
        }
    }
}
