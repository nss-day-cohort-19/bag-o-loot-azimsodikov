using System;
using Xunit;
namespace BagOLoot.Tests
{
    public class IsToyDeliveredToChild
    {
        CheckDelivered _checker;     
        public IsToyDeliveredToChild()   
        {
            _checker = new CheckDelivered();
        }

        [Fact]
        public void IsToyDeliveredTo()
        {
            int childId = 352;
            bool isToyDelivered = _checker.IsToyDelivered(childId);
            
            Assert.Equal(true, isToyDelivered);
        }
    }
}
