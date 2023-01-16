using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tool Action/Mob Behavior")]
public class MobInteraction : ToolAction
{
    [SerializeField] float sizeOfInteractableArea = 1f;
    [SerializeField] int ToolDamage = 1;
    public override bool OnApply(Vector2 worldPoint)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPoint, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.GetDamage(ToolDamage);
                hit.Hit();
                return true;
            }
        }

        return false;
    }
}
