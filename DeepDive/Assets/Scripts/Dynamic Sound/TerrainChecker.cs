using UnityEngine;

public class TerrainChecker : MonoBehaviour
{
    private float[] GetTextureMix(Vector3 playerPos, Terrain t)
    {
        Vector3 tPos = t.transform.position;
        TerrainData tData = t.terrainData;

        // player x pos relative to where they are standing on the terrain
        int mapX = Mathf.RoundToInt((playerPos.x - tPos.x) / tData.size.x * tData.alphamapWidth);
        int mapZ = Mathf.RoundToInt((playerPos.z - tPos.z) / tData.size.x * tData.alphamapHeight);

        // loading all the data weights at this location so we know which texture the player is on
        // the third dimension gives the weight of the different textures
        float[,,] splatMapData = tData.GetAlphamaps(mapX, mapZ, 1, 1);

        float[] cellmix = new float[splatMapData.GetUpperBound(2) + 1];
        for (int i = 0; i < cellmix.Length; i++)
        {
            cellmix[i] = splatMapData[0, 0, i];
        }
        return cellmix;
    }

    public string GetLayerName(Vector3 playerPos, Terrain t)
    {
        float[] cellmix = GetTextureMix(playerPos, t);
        float strongest = 0;
        int maxIndex = 0;

        // looping through cellmix to find the strongest mix
        for (int i = 0; i < cellmix.Length; i++)
        {
            if (cellmix[i] > strongest)
            {
                maxIndex = i;
                strongest = cellmix[i];//we only care about the 3rd dimention
            }
        }

        return t.terrainData.terrainLayers[maxIndex].name;
    }

}
