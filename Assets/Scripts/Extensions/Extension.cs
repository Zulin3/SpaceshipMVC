using UnityEngine;

public static class Extension
{
    public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
    {
        var component = gameObject.GetOrAddComponent<SpriteRenderer>();
        component.sprite = sprite;
        return gameObject;
    }

    public static Rigidbody AddRigidbody(this GameObject gameObject)
    {
        var component = gameObject.GetOrAddComponent<Rigidbody>();
        component.useGravity = false;
        return component;
    }

    private static T GetOrAddComponent<T>(this GameObject gameObject) where T: Component
    {
        var result = gameObject.GetComponent<T>();
        if (!result)
        {
            result = gameObject.AddComponent<T>();
        }

        return result;
    }
}