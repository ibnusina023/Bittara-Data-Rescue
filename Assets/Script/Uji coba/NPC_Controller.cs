using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    public Node currentNode;
    public List<Node> path = new List<Node>();

    public PlayerMovement player;
    public float speed = 3f;
    public float pathUpdateInterval = 1.5f;
    public float playerMoveThreshold = 1f;

    private float pathTimer;
    private Vector2 lastPlayerPosition;
    private Node lastStartNode;

    [Header("Activation Settings")]
    public bool needsKeyToActivate = true;
    public KeyManager key;
    private bool isActive = false;

    private void Start()
    {
        lastPlayerPosition = player.transform.position;
    }

    private void Update()
    {
        // Aktivasi NPC
        if (!isActive)
        {
            if (!needsKeyToActivate || (key != null && key.IsPickedUp))
            {
                isActive = true;
                UpdatePathToPlayer(); // Langsung jalan saat aktif
                lastPlayerPosition = player.transform.position;
                pathTimer = 0f;
            }
            else
            {
                return;
            }
        }

        // Update path jika interval terpenuhi dan player bergerak cukup jauh
        pathTimer += Time.deltaTime;

        if (pathTimer >= pathUpdateInterval &&
            Vector2.Distance(player.transform.position, lastPlayerPosition) > playerMoveThreshold)
        {
            UpdatePathToPlayer();
            pathTimer = 0f;
            lastPlayerPosition = player.transform.position;
        }

        MoveAlongPath();
    }

    void UpdatePathToPlayer()
    {
        Node startNode;

        // Gunakan currentNode jika cukup dekat
        if (currentNode != null && Vector2.Distance(transform.position, currentNode.transform.position) < 0.5f)
        {
            startNode = currentNode;
        }
        else
        {
            startNode = AStarManager.instance.FindNearestNode(transform.position);
        }

        Node targetNode = AStarManager.instance.FindNearestNode(player.transform.position);

        // Hindari update jika startNode tidak berubah dan NPC belum benar-benar pindah node
        if (startNode == lastStartNode && Vector2.Distance(transform.position, currentNode.transform.position) < 0.5f)
            return;

        if (startNode != null && targetNode != null)
        {
            List<Node> newPath = AStarManager.instance.GeneratePath(startNode, targetNode);

            // Update path hanya jika path baru berbeda dari sebelumnya
            if (newPath != null && !IsSamePath(path, newPath))
            {
                path = newPath;
                currentNode = startNode;
                lastStartNode = startNode;
            }
        }
    }

    void MoveAlongPath()
    {
        if (path.Count > 0)
        {
            Vector3 targetPos = new Vector3(path[0].transform.position.x, path[0].transform.position.y, -2);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, path[0].transform.position) < 0.1f)
            {
                currentNode = path[0];
                path.RemoveAt(0);
            }
        }
    }

    bool IsSamePath(List<Node> oldPath, List<Node> newPath)
    {
        if (oldPath == null || newPath == null || oldPath.Count != newPath.Count)
            return false;

        for (int i = 0; i < oldPath.Count; i++)
        {
            if (oldPath[i] != newPath[i])
                return false;
        }

        return true;
    }

    private void OnDrawGizmos()
    {
        if (path != null && path.Count > 0)
        {
            Gizmos.color = Color.red;
            Vector3 previous = transform.position;

            foreach (Node node in path)
            {
                if (node != null)
                {
                    Gizmos.DrawLine(previous, node.transform.position);
                    previous = node.transform.position;
                }
            }
        }
    }
}
