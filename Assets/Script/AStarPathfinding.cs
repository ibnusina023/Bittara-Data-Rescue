// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AStarPathfinding : MonoBehaviour
// {
//     Grid grid;

//     void Awake()
//     {
//         grid = GetComponent<Grid>();
//     }

//     public List<Node> FindPath(Vector3 startPos, Vector3 targetPos)
//     {
//         Node startNode = grid.NodeFromWorldPoint(startPos);
//         Node targetNode = grid.NodeFromWorldPoint(targetPos);

//         List<Node> openSet = new List<Node>();
//         HashSet<Node> closedSet = new HashSet<Node>();
//         openSet.Add(startNode);

//         if (startNode == null || targetNode == null)
//         {
//             Debug.LogError("Start node or target node is null.");
//             return null;
//         }   

//         while (openSet.Count > 0)
//         {
//             Node currentNode = openSet[0];
//             for (int i = 1; i < openSet.Count; i++)
//             {
//                 if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost)
//                 {
//                     if (openSet[i].hCost < currentNode.hCost)
//                         currentNode = openSet[i];
//                 }
//             }

//             openSet.Remove(currentNode);
//             closedSet.Add(currentNode);

//             if (currentNode == targetNode)
//             {
//                 return RetracePath(startNode, targetNode);
//             }

//             foreach (Node neighbour in grid.GetNeighbours(currentNode))
//             {
//                 if (!neighbour.walkable || closedSet.Contains(neighbour))
//                 {
//                     continue;
//                 }

//                 int newCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
//                 if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
//                 {
//                     neighbour.gCost = newCostToNeighbour;
//                     neighbour.hCost = GetDistance(neighbour, targetNode);
//                     neighbour.parent = currentNode;

//                     if (!openSet.Contains(neighbour))
//                         openSet.Add(neighbour);
//                 }
//             }
//         }

//         return null;
//     }

//     List<Node> RetracePath(Node startNode, Node endNode)
//     {
//         List<Node> path = new List<Node>();
//         Node currentNode = endNode;

//         while (currentNode != startNode)
//         {
//             path.Add(currentNode);
//             currentNode = currentNode.parent;
//         }
//         path.Reverse();
//         return path;
//     }

//     int GetDistance(Node nodeA, Node nodeB)
//     {
//         int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
//         int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

//         if (dstX > dstY)
//             return 14 * dstY + 10 * (dstX - dstY);
//         return 14 * dstX + 10 * (dstY - dstX);
//     }
// }
