//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.FeatureClassGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

public class Feature : Entitas.VisualDebugging.Unity.DebugSystems {

    public Feature(string name) : base(name) {
    }

    public Feature() : base(true) {
        var typeName = DesperateDevs.Utils.SerializationTypeExtension.ToCompilableString(GetType());
        var shortType = DesperateDevs.Utils.SerializationTypeExtension.ShortTypeName(typeName);
        var readableType = DesperateDevs.Utils.StringExtension.ToSpacedCamelCase(shortType);

        initialize(readableType);
    }
}

#else

public class Feature : Entitas.Systems {

    public Feature(string name) {
    }

    public Feature() {
    }
}

#endif