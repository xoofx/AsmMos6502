// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsmMos6502;

/// <summary>
/// Represents a single 6502 instruction, including opcode and operands.
/// </summary>
public readonly struct Mos6502Instruction : IEquatable<Mos6502Instruction>, ISpanFormattable
{
    private readonly uint _raw;

    /// <summary>
    /// Initializes a new instance of the <see cref="Mos6502Instruction"/> struct from a raw 32-bit value.
    /// </summary>
    /// <param name="raw">The raw 32-bit value encoding the instruction.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Mos6502Instruction(uint raw) => _raw = raw;

    /// <summary>
    /// Initializes a new instance of the <see cref="Mos6502Instruction"/> struct with the specified opcode.
    /// </summary>
    /// <param name="opCode">The opcode.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Mos6502Instruction(Mos6502OpCode opCode)
    {
        _raw = ((uint)opCode);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Mos6502Instruction"/> struct with the specified opcode and signed operand.
    /// </summary>
    /// <param name="opCode">The opcode.</param>
    /// <param name="lowByte">The signed operand byte.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Mos6502Instruction(Mos6502OpCode opCode, sbyte lowByte) : this(opCode, (byte)lowByte)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Mos6502Instruction"/> struct with the specified opcode and operand.
    /// </summary>
    /// <param name="opCode">The opcode.</param>
    /// <param name="lowByte">The operand byte.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Mos6502Instruction(Mos6502OpCode opCode, byte lowByte)
    {
        _raw = ((uint)opCode | ((uint)lowByte << 8));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Mos6502Instruction"/> struct with the specified opcode and 16-bit operand.
    /// </summary>
    /// <param name="opCode">The opcode.</param>
    /// <param name="value">The 16-bit operand value.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Mos6502Instruction(Mos6502OpCode opCode, ushort value)
    {
        _raw = ((uint)opCode | ((uint)value << 8));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Mos6502Instruction"/> struct with the specified opcode and two operand bytes.
    /// </summary>
    /// <param name="opCode">The opcode.</param>
    /// <param name="lowByte">The low operand byte.</param>
    /// <param name="highByte">The high operand byte.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Mos6502Instruction(Mos6502OpCode opCode, byte lowByte, byte highByte)
    {
        _raw = ((uint)opCode | ((uint)lowByte << 8) | ((uint)highByte<< 16));
    }

    /// <summary>
    /// Gets the opcode of the instruction.
    /// </summary>
    public Mos6502OpCode OpCode => (Mos6502OpCode)(byte)_raw;

    /// <summary>
    /// Gets the mnemonic for the instruction.
    /// </summary>
    public Mos6502Mnemonic Mnemonic => OpCode.ToMnemonic();

    /// <summary>
    /// Gets the addressing mode for the instruction.
    /// </summary>
    public Mos6502AddressingMode AddressingMode => OpCode.ToAddressingMode();

    /// <summary>
    /// Gets a value indicating whether the instruction is valid.
    /// </summary>
    public bool IsValid => AddressingMode != Mos6502AddressingMode.Unknown;

    /// <summary>
    /// Gets the cycle count for the instruction.
    /// </summary>
    public int CycleCount => OpCode.ToCycleCount();

    /// <summary>
    /// Gets the size in bytes of the instruction.
    /// </summary>
    public int SizeInBytes => AddressingMode.ToSizeInBytes();

    /// <summary>
    /// Gets the 16-bit operand value.
    /// </summary>
    public ushort Operand => (ushort)(_raw >> 8);

    /// <summary>
    /// Gets the low byte of the operand.
    /// </summary>
    public byte LowOperand => (byte)(_raw >> 8);

    /// <summary>
    /// Gets the high byte of the operand.
    /// </summary>
    public byte HighOperand => (byte)(_raw >> 16);

    /// <summary>
    /// Gets a read-only span representing the instruction bytes.
    /// </summary>
    [UnscopedRef]
    public ReadOnlySpan<byte> AsSpan => MemoryMarshal.CreateReadOnlySpan(ref Unsafe.As<uint, byte>(ref Unsafe.AsRef(in _raw)), SizeInBytes);

    /// <inheritdoc/>
    public bool Equals(Mos6502Instruction other) => _raw == other._raw;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Mos6502Instruction other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => (int)_raw;

    /// <summary>
    /// Decodes a buffer into a <see cref="Mos6502Instruction"/>.
    /// </summary>
    /// <param name="buffer">The buffer containing the instruction bytes.</param>
    /// <returns>The decoded instruction, or default if decoding fails.</returns>
    public static Mos6502Instruction Decode(ReadOnlySpan<byte> buffer) => TryDecode(buffer, out var instruction, out var count) ? instruction : default;

    /// <summary>
    /// Tries to decode a buffer into a <see cref="Mos6502Instruction"/>.
    /// </summary>
    /// <param name="buffer">The buffer containing the instruction bytes.</param>
    /// <param name="instruction">The decoded instruction.</param>
    /// <param name="sizeInBytes">The size in bytes of the instruction.</param>
    /// <returns><c>true</c> if decoding was successful; otherwise, <c>false</c>.</returns>
    public static bool TryDecode(ReadOnlySpan<byte> buffer, out Mos6502Instruction instruction, out int sizeInBytes)
    {
        instruction = default;
        sizeInBytes = 0;

        if (buffer.Length < 1)
            return false;
        var opCode = buffer[0];

        var addressingMode = Mos6502Tables.GetAddressingModeFromOpcode(opCode);
        if (addressingMode == Mos6502AddressingMode.Unknown)
            return false;

        sizeInBytes = Mos6502Tables.GetSizeInBytesFromAddressingMode(addressingMode);

        if (buffer.Length < sizeInBytes)
            return false;

        switch (sizeInBytes)
        {
            case 1:
                instruction = new Mos6502Instruction((Mos6502OpCode)opCode);
                break;
            case 2:
                instruction = new Mos6502Instruction((Mos6502OpCode)opCode, buffer[1]);
                break;
            default:
                instruction = new Mos6502Instruction((Mos6502OpCode)opCode, buffer[1], buffer[2]);
                break;
        }

        return true;
    }

    /// <inheritdoc/>
    public override string ToString() => ToString(null, null);

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        Span<char> destination = stackalloc char[64]; // Allocate a temporary buffer
        if (!TryFormat(destination, out var charsWritten, format, formatProvider))
        {
            var buffer = ArrayPool<char>.Shared.Rent(1024);
            destination = buffer;
            if (!TryFormat(destination, out charsWritten, format, formatProvider))
            {
                throw new InvalidOperationException("Failed to format Mos6502Instruction.");
            }
        }

        return destination.Slice(0, charsWritten).ToString();
    }

    /// <inheritdoc/>
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => TryFormat(destination, out charsWritten, format, provider, null);

    /// <summary>
    /// Tries to format the instruction as a string.
    /// </summary>
    /// <param name="destination">The destination span for the formatted string.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <param name="format">The format string.</param>
    /// <param name="provider">The format provider.</param>
    /// <param name="tryFormatDelegate">An optional delegate for custom formatting.</param>
    /// <returns><c>true</c> if formatting was successful; otherwise, <c>false</c>.</returns>
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider, Mos6502TryFormatDelegate? tryFormatDelegate)
    {
        var mnemonic = Mnemonic;
        bool lowercase = format.Length == 1 && format[0] == 'l';
        var mnemonicText = mnemonic.ToText(lowercase);
        var addressingMode = AddressingMode;
        switch (addressingMode)
        {
            case Mos6502AddressingMode.Unknown:
                return destination.TryWrite(provider, $"???", out charsWritten);
            case Mos6502AddressingMode.Absolute:
            {
                if (tryFormatDelegate != null)
                {
                    if (destination.TryWrite(provider, $"{mnemonicText} ", out var charsWrittenTemp) && tryFormatDelegate(Operand, destination.Slice(charsWrittenTemp), out var charsWrittenTryFormat))
                    {
                        charsWritten = charsWrittenTemp + charsWrittenTryFormat;
                        return true;
                    }
                }

                return destination.TryWrite(provider, $"{mnemonicText} ${Operand:X4}", out charsWritten);
            }
            case Mos6502AddressingMode.AbsoluteX:
            {
                if (tryFormatDelegate != null)
                {
                    if (destination.TryWrite(provider, $"{mnemonicText} ", out var charsWrittenTemp) && tryFormatDelegate(Operand, destination.Slice(charsWrittenTemp), out var charsWrittenTryFormat) && (lowercase
                            ? destination.Slice(charsWrittenTemp + charsWrittenTryFormat).TryWrite(provider, $",x", out var charsWrittenTempX)
                            : destination.Slice(charsWrittenTemp + charsWrittenTryFormat).TryWrite(provider, $",X", out charsWrittenTempX)))
                    {
                        charsWritten = charsWrittenTemp + charsWrittenTryFormat + charsWrittenTempX;
                        return true;
                    }
                }

                return lowercase ? destination.TryWrite(provider, $"{mnemonicText} ${Operand:X4},x", out charsWritten) : destination.TryWrite(provider, $"{mnemonicText} ${Operand:X4},X", out charsWritten);
            }
            case Mos6502AddressingMode.AbsoluteY:
            {
                if (tryFormatDelegate != null)
                {
                    if (destination.TryWrite(provider, $"{mnemonicText} ", out var charsWrittenTemp) && tryFormatDelegate(Operand, destination.Slice(charsWrittenTemp), out var charsWrittenTryFormat) && (lowercase
                            ? destination.Slice(charsWrittenTemp + charsWrittenTryFormat).TryWrite(provider, $",y", out var charsWrittenTempY)
                            : destination.Slice(charsWrittenTemp + charsWrittenTryFormat).TryWrite(provider, $",Y", out charsWrittenTempY)))
                    {
                        charsWritten = charsWrittenTemp + charsWrittenTryFormat + charsWrittenTempY;
                        return true;
                    }
                }

                return lowercase ? destination.TryWrite(provider, $"{mnemonicText} ${Operand:X4},y", out charsWritten) : destination.TryWrite(provider, $"{mnemonicText} ${Operand:X4},Y", out charsWritten);
            }
            case Mos6502AddressingMode.Accumulator:
                return lowercase ? destination.TryWrite(provider, $"{mnemonicText} a", out charsWritten) : destination.TryWrite(provider, $"{mnemonicText} A", out charsWritten);
            case Mos6502AddressingMode.Immediate:
                return destination.TryWrite(provider, $"{mnemonicText} #${LowOperand:X2}", out charsWritten);
            case Mos6502AddressingMode.Implied:
                return destination.TryWrite(provider, $"{mnemonicText}", out charsWritten);
            case Mos6502AddressingMode.Indirect:
                return destination.TryWrite(provider, $"{mnemonicText} (${Operand:X4})", out charsWritten);
            case Mos6502AddressingMode.IndirectX:
                return lowercase ? destination.TryWrite(provider, $"{mnemonicText} (${LowOperand:X2},x)", out charsWritten) : destination.TryWrite(provider, $"{mnemonicText} (${LowOperand:X2},X)", out charsWritten);
            case Mos6502AddressingMode.IndirectY:
                return lowercase ? destination.TryWrite(provider, $"{mnemonicText} (${LowOperand:X2}),y", out charsWritten) : destination.TryWrite(provider, $"{mnemonicText} (${LowOperand:X2}),Y", out charsWritten);
            case Mos6502AddressingMode.Relative:
            {
                if (tryFormatDelegate != null)
                {
                    if (destination.TryWrite(provider, $"{mnemonicText} ", out var charsWrittenTemp) && tryFormatDelegate((ushort)(short)(sbyte)LowOperand, destination.Slice(charsWrittenTemp), out var charsWrittenTryFormat))
                    {
                        charsWritten = charsWrittenTemp + charsWrittenTryFormat;
                        return true;
                    }
                }

                return destination.TryWrite(provider, $"{mnemonicText} ${(sbyte)LowOperand}", out charsWritten);
            }
            case Mos6502AddressingMode.ZeroPage:
                return destination.TryWrite(provider, $"{mnemonicText} ${LowOperand:X2}", out charsWritten);
            case Mos6502AddressingMode.ZeroPageX:
                return lowercase ? destination.TryWrite(provider, $"{mnemonicText} ${LowOperand:X2},x", out charsWritten) : destination.TryWrite(provider, $"{mnemonicText} ${LowOperand:X2},X", out charsWritten);
            case Mos6502AddressingMode.ZeroPageY:
                return lowercase ? destination.TryWrite(provider, $"{mnemonicText} ${LowOperand:X2},y", out charsWritten) : destination.TryWrite(provider, $"{mnemonicText} ${LowOperand:X2},Y", out charsWritten);
            default:
                throw new InvalidOperationException(); // Should never happen
        }
    }

    /// <summary>
    /// Determines whether two instructions are equal.
    /// </summary>
    public static bool operator ==(Mos6502Instruction left, Mos6502Instruction right) => left.Equals(right);

    /// <summary>
    /// Determines whether two instructions are not equal.
    /// </summary>
    public static bool operator !=(Mos6502Instruction left, Mos6502Instruction right) => !left.Equals(right);
}
