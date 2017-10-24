using System;
using Xunit;
using dojodachi;

namespace dojodachi
{
    public class UnitTest1
    {
        [Fact]
        public void opening_page_initializes_dachi()
        {
            object tester = new Dachi(); 
            Assert.IsType<Dachi>(tester);
            
            Assert.True(tester.happiness == 20);
            Assert.True(tester.fullness == 20);
            Assert.True(tester.energy == 50);
            Assert.True(tester.meals == 3);
        }
    }
}
