using AE.CoreUtility;
using AE.Domain;
using NuGet.Frameworks;
using System;
using System.Linq;
using Xunit;

namespace ChallengeTest.Domain
{
    public class UserTest
    {
        [Fact]
        public void SerializeTest()
        {
            var usr1 = new User("Alex");
            usr1.Permissions.GrantPermission(Permissions.Permission12);
            var bio1 = new BlobIO();
            byte[] buf = usr1.Serialize(bio1);

            var bio2 = new BlobIO(buf);
            var usr2 = UserEx.Deserialize(bio2);
            Assert.Equal(usr1.UserName, usr2.UserName);
            Assert.True(usr1.Permissions.ToByteArray().SequenceEqual(usr2.Permissions.ToByteArray()));
            Assert.Equal(usr1.CreateDate, usr2.CreateDate);
            Assert.Equal(usr1.TimeZoneName, usr2.TimeZoneName);
            Assert.Equal(usr1.Color, usr2.Color);
        }
    }
}
