using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Parameters;

namespace AoC2019.Util.Intcode.Instructions.BaseInstructions;

public interface IIntcodeInstruction
{
    public Opcode Opcode { get; set; }
    
    public Parameter Parameter1 { get; set; }
    public Parameter Parameter2 { get; set; }
    public Parameter Parameter3 { get; set; }
    
    /// <summary>
    /// Run the instruction. Computer value is stored internally. Retrieve using Value().
    /// </summary>
    public void Run(long[] memory);

    /// <summary>
    /// Instruction Size, which is Opcode + number of parameters used.
    /// </summary>
    /// <returns>Size</returns>
    public int Size();

    /// <summary>
    /// Returns the value of the computation performed when Run() is called.
    /// </summary>
    /// <returns>Computed value after Run()</returns>
    public long Value();
    
    /// <summary>
    /// Returns the memory address the output should be written to
    /// </summary>
    /// <returns>Computed value after Run()</returns>
    public long OutputAddress();
}