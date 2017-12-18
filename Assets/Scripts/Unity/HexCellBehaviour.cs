﻿using UnityEngine;
using General;

[SelectionBase]
public class HexCellBehaviour : MonoBehaviour {

    [SerializeField, EnumFlag("Passable")]
    public HexPassable _hexPassable;

    [SerializeField]
    public Vector3 cubeCoordinates;

#pragma warning disable 0649
    [SerializeField]
    private Material _highLight;
    private Material _standard;

#pragma warning disable 0649
    [SerializeField]
    private Renderer _model;
#pragma warning disable 0649
    [SerializeField]
    private Renderer _N, _S, _NE, _SE, _NW, _SW;

    private void Awake()
    {
        //safeguard default material, for when we want to overwrite it with a highlight:
        _standard = _model.material;
    }

    private void OnValidate()
    {
        _N.gameObject.SetActive(CanGo(HexPassable.N));
        _NE.gameObject.SetActive(CanGo(HexPassable.NE));
        _NW.gameObject.SetActive(CanGo(HexPassable.NW));
        _S.gameObject.SetActive(CanGo(HexPassable.S));
        _SW.gameObject.SetActive(CanGo(HexPassable.SW));
        _SE.gameObject.SetActive(CanGo(HexPassable.SE));
    }
    public bool CanGo(HexPassable dir)
    {
        return (dir & _hexPassable) == dir;
    }
    public void AllowGo(HexPassable dir)
    {
        _hexPassable |= dir;
    }

    public void BlockGo(HexPassable dir) {
        _hexPassable &= ~dir;
    }

    public void SetHighLight(bool hi)
    {
        _model.material = hi ? _highLight : _standard;
    }
}
