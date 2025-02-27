using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Tests
{
    public static class WorldsDumbestFunctionTests
    {
        //Naming Convention - ClassName_MethodName_ExpectedResult
        public static void WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnString()
        {
            try
            {
                //Arrange - Go get your variables, your classes, your functions, whatever you need.
                int num = 0;
                WorldsDumbestFunction worldsDumbest = new WorldsDumbestFunction();

                //Act - Execute this function
                string result = worldsDumbest.ReturnsPikachuIfZero(num);

                //Assert - Whatever is returned is what you want.
                if(result == "PIKACHU!")
                    Console.WriteLine("PASSED: WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnString");
                else
                    Console.WriteLine("FAILED: WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnString");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
