using UnityEngine;
using Zenject;

public class WallDrawerArm : MonoBehaviour, IInteractable
{
    [Inject]
    private WallDrawer wallDrawer;
    public void Interact()
    {
        if (wallDrawer.state == WallDrawer.State.FALSE)
            wallDrawer.state = WallDrawer.State.TRUE;
        else
            wallDrawer.state = WallDrawer.State.FALSE;
        StartCoroutine(wallDrawer.Move());
    }
  
}
