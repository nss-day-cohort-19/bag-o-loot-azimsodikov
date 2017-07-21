using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class WhichChildsGettingToy
    {        
        ReviewWhoIsGettingToy _review;     
        public WhichChildsGettingToy()   
        {
            _review = new ReviewWhoIsGettingToy();
        }

        [Fact]
        public void GetChildrenWithToy()
        {
            var listOfChildren = _review.GetChildrenWithToy();
            
            Assert.IsType<Dictionary<string, int>>(listOfChildren);
        }
    }
}
