using AoC2019.Util.Intcode.Parameters;

namespace AoC2019.Util.Intcode.Instructions.BaseInstructions;

public interface IIntcodeInstruction
{
    public Parameter Parameter1 { get; set; }
    public Parameter Parameter2 { get; set; }
    public Parameter Parameter3 { get; set; }
    
    /// <summary>
    /// Run the instruction. Computer value is stored internally. Retrieve using Value().
    /// </summary>
    public void Run();

    /// <summary>
    /// Instruction Size, which is Opcode + number of parameters used.
    /// </summary>
    /// <returns>Size</returns>
    public int Size();

    /// <summary>
    /// Returns the value of the computation performed when Run() is called.
    /// </summary>
    /// <returns>Computed value after Run()</returns>
    public int Value();
}