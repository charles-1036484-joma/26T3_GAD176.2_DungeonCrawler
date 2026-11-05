using UnityEngine;


public abstract class GeneratorScript : MonoBehaviour
{
    // The prefab to be instantiated by the generator.
    [SerializeField] protected GameObject prefab;

    // Abstract method to be implemented by derived classes for generating objects.
    public abstract void Generate();
}
