﻿using Entitas;

public class RootSystem : Feature
{
    public RootSystem(Contexts contexts): base("Root System")
    {
        //make sure that every game entity created also gets an ID component:
        contexts.game.OnEntityCreated += AddId;

        Add(new InitHelloWorld(contexts));
        Add(new Systems.Input.MouseInput(contexts));
        Add(new Systems.Input.SelectionShortcuts(contexts));
        //end of unity-specific systems

        Add(new Systems.Command.UnderControlByLocalPlayers(contexts));

        Add(new Systems.Selection.ClickSelect(contexts));
        Add(new Systems.Command.UI.BuildCommands(contexts));
        Add(new Systems.Command.UI.NewUnitCommand(contexts));

        Add(new Systems.Command.Attack.UILeftClickAttack(contexts));
        Add(new Systems.Command.Attack.DefaultRightClickAttackCommand(contexts));
        Add(new Systems.Command.Attack.AimGun(contexts));
        Add(new Systems.Command.Attack.AttackExecute(contexts));

        Add(new Systems.Command.Navigation.UILeftClickNavigate(contexts));
        Add(new Systems.Command.Navigation.NavigationCommand(contexts));
        Add(new Systems.Command.Navigation.CreateNavigationPath(contexts));
        Add(new Systems.Command.Navigation.ExecuteNavigation(contexts));
        Add(new Systems.Command.Navigation.UpdateNavigationCostWithOccupiedLocations(contexts));
        Add(new Systems.Command.Navigation.Detour(contexts));

        Add(new Systems.Ai.AutoAttack(contexts));

        Add(new Systems.Logic.WeaponApplyDamage(contexts));
        Add(new Systems.Logic.RecalculateHealth(contexts));
        //Add(new Systems.Logic.StripKilledObjects(contexts));
        Add(new Systems.Logic.RemoveKilledEntities(contexts));

        //start of unity-specific systems:
        Add(new Systems.Command.ShowWeaponRange(contexts)); //debug
        Add(new Systems.View.ShowTeamColor(contexts));
        Add(new Systems.View.MoveToStartPosition(contexts));
        Add(new Systems.View.ShowEnRoute(contexts));
        Add(new Systems.View.MoveInUnity(contexts));
        Add(new Systems.View.Attack.RotateTurretInUnity(contexts)); //must come after MoveInUnity
        Add(new Systems.View.Attack.FireWeaponInUnity(contexts));
        Add(new Systems.View.ShowSelectionBox(contexts));
        Add(new Systems.View.ShowHealthBox(contexts));
        Add(new Systems.View.SelectionView(contexts));
        Add(new Systems.View.CommandView(contexts));
        Add(new Systems.View.DestroyKilledObjects(contexts));

        //Add(new Systems.View.MouseHoverDebug(contexts));
        Add(new Systems.View.LogDebugMessageSystem(contexts));

        Add(new Systems.Cleanup.MoveCleanup(contexts));

    }

    //this method gets called whenever a game entity has been created
    private void AddId(IContext context, IEntity entity)
    {
        (entity as IID).AddID(entity.creationIndex);
    }
}
