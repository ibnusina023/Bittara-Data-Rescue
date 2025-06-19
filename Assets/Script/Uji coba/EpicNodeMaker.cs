// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EpicNodeMaker : MonoBehaviour
// {
//     // public float yNodeStart;
//     // public float yNodeEnd;
//     // public float xNodeStart;
//     // public float xNodeEnd;

//     public Node nodePrefab;
//     public List<Node> nodeList;
//     [ContextMenu("Create Nodes")]
//     public void MakeNodes()
//     {
//         for(int x = -12; x < 12; x += 2)
//         {
//             for(int y = -2; y < 10; y += 2)
//             {
//                 Node n = Instantiate(nodePrefab, new Vector2(x,y-0.5f), Quaternion.identity);
//                 nodeList.Add(n);
//             }
//         }
//     }

//     [ContextMenu("Remove Empty Nodes")]
//     public void RemoveNodes()
//     {
//         for(int i = 0; i < nodeList.Count; i++)
//         {
//             if (nodeList[i] == null)
//             {
//                 nodeList.RemoveAt(i);
//                 i--;
//             }
//         }
//     }

//     [ContextMenu("Connect Nodes")]
//     public void ConnectNodes()
//     {
//         for(int i = 0; i < nodeList.Count; i++)
//         {
//             for(int j = i+1; j < nodeList.Count;j++)
//             {
//                 if (Vector2.Distance(nodeList[i].transform.position, nodeList[j].transform.position) <= 2.0f)
//                 {
//                     nodeList[i].connections.Add(nodeList[j]);
//                     nodeList[j].connections.Add(nodeList[i]);
//                 }
//             }
//         }
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicNodeMaker : MonoBehaviour
{
    [Header("Node Settings")]
    public Node nodePrefab;
    public Vector3 nodeScale = Vector3.one;

    [Header("Grid Settings")]
    public float xStart = -12f;
    public float xEnd = 12f;
    public float yStart = -2f;
    public float yEnd = 10f;
    public float nodeSpacingX = 2f;
    public float nodeSpacingY = 2f;
    public float yOffset = -0.5f;

    [Header("Connection Settings")]
    public float connectionRadius = 2.0f;

    [Header("Generated Nodes")]
    public List<Node> nodeList = new List<Node>();

    [Header("Ground Detection")]
    public LayerMask groundLayer; // <-- Tambahkan ini agar bisa filter pakai Layer

    [ContextMenu("Create Nodes")]
    public void MakeNodes()
    {
        // Hapus node lama sebelum membuat baru
        foreach (Node oldNode in nodeList)
        {
            if (oldNode != null)
            {
                DestroyImmediate(oldNode.gameObject);
            }
        }
        nodeList.Clear();

        for (float x = xStart; x <= xEnd; x += nodeSpacingX)
        {
            for (float y = yStart; y <= yEnd; y += nodeSpacingY)
            {
                Vector2 position = new Vector2(x, y + yOffset);

                // Cek apakah ada Ground di titik ini
                Collider2D hit = Physics2D.OverlapPoint(position, groundLayer);
                if (hit != null)
                {
                    // Ada ground di sini, skip node
                    continue;
                }

                Node n = Instantiate(nodePrefab, position, Quaternion.identity, transform);
                n.transform.localScale = nodeScale;
                nodeList.Add(n);
            }
        }
    }

    [ContextMenu("Remove Empty Nodes")]
    public void RemoveNodes()
    {
        for (int i = 0; i < nodeList.Count; i++)
        {
            if (nodeList[i] == null)
            {
                nodeList.RemoveAt(i);
                i--;
            }
        }
    }

    [ContextMenu("Connect Nodes")]
    public void ConnectNodes()
    {
        foreach (Node node in nodeList)
        {
            node.connections.Clear(); // Pastikan tidak ada koneksi ganda
        }

        for (int i = 0; i < nodeList.Count; i++)
        {
            for (int j = i + 1; j < nodeList.Count; j++)
            {
                if (Vector2.Distance(nodeList[i].transform.position, nodeList[j].transform.position) <= connectionRadius)
                {
                    nodeList[i].connections.Add(nodeList[j]);
                    nodeList[j].connections.Add(nodeList[i]);
                }
            }
        }
    }
}
