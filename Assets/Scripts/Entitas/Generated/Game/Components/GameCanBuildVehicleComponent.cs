//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly CanBuildVehicle canBuildVehicleComponent = new CanBuildVehicle();

    public bool isCanBuildVehicle {
        get { return HasComponent(GameComponentsLookup.CanBuildVehicle); }
        set {
            if (value != isCanBuildVehicle) {
                var index = GameComponentsLookup.CanBuildVehicle;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : canBuildVehicleComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCanBuildVehicle;

    public static Entitas.IMatcher<GameEntity> CanBuildVehicle {
        get {
            if (_matcherCanBuildVehicle == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CanBuildVehicle);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCanBuildVehicle = matcher;
            }

            return _matcherCanBuildVehicle;
        }
    }
}
