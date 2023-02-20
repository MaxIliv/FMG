using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance;

    [SerializeField] public List<Tile> tilesList = new List<Tile>();
    [SerializeField] public Tile activeTile;
    [SerializeField] public Tile ActiveTile { get { return activeTile; } }
    [SerializeField] public int currentTileIndex = 0;

    [SerializeField]
    public StageController ActiveStage { get { return ActiveTile.StageController; } }
    [SerializeField]
    public Waypoint ActiveWaypoint { get { return ActiveTile.Waypoint; } }

    [System.Serializable]
    public class TileOptions
    {
        public string Tile;
        public float SpeedModificator;
    }

    public List<TileOptions> Tiles;

    [SerializeField]
    private Dictionary<string, TileOptions> _tileOptions = new Dictionary<string, TileOptions>();

    private TileOptions _defaultOptions = new TileOptions()
    {
        SpeedModificator = 1,
    };


    public void Awake()
    {
        Instance = this;
        CollectTiles();
        UpdateTile();

        foreach (var tile in Tiles)
        {
            _tileOptions.Add(tile.Tile, tile);
        }
    }

    void OnEnable()
    {
        EventManager.OnNextTile += NextTile;
    }

    void OnDisable()
    {
        EventManager.OnNextTile -= NextTile;
    }

    public TileOptions GetTileOptions(string name)
    {
        if (_tileOptions.TryGetValue(name, out TileOptions tile))
        {
            return tile;
        }
        return _defaultOptions;
    }

    public void CollectTiles()
    {
        GameObject tileParent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in tileParent.transform)
        {
            Tile tile = child.GetComponent<Tile>();

            if (tile != null)
            {
                tilesList.Add(tile);
            }
        }
    }

    public void UpdateTile()
    {
        activeTile = tilesList[currentTileIndex];
    }

    public void NextTile()
    {
        currentTileIndex++;

        if (currentTileIndex == tilesList.Count) {
            currentTileIndex = 0;
        }

        UpdateTile();
    }
}


