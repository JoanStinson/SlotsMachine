using UnityEngine;

[CreateAssetMenu(menuName = "Roller Item Sequence", fileName = "New Roller Item Sequence")]
public class RollerItemSequence : ScriptableObject
{
    [SerializeField]
    private RollerItemType[] _rollerItemTypes;
}
