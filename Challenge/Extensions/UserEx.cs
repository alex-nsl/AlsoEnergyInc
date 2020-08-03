using AE.Domain;
using System.Drawing;

namespace AE.CoreUtility
{
    public static class UserEx
    {
        public static byte[] Serialize(this User user, BlobIO bio)
        {
            bio += user.UserName;
            bio += (byte[])user.Permissions;
            bio += user.CreateDate;
            bio += user.TimeZoneName;
            bio += (int)user.Color;
            return bio.IO;
        }

        public static User Deserialize(BlobIO bio)
        {
            return new User(bio.GetString(0), (KnownColor)bio.GetInt32(4), bio.GetPermissionSet(1), bio.GetDateTime(2).Value, bio.GetString(3));
        }
    }
}
