using AoC2019.Util.Intcode;

namespace TestPuzzles;

public class TestIntcodeComputer
{
    private IntcodeConfig _defaultConfig = new() { InputValue = 100, PhaseSetting = 1, Noun = 1, Verb = 1 };
    
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
    public void TestAdditionInstruction_WithParameterModes()
    {
        var program = new [] { 1001, 0, 0, 0, 99 };
        var vm = new IntcodeComputer(_defaultConfig, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(1001, output);
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
    
    [Fact]
    public void TestMultiplication_WithParameterModes()
    {
        var program = new[] { 102, 3, 0, 3, 99 };
        var vm = new IntcodeComputer(_defaultConfig, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(306, output);
    }
    
    [Fact]
    public void TestInput()
    {
        var program = new[] { 3, 0, 99 };
        var vm = new IntcodeComputer(_defaultConfig, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(_defaultConfig.InputValue, output);
    }
    
    [Fact]
    public void TestOutput()
    {
        var program = new[] { 4, 2, 99 };
        var vm = new IntcodeComputer(_defaultConfig, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(99, output);
    }
    
    [Fact]
    public void TestEqualsFalse()
    {
        const int compare = 12;
        var program = new [] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, compare };
        var vm = new IntcodeComputer(_defaultConfig, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(0, output);
    }
    
    [Fact]
    public void TestEqualsTrue()
    {
        const int compare = 12;
        var program = new [] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, compare };
        var vm = new IntcodeComputer(new IntcodeConfig{ InputValue = 12 }, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(1, output);
    }
    
    [Fact]
    public void TestEqualsFalse_ImmediateMode()
    {
        const int compare = 12;
        var program = new[] { 3, 3, 1108, -1, compare, 3, 4, 3, 99 };
        var vm = new IntcodeComputer(_defaultConfig, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(0, output);
    }
    
    [Fact]
    public void TestEqualsTrue_ImmediateMode()
    {
        const int compare = 12;
        var program = new[] { 3, 3, 1108, -1, compare, 3, 4, 3, 99 };
        var vm = new IntcodeComputer(new IntcodeConfig{ InputValue = 12 }, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(1, output);
    }
    
    [Fact]
    public void TestLessThanTrue()
    {
        const int compare = 12;
        var program = new [] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, compare };
        var vm = new IntcodeComputer(new IntcodeConfig{ InputValue = 5 }, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(1, output);
    }
    
    [Fact]
    public void TestLessThanFalse()
    {
        const int compare = 12;
        var program = new [] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, compare };
        var vm = new IntcodeComputer(new IntcodeConfig{ InputValue = 20 }, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(0, output);
    }
    
    [Fact]
    public void TestLessThanFalse2()
    {
        const int compare = 12;
        var program = new [] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, compare };
        var vm = new IntcodeComputer(new IntcodeConfig{ InputValue = 12 }, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(0, output);
    }
    
    [Fact]
    public void TestLessThanTrue_ImmediateMode()
    {
        const int compare = 12;
        var program = new[] { 3, 3, 1107, -1, compare, 3, 4, 3, 99 };
        var vm = new IntcodeComputer(new IntcodeConfig{ InputValue = 5 }, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(1, output);
    }
    
    [Fact]
    public void TestLessThanFalse_ImmediateMode()
    {
        const int compare = 12;
        var program = new[] { 3, 3, 1107, -1, compare, 3, 4, 3, 99 };
        var vm = new IntcodeComputer(new IntcodeConfig{ InputValue = 12 }, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(0, output);
    }
    
    [Fact]
    public void TestLessThanFalse2_ImmediateMode()
    {
        const int compare = 12;
        var program = new[] { 3, 3, 1107, -1, compare, 3, 4, 3, 99 };
        var vm = new IntcodeComputer(new IntcodeConfig{ InputValue = 20 }, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(0, output);
    }
    
    [Fact]
    public void TestJumpZeroInput()
    {
        var program = new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
        var vm = new IntcodeComputer(new IntcodeConfig{ InputValue = 0 }, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(0, output);
    }
    
    [Fact]
    public void TestJumpNonZeroInput()
    {
        var program = new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
        var vm = new IntcodeComputer(_defaultConfig, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(1, output);
    }
    
    [Fact]
    public void TestJumpNonZeroInput2()
    {
        var program = new[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
        var vm = new IntcodeComputer(_defaultConfig, program);
        
        vm.Run();
        var output = vm.GetOutput();
        
        Assert.Equal(1, output);
    }
}