// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using AsmMos6502.Expressions;

namespace AsmMos6502.Tests;

[TestClass]
public class Mos6502AssemblerExpressionTests : VerifyAsmBase
{
    [TestMethod]
    public async Task TestLowHighBytes()
    {
        using var asm = CreateAsm();

        asm
            .Begin()
            .LabelForward(out var forwardLabel)
            .LDA_Imm(forwardLabel.LowByte())
            .STA(0x1000)
            .LDA_Imm(forwardLabel.HighByte())
            .STA(0x1001)
            .RTS()
            .Label(forwardLabel)
            .End();

        await VerifyAsm(asm);
    }

    [TestMethod]
    public async Task TestSubtract()
    {
        using var asm = CreateAsm();

        asm
            .Begin()
            .Label("start", out var startLabel)
            .LabelForward("end", out var endLabel)
            .LDA_Imm((endLabel - startLabel).LowByte()) // Store the size of this code
            .STA(0x1000)
            .LDA_Imm(((endLabel - startLabel) + 1).LowByte()) // Store the size of this code
            .STA(0x1001)
            .RTS()
            .Label(endLabel)
            .End();

        await VerifyAsm(asm);
    }


    [TestMethod]
    public async Task TestFunctions()
    {
        using var asm = CreateAsm();

        // Dynamic functions
        asm
            .Begin()
            .LDA_Imm((Mos6502ExpressionU8)(() => (byte)10))
            .STA(0x1000)
            .LDA((Mos6502ExpressionU16)(() => (ushort)0x1234))
            .End();

        await VerifyAsm(asm);
    }

}