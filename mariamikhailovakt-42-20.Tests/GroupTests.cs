using mariamikhailovakt_42_20.Models;
namespace mariamikhailovakt_42_20.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_True()
        {
            var GroupName = new Group
            {
                GroupName = "สา-42-20"
            };

            var result = GroupName.IsValidGroupName();

            Assert.False(result);

        }
    }
}