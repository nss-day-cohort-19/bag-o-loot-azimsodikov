
using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ShouldAssignToyToChild
    {        
        SantaHelper _helper;     
        public ShouldAssignToyToChild()   
        {
            _helper = new SantaHelper();
        }
        
        [Fact]
        public void AddToyToChildsBag()
        {
            string toyName = "Basketball";
            int childId = 715;
            int toyId = _helper.AddToyToBag(toyName, childId);
            List<int> toys = _helper.GetChildsToys(childId);
            Assert.Contains(toyId, toys);
        }
    }
}
