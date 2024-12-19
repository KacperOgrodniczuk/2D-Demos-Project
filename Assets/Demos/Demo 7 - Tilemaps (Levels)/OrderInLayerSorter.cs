using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class OrderInLayerSorter : EditorWindow
{
    Transform environmentParent;     //Top-parent object of the environment as this is what we will use to cycle thorugh environment objects.
    string[] sortingLayers;         // Array to hold existing sorting layer names
    int selectedLayerIndex = 1;     // Index of the selected sorting layer
    bool sortNestedChildren = true;

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
        environmentParent = (Transform)EditorGUILayout.ObjectField(
            new GUIContent("Environment Parent", "This tool assumes all the props that need to be dynamically sorted are under the same gameobject."), 
            environmentParent, 
            typeof(Transform), 
            true
            );

        selectedLayerIndex = EditorGUILayout.Popup(
            new GUIContent("Sorting Layer", "Select the sorting layer you want the sorted objects to be set to."),
            selectedLayerIndex, 
            sortingLayers
            );

        sortNestedChildren = EditorGUILayout.Toggle(
            new GUIContent("Sort Nested Children", "Sort the order in layer of props' children?"), 
            sortNestedChildren);

        if (GUILayout.Button("Update Sorting Layers"))
        {
            if (environmentParent != null)
            {
                UpdateSortingLayers(environmentParent);
            }
            else
            {
                Debug.LogWarning("Environment Parent is not set. Please assign it first.");
            }
        }
    }

    public void UpdateSortingLayers(Transform dynamicSortParentObject)
    {
        foreach (Transform child in dynamicSortParentObject)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = Mathf.RoundToInt(child.position.y * -100);
                spriteRenderer.sortingLayerName = "Dynamic Layer";
            }

            if (sortNestedChildren)
            {
                UpdateSortingLayers(child);
            }
        }

        Debug.Log("Sorting layers updated for all children of " + dynamicSortParentObject);
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
