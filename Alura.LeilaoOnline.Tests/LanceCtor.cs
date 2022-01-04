using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void RetornaArgumentExceptionCasoRecebaLanceNegativo()
        {
            // assert
            Assert.Throws<ArgumentException>(
                // act
                () => new Lance(null, -10)
            );
        }
    }
}
