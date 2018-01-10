//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public NavigationPathComponent navigationPath { get { return (NavigationPathComponent)GetComponent(GameComponentsLookup.NavigationPath); } }
    public bool hasNavigationPath { get { return HasComponent(GameComponentsLookup.NavigationPath); } }

    public void AddNavigationPath(System.Collections.Generic.Stack<HexCellBehaviour> newPath) {
        var index = GameComponentsLookup.NavigationPath;
        var component = CreateComponent<NavigationPathComponent>(index);
        component.path = newPath;
        AddComponent(index, component);
    }

    public void ReplaceNavigationPath(System.Collections.Generic.Stack<HexCellBehaviour> newPath) {
        var index = GameComponentsLookup.NavigationPath;
        var component = CreateComponent<NavigationPathComponent>(index);
        component.path = newPath;
        ReplaceComponent(index, component);
    }

    public void RemoveNavigationPath() {
        RemoveComponent(GameComponentsLookup.NavigationPath);
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

    static Entitas.IMatcher<GameEntity> _matcherNavigationPath;

    public static Entitas.IMatcher<GameEntity> NavigationPath {
        get {
            if (_matcherNavigationPath == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NavigationPath);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNavigationPath = matcher;
            }

            return _matcherNavigationPath;
        }
    }
}
