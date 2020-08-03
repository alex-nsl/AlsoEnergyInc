using System;
using System.Drawing;

namespace AE.Domain
{
    public class User
    {
        public string UserName { get; }
        public PermissionSet Permissions { get; }
        public DateTime CreateDate { get; }
        public string TimeZoneName { get; }
        public TimeZoneInfo GetTimeZone() => TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName);
        public KnownColor Color { get; set; }

        public User(string userName, KnownColor color = KnownColor.Green) :
            this(userName, color, new PermissionSet(), DateTime.UtcNow, TimeZoneInfo.Local.StandardName)
        { }

        public User(string userName, KnownColor color, PermissionSet permissions, DateTime createDate, string timeZoneName)
        {
            UserName = userName;
            Permissions = permissions;
            CreateDate = createDate;
            TimeZoneName = timeZoneName;
            Color = color;
        }

    }
}
