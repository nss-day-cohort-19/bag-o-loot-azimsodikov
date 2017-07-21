using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ShouldReviewChildsToyList
    {        
        ReviewChildsToyList _review;     
        public ShouldReviewChildsToyList()   
        {
            _review = new ReviewChildsToyList();
        }

        [Fact]
        public void GetChildsToyList()
        {
            var result = _review.GetChildsToyList();
            
            Assert.IsType<Dictionary<string, int>>(result);
        }
    }
}
