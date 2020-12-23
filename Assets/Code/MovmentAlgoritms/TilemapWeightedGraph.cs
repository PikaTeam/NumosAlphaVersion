/*//using Assets.Scripts._1_tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts._0_bfs
{
    class TilemapWeightedGraph: IWeightedGraph<Vector3Int>
    {
        private Tilemap tilemap;
        private WeightedAllowedTiles allowedTiles;

        public TilemapWeightedGraph(Tilemap tilemap, WeightedAllowedTiles allowedTiles)
        {
            this.tilemap = tilemap;
            this.allowedTiles = allowedTiles;
        }

        static Vector3Int[] directions = {
            new Vector3Int(-1, 0, 0),
            new Vector3Int(1, 0, 0),
            new Vector3Int(0, -1, 0),
            new Vector3Int(0, 1, 0),
        };

        public IEnumerable<KeyValuePair<Vector3Int, float>> Neighbors(Vector3Int node)
        {
            foreach (var direction in directions)
            {
                Vector3Int neighborPos = node + direction;
                TileBase neighborTile = tilemap.GetTile(neighborPos);
                if (allowedTiles.Contains(neighborTile))
                    yield return new KeyValuePair<Vector3Int, float>(neighborPos, allowedTiles.GetWeightOf(neighborTile));
            }
        }
    }
}*/
