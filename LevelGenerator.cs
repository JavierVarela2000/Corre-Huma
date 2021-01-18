using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator sharedInstance;
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>(); //lista para asignar los bloques de niveles
    public Transform LevelStartPoint;
    public List<LevelBlock> currentBlocks = new List<LevelBlock>();

    private void Awake()
    {
        sharedInstance = this;
    }
    private void Start()
    {
        GenerateInitialBlocks();
    }
    public void AddLevelBlock()
    {
        int randomIndex = Random.Range(0, allTheLevelBlocks.Count); //obtiene un indice aleatorio
        LevelBlock currentBlock = (LevelBlock)Instantiate(allTheLevelBlocks[randomIndex]);//paso de la carpeta assets al videojuego (instanciar)
        currentBlock.transform.SetParent(this.transform,false); // pone el nuevo bloque como hijo del LevelGenerator
        Vector3 spawnPosition = Vector3.zero;
        if (currentBlocks.Count == 0)
        {
            spawnPosition = LevelStartPoint.position;
        }
        else
        {
            spawnPosition = currentBlocks[currentBlocks.Count - 1].ExitPoint.position;
        }

        Vector3 correction = new Vector3(spawnPosition.x-currentBlock.StartPoint.position.x,spawnPosition.y-currentBlock.StartPoint.position.y,0);

        currentBlock.transform.position = correction;
        currentBlocks.Add(currentBlock);
    }
    public void RemoveOldestLevelBlock()
    {
        LevelBlock oldestBlock = currentBlocks[0];
        currentBlocks.Remove(oldestBlock);
        Destroy(oldestBlock.gameObject);
    }

    public void RemoveAllBlocks()
    {
        while (currentBlocks.Count > 0)
        {
            RemoveOldestLevelBlock();
        }
    }

    public void GenerateInitialBlocks()
    {
        for (int i=0; i<2; i++)
        {
            AddLevelBlock();
        }
    }
}
