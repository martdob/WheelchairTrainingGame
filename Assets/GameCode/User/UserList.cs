using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WheelchairTrainingGame.User
{
    public class UserList : ScriptableObject
    {
        public List<UserModel> Users = new List<UserModel>();
    }
}