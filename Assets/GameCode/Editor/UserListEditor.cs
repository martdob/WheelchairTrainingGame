using UnityEditor;
using UnityEngine;
using WheelchairTrainingGame.User;

[CustomEditor(typeof(UserList))]
public class UserListEditor : Editor
{
    [MenuItem("Assets/Create/WheelchairTrainingGame/User List")]
    public static UserList Create()
    {
        UserList asset = CreateInstance<UserList>();

        AssetDatabase.CreateAsset(asset, "Assets/UserList.asset");
        AssetDatabase.SaveAssets();

        return asset;
    }

    public override void OnInspectorGUI()
    {
        // Get editor target
        UserList userList = (UserList)target;

        // Show default inspector property editor
        DrawDefaultInspector();

        GUILayout.Space(20);

        GUILayout.BeginVertical();

        if (GUILayout.Button("Random"))
        {
            UserModel[] newUsers = new UserModel[] {
                new UserModel { Gender = Gender.Male, Name = "Paul" },
                new UserModel { Gender = Gender.Female, Name = "Alice" },
                new UserModel { Gender = Gender.Male, Name = "Jean" },
                new UserModel { Gender = Gender.Female, Name = "Tamara" },
                new UserModel { Gender = Gender.Male, Name = "Pierre" }
            };

            userList.Users.AddRange(newUsers);
        }

        if(GUILayout.Button("DeleteAll"))
        {
            int userCount = userList.Users.Count;
            userList.Users.Clear();

            Debug.LogFormat("Deleted {0} users from list.", userCount);
        }

        GUILayout.EndVertical();
    }
}
