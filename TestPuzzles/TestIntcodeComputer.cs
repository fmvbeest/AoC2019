using AoC2019.Util.Intcode;

namespace TestPuzzles;

public class TestIntcodeComputer
{
    private IntcodeConfig _defaultConfig = new IntcodeConfig { InputValue = 1, PhaseSetting = 1, Noun = 1, Verb = 1 };
    
    [Fact]
    public void TestAdditionInstruction()
    {
        var program = new [] { 1, 0, 0, 0, 99 };
        var vm = new IntcodeComputer(_defaultConfig, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(2, output);
    }
    
    [Fact]
    public void TestMultiplication()
    {
        var program = new[] { 2, 3, 0, 3, 99 };
        var vm = new IntcodeComputer(_defaultConfig, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(6, output);
    }
}