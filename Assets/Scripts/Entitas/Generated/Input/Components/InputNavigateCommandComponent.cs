//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public NavigateCommandComponent navigateCommand { get { return (NavigateCommandComponent)GetComponent(InputComponentsLookup.NavigateCommand); } }
    public bool hasNavigateCommand { get { return HasComponent(InputComponentsLookup.NavigateCommand); } }

    public void AddNavigateCommand(HexGridBehaviour newDestination) {
        var index = InputComponentsLookup.NavigateCommand;
        var component = CreateComponent<NavigateCommandComponent>(index);
        component.destination = newDestination;
        AddComponent(index, component);
    }

    public void ReplaceNavigateCommand(HexGridBehaviour newDestination) {
        var index = InputComponentsLookup.NavigateCommand;
        var component = CreateComponent<NavigateCommandComponent>(index);
        component.destination = newDestination;
        ReplaceComponent(index, component);
    }

    public void RemoveNavigateCommand() {
        RemoveComponent(InputComponentsLookup.NavigateCommand);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherNavigateCommand;

    public static Entitas.IMatcher<InputEntity> NavigateCommand {
        get {
            if (_matcherNavigateCommand == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.NavigateCommand);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherNavigateCommand = matcher;
            }

            return _matcherNavigateCommand;
        }
    }
}
