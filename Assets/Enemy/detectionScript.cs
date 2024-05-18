using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionScript : MonoBehaviour
{
    public bool detected;
    public Vector2 direction => target.transform.position - detector.position;

    [Header("OverlapBox")]
    public Transform detector;
    public Vector2 detectorSize = Vector2.one;
    public Vector2 detectorOffset = Vector2.zero;

    private GameObject target;

    public float detectDelay = 0.3f;

    public LayerMask detectorLayer;

    [Header("Gizmo")]
    public Color gizmoIdle = Color.green;
    public Color gizmoDetected = Color.red;
    public bool showGizmo = true;

    public GameObject Target
    {
        get => target;
        private set
        {
            target = value;
            detected = target != null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(detectCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 direction = player.transform.position - transform.position;

    }

    IEnumerator detectCoroutine()
    {
        yield return new WaitForSeconds(detectDelay);
        performDetect();
        StartCoroutine(detectCoroutine());
    }

    public void performDetect()
    {
        Collider2D collider = Physics2D.OverlapBox((Vector2)transform.position + detectorOffset * transform.rotation.x, 
            detectorSize, 0, detectorLayer);
        if (collider != null)
        {
            Target = collider.gameObject;
        }
        else
        {
            Target = null;
        }
    }

    private void OnDrawGizmos()
    {
        if (showGizmo)
        {
            Gizmos.color = gizmoIdle;
            if (detected)
                Gizmos.color = gizmoDetected;
            Gizmos.DrawCube((Vector2)transform.position + detectorOffset * transform.rotation.x, detectorSize);
        }
    }
}
