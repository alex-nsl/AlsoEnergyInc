using AE.Domain;
using System;
using Xunit;

namespace ChallengeTest.Domain
{
    public class PermissionSetTest
    {
        [Fact]
        public void PermissionSetConstructTest()
        {
            var ps1 = new PermissionSet();
            ps1.GrantPermission(Permissions.Permission1);
            ps1.GrantPermission(Permissions.Permission12);
            ps1.GrantPermission(Permissions.Permission100);
            var ps2 = new PermissionSet((byte[])ps1);
            for (int i = 0; i < Enum.GetNames(typeof(Permissions)).Length; i++)
            {
                Assert.Equal((i == 0 || i == 11 || i == 99), ps2.HasPermission((Permissions)i));
            }
        }

        [Fact]
        public void PermissionSetGrantRevokeTest()
        {
            var ps = new PermissionSet();
            ps.GrantPermission(Permissions.Permission1);
            ps.GrantPermission(Permissions.Permission12);
            ps.GrantPermission(Permissions.Permission100);
            for (int i = 0; i < Enum.GetNames(typeof(Permissions)).Length; i++)
            {
                Assert.Equal((i == 0 || i == 11 || i == 99), ps.HasPermission((Permissions)i));
            }
            ps.RevokePermission(Permissions.Permission1);
            ps.RevokePermission(Permissions.Permission100);
            for (int i = 0; i < Enum.GetNames(typeof(Permissions)).Length; i++)
            {
                Assert.Equal(i == 11, ps.HasPermission((Permissions)i));
            }
        }
    }
}
