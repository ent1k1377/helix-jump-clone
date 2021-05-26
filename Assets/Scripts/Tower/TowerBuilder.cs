using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class TowerBuilder : MonoBehaviour, ISceneLoadHandler<int>
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _sizeBetweenPlatforms;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;

    //private float _startAndFinishAdditionalScale = 0.6f;
    //public float BeamScaleY => _levelCount / 2f * _sizeBetweenPlatforms + _startAndFinishAdditionalScale + _additionalScale / 2;
    public float BeamScaleY => (_levelCount / 2f * _sizeBetweenPlatforms) + _additionalScale;
    

    public void OnSceneLoaded(int argument)
    {
        _levelCount = argument;
    }

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, beam.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Platform _platform = Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
        _platform.transform.parent = parent;
        spawnPosition.y -= _sizeBetweenPlatforms;
    }
}
