using UnityEditor;
using UnityEngine;
using WheelchairTrainingGame.User;

public class UserListEditor : EditorWindow
{
    [MenuItem("Assets/Create/WheelchairTrainingGame/User List")]
    public static UserList Create()
    {
        UserList asset = ScriptableObject.CreateInstance<UserList>();

        AssetDatabase.CreateAsset(asset, "Assets/UserList.asset");
        AssetDatabase.SaveAssets();

        return asset;
    }
}
