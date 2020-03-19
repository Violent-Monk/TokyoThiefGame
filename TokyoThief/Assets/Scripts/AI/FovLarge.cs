using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovLarge : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();// coordinates for visible targets

    public float meshResolution;
    public int edgeResolveIterations;
    public float edgeDstThreshold;

    public MeshFilter viewMeshFilterLarge;
    Mesh viewMeshLarge;

    Material fovMat;
    Color colorAlert = Color.green;
    Color colorGuarding;

    public EnemyPatrol enemyPatrol;

    private void Start()
    {
        viewMeshLarge = new Mesh();
        viewMeshLarge.name = "View Mesh Large";
        viewMeshFilterLarge.mesh = viewMeshLarge;
        StartCoroutine("FindTargetsWithDelay", .1f);
        fovMat = viewMeshFilterLarge.GetComponent<Renderer>().material;
        colorGuarding = fovMat.color;
    }

    private void Update()
    {
        if (visibleTargets.Count == 0)
        {
            fovMat.SetColor("_Color", colorGuarding);
        }
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargetsLarge();
        }
    }

    private void LateUpdate()
    {
        DrawFieldOfViewLarge();
    }

    void FindVisibleTargetsLarge()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask); // number of targets within viewing distance

        for (int i = 0; i < targetsInViewRadius.Length; i++) // for each target, check if we can see them
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) // check for obstacles
                {
                    // we have line of sight
                    visibleTargets.Add(target);
                    fovMat.SetColor("_Color", colorAlert);
                    // if not already investigating, investigate
                    if (enemyPatrol.investigating == false)
                    {
                        enemyPatrol.investigating = true;
                        enemyPatrol.investLoc = target;
                    }
                    //FindObjectOfType<GameManager>().EndGame();
                }
            }
        }
    }

    void DrawFieldOfViewLarge() // generate mesh (will be child of character)
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution); // resolution i.e. number of rays
        float stepAngleSize = viewAngle / stepCount; // size of rays
        List<Vector3> viewPoints = new List<Vector3>(); // endpoints of rays
        ViewCastInfoLarge oldViewCast = new ViewCastInfoLarge();

        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i; // angle between rays
            ViewCastInfoLarge newViewCast = ViewCastLarge(angle);

            // find the edge of obstacle and cast at it to resolve jitter near edge without increasing resolution
            if (i > 0)
            {
                bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.dst - newViewCast.dst) > edgeDstThreshold;
                if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded))
                {
                    EdgeInfoLarge edge = FindEdgeLarge(oldViewCast, newViewCast);
                    if (edge.pointA != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointA);
                    }
                    if (edge.pointB != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointB);
                    }
                }
            }

            viewPoints.Add(newViewCast.point);
            oldViewCast = newViewCast;
        }

        // calculate triangles
        int vertexCount = viewPoints.Count + 1; // # of vertices = endpoints of rays + origin
        Vector3[] vertices = new Vector3[vertexCount]; // array of vertex positions
        int[] triangles = new int[(vertexCount - 2) * 3]; // Unity wants an index of vertices for each triangle

        // vertices must be relative to character, not global
        vertices[0] = new Vector3(0, -.5f, 0); // origin vertex
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]) + new Vector3(0, -.5f, 0); // convert from global point to character relative, and move it to ground

            if (i < vertexCount - 2)
            {
                //vertices for each triangle
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        viewMeshLarge.Clear();
        viewMeshLarge.vertices = vertices;
        viewMeshLarge.triangles = triangles;
        viewMeshLarge.RecalculateNormals();
    }

    EdgeInfoLarge FindEdgeLarge(ViewCastInfoLarge minViewCast, ViewCastInfoLarge maxViewCast) // find the edge of the obstacle we hit
    {
        float minAngle = minViewCast.angle;
        float maxAngle = maxViewCast.angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;

        for (int i = 0; i < edgeResolveIterations; i++)
        {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInfoLarge newViewCast = ViewCastLarge(angle);

            bool edgeDstThresholdExceeded = Mathf.Abs(minViewCast.dst - newViewCast.dst) > edgeDstThreshold;
            if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded)
            {
                minAngle = angle;
                minPoint = newViewCast.point;
            }
            else
            {
                maxAngle = angle;
                maxPoint = newViewCast.point;
            }
        }

        return new EdgeInfoLarge(minPoint, maxPoint);
    }

    ViewCastInfoLarge ViewCastLarge(float globalAngle)
    {
        Vector3 dir = DirFromAngleLarge(globalAngle, true);
        RaycastHit hit;

        // check if we hit something
        if (Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask))
        {
            return new ViewCastInfoLarge(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfoLarge(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }

    public Vector3 DirFromAngleLarge(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public struct ViewCastInfoLarge
    {
        public bool hit; // did the ray hit something
        public Vector3 point; // endpoint of ray
        public float dst; // length of ray
        public float angle; // angle ray was fired at

        public ViewCastInfoLarge(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }

    public struct EdgeInfoLarge
    {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfoLarge(Vector3 _pointA, Vector3 _pointB)
        {
            pointA = _pointA;
            pointB = _pointB;
        }
    }
}
