using UnityEngine;
using UnityEditor;

public class OrderInLayerSorter : EditorWindow
{
    Transform environmentParent;     //Top-parent object of the environment as this is what we will use to cycle thorugh environment objects.
    string[] sortingLayers;         // Array to hold existing sorting layer names
    int selectedLayerIndex = 0;     // Index of the selected sorting layer

    [MenuItem("Tools/Order In Layer Sorter")]   //Adds the tool to Unity's menu bar

    public static void ShowWindow()
    {
        GetWindow<OrderInLayerSorter>("Order In Layer Sorter");
    }

    private void OnEnable()
    {
        // Get all sorting layers and store them in an array
        sortingLayers = GetSortingLayerNames();
    }

    private void OnGUI()
    {
        // Input field for the environment parent
        environmentParent = (Transform)EditorGUILayout.ObjectField("Environment Parent", environmentParent, typeof(Transform), true);
        selectedLayerIndex = EditorGUILayout.Popup("Sorting Layer", selectedLayerIndex, sortingLayers);

        if (GUILayout.Button("Update Sorting Layers"))
        {
            if (environmentParent != null)
            {
                UpdateSortingLayers();
            }
            else
            {
                Debug.LogWarning("Environment Parent is not set. Please assign it first.");
            }
        }
    }

    public void UpdateSortingLayers()
    {
        foreach (Transform child in environmentParent)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sortingOrder = Mathf.RoundToInt(child.position.y * -10);
                sr.sortingLayerName = "Dynamic Layer";
            }
        }

        Debug.Log("Sorting layers updated for all children of " + environmentParent.name);
    }

    private string[] GetSortingLayerNames()
    {
        // Get all the sorting layers in Unity
        var sortingLayerCount = SortingLayer.layers.Length;
        string[] layers = new string[sortingLayerCount];

        for (int i = 0; i < sortingLayerCount; i++)
        {
            layers[i] = SortingLayer.layers[i].name;
        }

        return layers;
    }
}
