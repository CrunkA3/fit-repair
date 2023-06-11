using FitRepair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair;


/// <summary>
/// Filed numbers for <see cref="FileCreatorMessageFieldNumber" />
/// </summary>
public sealed class FileCreatorMessageFieldNumber : FieldNumberDefinitions<byte>
{
    public static readonly FileCreatorMessageFieldNumber SoftwareVersion = new(0);
    public static readonly FileCreatorMessageFieldNumber HardwareVersion = new(1);

    private FileCreatorMessageFieldNumber(byte value) : base(value) { }

}


public sealed class FileCreatorMessage : DataMessage
{
    internal FileCreatorMessage(int localMessageType) : base(localMessageType)
    {
    }

    public ushort? GetSoftwareVersion() => GetValueOrDefaultUshort(FileCreatorMessageFieldNumber.SoftwareVersion);
    public byte? GetHardwareVersion() => GetValueOrDefaultByte(FileCreatorMessageFieldNumber.HardwareVersion);
}

