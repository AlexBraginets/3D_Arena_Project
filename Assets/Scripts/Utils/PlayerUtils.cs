using UnityEngine;

public static class PlayerUtils
{
    public static bool IsPlayer(this Collider collider)
    {
        if (collider.transform.parent == null) return false;
        return collider.transform.parent.CompareTag("Player");
    }
    public static bool IsPlayer(this Collider collider, out Player player)
    {
        player = null;
        bool isPlayer = collider.IsPlayer();
        if (isPlayer)
        {
            player = collider.transform.parent.GetComponent<Player>();
        }
        return isPlayer;
    }
}
