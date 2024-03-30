using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MoveFromInitPositionTrigger : MonoBehaviour
{
    public Animator lightAnimator;
    public string animationName;
    public float safeDistanceMargin = 1;
    public ShadowManMovement shadowMan;

    private Vector3 initialBoxPosition;
    private bool doneTheAction;

    void Start()
    {
        initialBoxPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > (initialBoxPosition.x + safeDistanceMargin) && !doneTheAction) 
        {
            doneTheAction = true;
            lightAnimator.Play(animationName);
            StartCoroutine(DestroyingShadow());
        }
    }

    IEnumerator DestroyingShadow()
    {
        yield return new WaitForSeconds(1f);
        Destroy(shadowMan.gameObject);
    }
}
