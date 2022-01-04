using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Tests.Mock
{
    public class LancesMock
    {
        public static IEnumerable<object[]> ValidaValorGanhador =>
                new List<object[]>
                {
                    new object[] { 500, new Dictionary<string, double> { { "Fulano", 300 }, { "Sicrano", 400 }, { "Beltrano", 500 } } },
                    new object[] { 500, new Dictionary<string, double> { { "Fulano", 300 }, { "Sicrano", 500 }, { "Beltrano", 400 } } },
                    new object[] { 300, new Dictionary<string, double> { { "Fulano", 300 } } },
                };

        public static IEnumerable<object[]> ValidaQtdLances =>
                new List<object[]>
                {
                    new object[] { 3, new Dictionary<string, double> { { "Fulano", 300 }, { "Sicrano", 400 }, { "Beltrano", 500 } } },
                    new object[] { 2, new Dictionary<string, double> { { "Fulano", 300 }, { "Sicrano", 500 }, { "Beltrano", 400 } } },
                    new object[] { 1, new Dictionary<string, double> { { "Fulano", 300 } } },
                };
    }
}
