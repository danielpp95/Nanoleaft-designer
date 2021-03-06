﻿using UnityEngine;

public class TileMap
{
    public int SizeX { get; set; }

    public int SizeY { get; set; }

    public int[,] MapData { get; set; }

    public Vector2Int Origin { get; private set; }

    public TileMap()
    {
    }

    //public TileMap(int sizeX, int sizeY, Vector2Int startPoint, Vector2Int endPoint)
    //{
    //    this.InitializeTileMap(sizeX, sizeY, startPoint, endPoint);
    //}

    public TileMap(int sizeX, int sizeY, Vector2Int origin)
    {
        this.Origin = origin;

        this.InitializeTileMap(sizeX, sizeY, origin);
    }

    private void InitializeTileMap(int sizeX, int sizeY, Vector2Int origin)
    {
        this.SizeX = sizeX;
        this.SizeY = sizeY;

        this.MapData = new int[sizeX, sizeY];

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                this.MapData[x, y] = (int)TileEnum.None;
            }
        }

        this.MapData[origin.x, origin.y] = (int)TileEnum.Connector;

        //this.MapData[startPoint.x, startPoint.y] = (int)TileEnum.Spawn;
        //this.MapData[endPoint.x, endPoint.y] = (int)TileEnum.End;
    }

    public int GetTileAt(int x, int y)
    {
        if (x >= this.SizeX ||
            y >= this.SizeY ||
            x < 0 ||
            y < 0)
        {
            return 0;
        }

        return this.MapData[x, y];

    }
}
