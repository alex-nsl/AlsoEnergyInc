using System;
using System.Collections;

namespace AE.Domain
{
    /// <summary>
    /// Set of permissions. For that example I choose implementation based on BitVector storage.
    /// In real life depends on business area implementation based on HashSet should be considered as possible alternative.
    /// Points to consider: how many permissions could have average user, how many new permissions can be added, etc.
    /// This class is not thread-safe.
    /// </summary>
    public class PermissionSet
    {
        private BitArray permissions;

        public PermissionSet() => permissions = new BitArray(Enum.GetNames(typeof(Permissions)).Length);

        public PermissionSet(byte[] source) : this() // to cover the case when source has different number of elements
        {
            var src = new BitArray(source);
            int cnt = Math.Min(permissions.Count, src.Count);
            for (int i = 0; i < cnt; i++)
                permissions[i] = src[i];
        }

        public void GrantPermission(Permissions perm) => permissions.Set((int)perm, true);
        public void RevokePermission(Permissions perm) => permissions.Set((int)perm, false);
        public bool HasPermission(Permissions perm) => permissions.Get((int)perm);

        public byte[] ToByteArray()
        {
            byte[] res = new byte[(permissions.Length + 7) >> 3]; // how many bytes are needed to represent permissions BitArray
            permissions.CopyTo(res, 0);
            return res;
        }

        public static explicit operator byte[] (PermissionSet x) => x.ToByteArray();
    }
}
