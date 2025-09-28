using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [Header("Arrow Settings")]
    public Transform arrow;

    [Header("Target Settings")]
    public GameObject[] eggs;
    public float hideDistance = 2f;

    [Header("Arrow Orientation")]
    public Vector3 arrowForwardAxis = Vector3.up;
    public Vector3 arrowUpAxis = -Vector3.forward;

    private GameObject closestEgg;
    private Renderer arrowRenderer;

    void Start()
    {

        if (arrow != null)
        {
            arrowRenderer = arrow.GetComponent<Renderer>();
        }

        if (eggs.Length == 0)
        {
            eggs = GameObject.FindGameObjectsWithTag("Egg");
        }
    }

    void Update()
    {
        if (arrow == null || eggs.Length == 0) return;

        FindClosestEgg();
        PointArrowToTarget();
        CheckDistanceAndVisibility();
    }

    void FindClosestEgg()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEgg = null;

        foreach (GameObject egg in eggs)
        {
            if (egg == null) continue;

            float distance = Vector3.Distance(transform.position, egg.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEgg = egg;
            }
        }

        closestEgg = nearestEgg;
    }

    void PointArrowToTarget()
    {
        if (closestEgg == null) return;


        Vector3 targetDirection = (closestEgg.transform.position - transform.position).normalized;


        Vector3 currentForward = arrow.TransformDirection(arrowForwardAxis.normalized);
        Vector3 currentUp = arrow.TransformDirection(arrowUpAxis.normalized);


        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);


        Vector3 correctedDirection = targetDirection;
        if (arrowForwardAxis == Vector3.up)
        {
            float angle = Mathf.Atan2(correctedDirection.x, correctedDirection.z) * Mathf.Rad2Deg;
            arrow.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }

        else if (arrowForwardAxis == Vector3.forward)
        {
            arrow.rotation = Quaternion.LookRotation(correctedDirection);
        }

        else
        {

            Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
            Quaternion axisCorrection = Quaternion.FromToRotation(Vector3.forward, arrowForwardAxis);
            arrow.rotation = lookRotation * Quaternion.Inverse(axisCorrection);
        }
    }

    void CheckDistanceAndVisibility()
    {
        if (closestEgg == null || arrowRenderer == null) return;

        float distanceToTarget = Vector3.Distance(transform.position, closestEgg.transform.position);


        arrowRenderer.enabled = distanceToTarget > hideDistance;
    }

}