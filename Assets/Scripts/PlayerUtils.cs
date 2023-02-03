using UnityEngine;

public static class PlayerUtils
{
    public static bool IsPlayer(this Collider collider)
    {
        if (collider.transform.parent == null) return false;
        return collider.transform.parent.CompareTag("Player");
    }
}
