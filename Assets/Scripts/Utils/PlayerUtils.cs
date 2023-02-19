using UnityEngine;

public static class PlayerUtils
{
    public static bool IsPlayer(this Collider collider)
    {
        if (collider == null) return false;
        return collider.CompareTag("Player");
    }
    public static bool IsPlayer(this Collider collider, out Player player)
    {
        player = null;
        bool isPlayer = collider.IsPlayer();
        if (isPlayer)
        {
            player = collider.GetComponent<Player>();
        }
        return isPlayer;
    }
}
