﻿using System;
using UnityEngine;

public class Presets
{
    public enum EntitasPresetEnum { BARRACKS, VEHICLE, TURRET }

    private GameContext _game;
    private HexGridBehaviour _grid;

    public Presets(GameContext game, HexGridBehaviour grid)
    {
        _game = game;
        _grid = grid;
    }

    public GameEntity CreateBlueprint(EntitasInit UnityObject)
    {
        switch (UnityObject.EntitasBlueprint)
        {
            case EntitasPresetEnum.BARRACKS: return CreateBarracks(UnityObject);
            case EntitasPresetEnum.VEHICLE: return CreateVehicle(UnityObject);
            case EntitasPresetEnum.TURRET: return CreateTurret(UnityObject);
        }

        Debug.LogError("Preset code couldn't create Entity for " + UnityObject.name);
        return null;
    }

    private GameEntity CreateTurret(EntitasInit unityObject)
    {
        GameEntity ge = CreateCommon(unityObject);
        ge.isSelectable = true;
        ge.isUnit = true;
        ge.AddHealth(200);
        ge.AddWeapon(3, 90f, 2f, 2);
        ge.AddWeaponRotation(0f);

        return ge;
    }

    public GameEntity CreateVehicle(EntitasInit unityObject)
    {
        GameEntity ge = CreateCommon(unityObject);

        ge.isUnit = true;
        ge.AddNavigable(90f, .5f);
        ge.AddHealth(50);
        ge.AddWeaponRotation(0);
        ge.AddWeapon(2, 45, 2f, 1f); //turret has half turnrate of vehicle to illustrate correction

        return ge;
    }

    private GameEntity CreateBarracks(EntitasInit unityObject)
    {
        GameEntity ge = CreateCommon(unityObject);

        ge.AddHealth(500);

        return ge;
    }

    private GameEntity CreateCommon(EntitasInit unityObject)
    {
        GameEntity ge = _game.CreateEntity();
        ge.AddGameObject(unityObject.gameObject);

        Vector3 pos = unityObject.transform.position;
        Quaternion rot = unityObject.transform.rotation;
        ge.AddWorldCoordinates(pos.x, pos.y, pos.z, rot.x, rot.y, rot.z, rot.w);

        HexCellBehaviour cell = _grid.GetCell(_grid.axial_to_cube(_grid.pixel_to_axial(unityObject.transform.position)));
        if (cell != null)
        {
            int id = cell.GetComponent<EntitasLink>().id;
            ge.AddLocation(cell, id);
        }

        HexSelectable selectable = unityObject.GetComponent<HexSelectable>();
        if (selectable != null)
        {
            ge.isSelectable = true;
        }

        //now that the entity has been created with a unique ID,
        //put this ID on the unity GameObject for easy reference:
        EntitasLink el = unityObject.gameObject.AddComponent<EntitasLink>();
        el.id = ge.iD.value;

        return ge;
    }
}