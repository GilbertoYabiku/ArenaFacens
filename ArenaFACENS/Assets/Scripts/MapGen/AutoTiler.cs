using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//using UnityEditor;

public class AutoTiler : MonoBehaviour {

 //   [Range(0,100)]
 //   public int iniChance;

 //   [Range(1,8)]
 //   public int birthLimit;

 //   [Range(1, 8)]
 //   public int deathLimit;

 //   [Range(1, 10)]
 //   public int numR;
 //   private int count = 0;

 //   private int[,] terrainMap;
 //   public Vector3Int tmapSize;

 //   public Tilemap topMap;
 //   public Tilemap bottonMap;
 //   public RuleTile topTile;
 //   public RuleTile bottonTile;

 //   int width, height;


 //   public void DoSim(int m_numR)
 //   {
 //       ClearMap(false);
 //       width = tmapSize.x;
 //       height = tmapSize.y;

 //       if (terrainMap == null)
 //       {
 //           terrainMap = new int[width, height];
 //           InitPos();
 //       }

 //       for (int i = 0; i < m_numR; i++)
 //       {
 //           terrainMap = GenTilePos(terrainMap);
 //       }

 //       for (int x = 0; x < width; x++)
 //       {
 //           for (int y = 0; y < height; y++)
 //           {
 //               if (terrainMap[x, y] == 1)
 //               {
 //                   topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);                   
 //               }
 //               if (terrainMap[x, y] == 0)
 //               {
 //                   bottonMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), bottonTile);
 //                   for (int h = -1; h < 2; h++)
 //                   {
 //                       int hx = x + h;
 //                       for (int v = -1; v < 2; v++)
 //                       {
 //                           int vy = y + v;
 //                           if ((hx >= 0 && vy >= 0) && (hx < width && vy < height))
 //                           {
 //                               if (terrainMap[hx, vy] == 1)
 //                               {
 //                                   bottonMap.SetTile(new Vector3Int(-hx + width / 2, -vy + height / 2, 0), bottonTile);
 //                               }
 //                           }

 //                       }
 //                   }
 //               }
 //           }
 //       }
 //   }

 //   public int [,] GenTilePos(int[,] oldMap)
 //   {
 //       int[,] newMap = new int[width, height];
 //       int neighb;
 //       BoundsInt myb = new BoundsInt(-1, -1, 0, 3, 3, 1);
 //       for (int x = 0; x < width; x++)
 //       {
 //           for (int y = 0; y < height; y++)
 //           {
 //               neighb = 0;
 //               foreach (var b in myb.allPositionsWithin)
 //               {
 //                   if (b.x == 0 && b.y == 0) continue;
 //                   if (x+b.x >= 0 && x+b.x < width && y+b.y >=0 & y+b.y < height)
 //                   {
 //                       neighb += oldMap[x + b.x, y + b.y];
 //                   }
 //                   else
 //                   {
 //                       neighb++;
 //                   }
 //               }
 //               if (oldMap[x,y] == 1)
 //               {
 //                   if (neighb < deathLimit) newMap[x, y] = 0;
 //                   else
 //                   {
 //                       newMap[x, y] = 1;
 //                   }
                    
 //               }
 //               if (oldMap[x, y] == 0)
 //               {
 //                   if (neighb > birthLimit) newMap[x, y] = 1;
 //                   else
 //                   {
 //                       newMap[x, y] = 0;
 //                   }
 //               }
 //           }
 //       }
 //       return newMap;
 //   }

 //   public void InitPos()
 //   {
 //       for (int x = 0; x < width; x++)
 //       {
 //           for (int y = 0; y < height; y++)
 //           {
 //               terrainMap[x, y] = Random.Range(1, 101) < iniChance ? 1 : 0;
 //           }
 //       }
 //   }

 //   // Update is called once per frame
 //   void Update () {
 //       if (Input.GetMouseButtonDown(0))
 //       {
 //           DoSim(numR);
 //       }

 //       if (Input.GetMouseButtonDown(1))
 //       {
 //           ClearMap(true);
 //       }

 //       if (Input.GetMouseButtonDown(2))
 //       {
 //           SaveAssetMap();
 //       }
	//}

 //   public void ClearMap (bool complete)
 //   {
 //       topMap.ClearAllTiles();
 //       bottonMap.ClearAllTiles();

 //       if (complete)
 //       {
 //           terrainMap = null;
 //       }
 //   }

 //   public void SaveAssetMap()
 //   {
 //       string saveName = "tmapXY_" + count;
 //       var mf = GameObject.Find("Grid");
 //       if (mf)
 //       {
 //           var savePath = "Assets/" + saveName + ".prefab";
 //           if (PrefabUtility.CreatePrefab(savePath,mf))
 //           {
 //               EditorUtility.DisplayDialog("Tilemap saved", "Your tilemap was saved under" + savePath, "Continue");
 //           }
 //       }
 //   }
}
