using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ShouldRemoveToyFromChild
    {        
        SantaHelperRemove _helper;     
        public ShouldRemoveToyFromChild()   
        {
            _helper = new SantaHelperRemove();
        }
        
        [Fact]
        public void RemoveToyFromChild()
        {
            int childId = 17;
            string toyName = "basketball";
            int toyId  = _helper.RemoveToyFromChild(toyName, childId);
            List<string> toys = _helper.GetChildsToys(childId);
            Assert.IsType<List<string>>(toys);
            Assert.IsType<int>(toyId);
        }
    }
}
