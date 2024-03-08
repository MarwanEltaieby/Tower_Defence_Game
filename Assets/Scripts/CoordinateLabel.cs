using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockColor = Color.gray;
    private TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    private void Awake() {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        label.enabled = true;
        DisplayCoordinates();
    }

    private void Update() {
        if (!Application.isPlaying) {
            DisplayCoordinates();
            UpdateName();
        }
        SetLabelColor();
        ToggleLabels();
    }

    private void SetLabelColor() {
        if(!waypoint.IsPlaceable) {
            label.color = blockColor;
        } else {
            label.color = defaultColor;
        }
    }

    private void ToggleLabels() {
        if (Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.IsActive();
        }
    }

    private void DisplayCoordinates() {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x); // /10
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); // /10
        label.text = coordinates.x + "," + coordinates.y;
    }

    private void UpdateName() {
        transform.parent.name = coordinates.ToString();
    }
}
