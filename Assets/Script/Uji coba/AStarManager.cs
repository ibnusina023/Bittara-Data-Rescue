using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics; // Untuk Stopwatch
using System.IO; // Untuk menyimpan ke file

public class AStarManager : MonoBehaviour
{
    public static AStarManager instance;

    public List<double> executionTimes = new List<double>();

    private void Awake()
    {
        instance = this;
    }

    public List<Node> GeneratePath(Node start, Node end)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        foreach (Node n in FindObjectsOfType<Node>())
        {
            n.gScore = float.MaxValue;
            n.hScore = 0;
            n.cameFrom = null;
        }

        start.gScore = 0;
        start.hScore = Vector2.Distance(start.transform.position, end.transform.position);
        openSet.Add(start);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].FScore() < currentNode.FScore())
                    currentNode = openSet[i];
            }

            if (currentNode == end)
            {
                stopwatch.Stop();
                double elapsed = stopwatch.Elapsed.TotalMilliseconds;
                executionTimes.Add(elapsed);
                UnityEngine.Debug.Log($"[A*] Waktu eksekusi pencarian jalur: {elapsed:F3} ms");
                return ReconstructPath(end);
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            foreach (Node neighbor in currentNode.connections)
            {
                if (closedSet.Contains(neighbor))
                    continue;

                float tentativeG = currentNode.gScore + Vector2.Distance(currentNode.transform.position, neighbor.transform.position);

                if (tentativeG < neighbor.gScore)
                {
                    neighbor.cameFrom = currentNode;
                    neighbor.gScore = tentativeG;
                    neighbor.hScore = Vector2.Distance(neighbor.transform.position, end.transform.position);

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        stopwatch.Stop();
        double failElapsed = stopwatch.Elapsed.TotalMilliseconds;
        executionTimes.Add(failElapsed);
        UnityEngine.Debug.LogWarning("[A*] Jalur tidak ditemukan.");
        UnityEngine.Debug.Log($"[A*] Waktu eksekusi pencarian gagal: {failElapsed:F3} ms");
        return null;
    }

    public void SaveTimesToFile()
    {
        string path = Application.dataPath + "/execution_times.txt";
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (double time in executionTimes)
            {
                writer.WriteLine(time.ToString("F3") + " ms");
            }
        }
        UnityEngine.Debug.Log("Waktu eksekusi disimpan di: " + path);
    }

    private List<Node> ReconstructPath(Node endNode)
    {
        List<Node> path = new List<Node>();
        Node current = endNode;

        while (current != null)
        {
            path.Add(current);
            current = current.cameFrom;
        }

        path.Reverse();
        return path;
    }

    public Node FindNearestNode(Vector2 pos)
    {
        Node nearest = null;
        float minDistance = float.MaxValue;

        foreach (Node node in FindObjectsOfType<Node>())
        {
            float dist = Vector2.Distance(pos, node.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                nearest = node;
            }
        }

        return nearest;
    }

    public Node FindFurthestNode(Vector2 pos)
    {
        Node furthest = null;
        float maxDistance = 0;

        foreach (Node node in FindObjectsOfType<Node>())
        {
            float dist = Vector2.Distance(pos, node.transform.position);
            if (dist > maxDistance)
            {
                maxDistance = dist;
                furthest = node;
            }
        }

        return furthest;
    }

    public Node[] AllNodes()
    {
        return FindObjectsOfType<Node>();
    }
}
