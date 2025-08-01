// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.
// ------------------------------------------------------------------------------
// This code was generated by AsmMos6502.CodeGen.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// ------------------------------------------------------------------------------
// ReSharper disable All
// ------------------------------------------------------------------------------
namespace AsmMos6502;

/// <summary>
/// Internal tables to help decoding <see cref="Mos6502OpCode"/>.
/// </summary>
internal static partial class Mos6502Tables
{
    private static ReadOnlySpan<byte> MapOpCodeToAddressingMode => new byte[256]
    {
        0x06, 0x08, 0x00, 0x00, 0x00, 0x0B, 0x0B, 0x00, 0x06, 0x05, 0x04, 0x00, 0x00, 0x01, 0x01, 0x00, 
        0x0A, 0x09, 0x00, 0x00, 0x00, 0x0C, 0x0C, 0x00, 0x06, 0x03, 0x00, 0x00, 0x00, 0x02, 0x02, 0x00, 
        0x01, 0x08, 0x00, 0x00, 0x0B, 0x0B, 0x0B, 0x00, 0x06, 0x05, 0x04, 0x00, 0x01, 0x01, 0x01, 0x00, 
        0x0A, 0x09, 0x00, 0x00, 0x00, 0x0C, 0x0C, 0x00, 0x06, 0x03, 0x00, 0x00, 0x00, 0x02, 0x02, 0x00, 
        0x06, 0x08, 0x00, 0x00, 0x00, 0x0B, 0x0B, 0x00, 0x06, 0x05, 0x04, 0x00, 0x01, 0x01, 0x01, 0x00, 
        0x0A, 0x09, 0x00, 0x00, 0x00, 0x0C, 0x0C, 0x00, 0x06, 0x03, 0x00, 0x00, 0x00, 0x02, 0x02, 0x00, 
        0x06, 0x08, 0x00, 0x00, 0x00, 0x0B, 0x0B, 0x00, 0x06, 0x05, 0x04, 0x00, 0x07, 0x01, 0x01, 0x00, 
        0x0A, 0x09, 0x00, 0x00, 0x00, 0x0C, 0x0C, 0x00, 0x06, 0x03, 0x00, 0x00, 0x00, 0x02, 0x02, 0x00, 
        0x00, 0x08, 0x00, 0x00, 0x0B, 0x0B, 0x0B, 0x00, 0x06, 0x00, 0x06, 0x00, 0x01, 0x01, 0x01, 0x00, 
        0x0A, 0x09, 0x00, 0x00, 0x0C, 0x0C, 0x0D, 0x00, 0x06, 0x03, 0x06, 0x00, 0x00, 0x02, 0x00, 0x00, 
        0x05, 0x08, 0x05, 0x00, 0x0B, 0x0B, 0x0B, 0x00, 0x06, 0x05, 0x06, 0x00, 0x01, 0x01, 0x01, 0x00, 
        0x0A, 0x09, 0x00, 0x00, 0x0C, 0x0C, 0x0D, 0x00, 0x06, 0x03, 0x06, 0x00, 0x02, 0x02, 0x03, 0x00, 
        0x05, 0x08, 0x00, 0x00, 0x0B, 0x0B, 0x0B, 0x00, 0x06, 0x05, 0x06, 0x00, 0x01, 0x01, 0x01, 0x00, 
        0x0A, 0x09, 0x00, 0x00, 0x00, 0x0C, 0x0C, 0x00, 0x06, 0x03, 0x00, 0x00, 0x00, 0x02, 0x02, 0x00, 
        0x05, 0x08, 0x00, 0x00, 0x0B, 0x0B, 0x0B, 0x00, 0x06, 0x05, 0x06, 0x00, 0x01, 0x01, 0x01, 0x00, 
        0x0A, 0x09, 0x00, 0x00, 0x00, 0x0C, 0x0C, 0x00, 0x06, 0x03, 0x00, 0x00, 0x00, 0x02, 0x02, 0x00, 
    };
    
    private static ReadOnlySpan<byte> MapOpCodeToMnemonic => new byte[256]
    {
        11, // [0x00] BRK_Implied 
        35, // [0x01] ORA_IndirectX 
        0 , // [0x02] No opcodes for this instruction
        0 , // [0x03] No opcodes for this instruction
        0 , // [0x04] No opcodes for this instruction
        35, // [0x05] ORA_ZeroPage 
        3 , // [0x06] ASL_ZeroPage 
        0 , // [0x07] No opcodes for this instruction
        37, // [0x08] PHP_Implied 
        35, // [0x09] ORA_Immediate 
        3 , // [0x0A] ASL_Accumulator 
        0 , // [0x0B] No opcodes for this instruction
        0 , // [0x0C] No opcodes for this instruction
        35, // [0x0D] ORA_Absolute 
        3 , // [0x0E] ASL_Absolute 
        0 , // [0x0F] No opcodes for this instruction
        10, // [0x10] BPL_Relative 
        35, // [0x11] ORA_IndirectY 
        0 , // [0x12] No opcodes for this instruction
        0 , // [0x13] No opcodes for this instruction
        0 , // [0x14] No opcodes for this instruction
        35, // [0x15] ORA_ZeroPageX 
        3 , // [0x16] ASL_ZeroPageX 
        0 , // [0x17] No opcodes for this instruction
        14, // [0x18] CLC_Implied 
        35, // [0x19] ORA_AbsoluteY 
        0 , // [0x1A] No opcodes for this instruction
        0 , // [0x1B] No opcodes for this instruction
        0 , // [0x1C] No opcodes for this instruction
        35, // [0x1D] ORA_AbsoluteX 
        3 , // [0x1E] ASL_AbsoluteX 
        0 , // [0x1F] No opcodes for this instruction
        29, // [0x20] JSR_Absolute 
        2 , // [0x21] AND_IndirectX 
        0 , // [0x22] No opcodes for this instruction
        0 , // [0x23] No opcodes for this instruction
        7 , // [0x24] BIT_ZeroPage 
        2 , // [0x25] AND_ZeroPage 
        40, // [0x26] ROL_ZeroPage 
        0 , // [0x27] No opcodes for this instruction
        39, // [0x28] PLP_Implied 
        2 , // [0x29] AND_Immediate 
        40, // [0x2A] ROL_Accumulator 
        0 , // [0x2B] No opcodes for this instruction
        7 , // [0x2C] BIT_Absolute 
        2 , // [0x2D] AND_Absolute 
        40, // [0x2E] ROL_Absolute 
        0 , // [0x2F] No opcodes for this instruction
        8 , // [0x30] BMI_Relative 
        2 , // [0x31] AND_IndirectY 
        0 , // [0x32] No opcodes for this instruction
        0 , // [0x33] No opcodes for this instruction
        0 , // [0x34] No opcodes for this instruction
        2 , // [0x35] AND_ZeroPageX 
        40, // [0x36] ROL_ZeroPageX 
        0 , // [0x37] No opcodes for this instruction
        45, // [0x38] SEC_Implied 
        2 , // [0x39] AND_AbsoluteY 
        0 , // [0x3A] No opcodes for this instruction
        0 , // [0x3B] No opcodes for this instruction
        0 , // [0x3C] No opcodes for this instruction
        2 , // [0x3D] AND_AbsoluteX 
        40, // [0x3E] ROL_AbsoluteX 
        0 , // [0x3F] No opcodes for this instruction
        42, // [0x40] RTI_Implied 
        24, // [0x41] EOR_IndirectX 
        0 , // [0x42] No opcodes for this instruction
        0 , // [0x43] No opcodes for this instruction
        0 , // [0x44] No opcodes for this instruction
        24, // [0x45] EOR_ZeroPage 
        33, // [0x46] LSR_ZeroPage 
        0 , // [0x47] No opcodes for this instruction
        36, // [0x48] PHA_Implied 
        24, // [0x49] EOR_Immediate 
        33, // [0x4A] LSR_Accumulator 
        0 , // [0x4B] No opcodes for this instruction
        28, // [0x4C] JMP_Absolute 
        24, // [0x4D] EOR_Absolute 
        33, // [0x4E] LSR_Absolute 
        0 , // [0x4F] No opcodes for this instruction
        12, // [0x50] BVC_Relative 
        24, // [0x51] EOR_IndirectY 
        0 , // [0x52] No opcodes for this instruction
        0 , // [0x53] No opcodes for this instruction
        0 , // [0x54] No opcodes for this instruction
        24, // [0x55] EOR_ZeroPageX 
        33, // [0x56] LSR_ZeroPageX 
        0 , // [0x57] No opcodes for this instruction
        16, // [0x58] CLI_Implied 
        24, // [0x59] EOR_AbsoluteY 
        0 , // [0x5A] No opcodes for this instruction
        0 , // [0x5B] No opcodes for this instruction
        0 , // [0x5C] No opcodes for this instruction
        24, // [0x5D] EOR_AbsoluteX 
        33, // [0x5E] LSR_AbsoluteX 
        0 , // [0x5F] No opcodes for this instruction
        43, // [0x60] RTS_Implied 
        1 , // [0x61] ADC_IndirectX 
        0 , // [0x62] No opcodes for this instruction
        0 , // [0x63] No opcodes for this instruction
        0 , // [0x64] No opcodes for this instruction
        1 , // [0x65] ADC_ZeroPage 
        41, // [0x66] ROR_ZeroPage 
        0 , // [0x67] No opcodes for this instruction
        38, // [0x68] PLA_Implied 
        1 , // [0x69] ADC_Immediate 
        41, // [0x6A] ROR_Accumulator 
        0 , // [0x6B] No opcodes for this instruction
        28, // [0x6C] JMP_Indirect 
        1 , // [0x6D] ADC_Absolute 
        41, // [0x6E] ROR_Absolute 
        0 , // [0x6F] No opcodes for this instruction
        13, // [0x70] BVS_Relative 
        1 , // [0x71] ADC_IndirectY 
        0 , // [0x72] No opcodes for this instruction
        0 , // [0x73] No opcodes for this instruction
        0 , // [0x74] No opcodes for this instruction
        1 , // [0x75] ADC_ZeroPageX 
        41, // [0x76] ROR_ZeroPageX 
        0 , // [0x77] No opcodes for this instruction
        47, // [0x78] SEI_Implied 
        1 , // [0x79] ADC_AbsoluteY 
        0 , // [0x7A] No opcodes for this instruction
        0 , // [0x7B] No opcodes for this instruction
        0 , // [0x7C] No opcodes for this instruction
        1 , // [0x7D] ADC_AbsoluteX 
        41, // [0x7E] ROR_AbsoluteX 
        0 , // [0x7F] No opcodes for this instruction
        0 , // [0x80] No opcodes for this instruction
        48, // [0x81] STA_IndirectX 
        0 , // [0x82] No opcodes for this instruction
        0 , // [0x83] No opcodes for this instruction
        50, // [0x84] STY_ZeroPage 
        48, // [0x85] STA_ZeroPage 
        49, // [0x86] STX_ZeroPage 
        0 , // [0x87] No opcodes for this instruction
        23, // [0x88] DEY_Implied 
        0 , // [0x89] No opcodes for this instruction
        54, // [0x8A] TXA_Implied 
        0 , // [0x8B] No opcodes for this instruction
        50, // [0x8C] STY_Absolute 
        48, // [0x8D] STA_Absolute 
        49, // [0x8E] STX_Absolute 
        0 , // [0x8F] No opcodes for this instruction
        4 , // [0x90] BCC_Relative 
        48, // [0x91] STA_IndirectY 
        0 , // [0x92] No opcodes for this instruction
        0 , // [0x93] No opcodes for this instruction
        50, // [0x94] STY_ZeroPageX 
        48, // [0x95] STA_ZeroPageX 
        49, // [0x96] STX_ZeroPageY 
        0 , // [0x97] No opcodes for this instruction
        56, // [0x98] TYA_Implied 
        48, // [0x99] STA_AbsoluteY 
        55, // [0x9A] TXS_Implied 
        0 , // [0x9B] No opcodes for this instruction
        0 , // [0x9C] No opcodes for this instruction
        48, // [0x9D] STA_AbsoluteX 
        0 , // [0x9E] No opcodes for this instruction
        0 , // [0x9F] No opcodes for this instruction
        32, // [0xA0] LDY_Immediate 
        30, // [0xA1] LDA_IndirectX 
        31, // [0xA2] LDX_Immediate 
        0 , // [0xA3] No opcodes for this instruction
        32, // [0xA4] LDY_ZeroPage 
        30, // [0xA5] LDA_ZeroPage 
        31, // [0xA6] LDX_ZeroPage 
        0 , // [0xA7] No opcodes for this instruction
        52, // [0xA8] TAY_Implied 
        30, // [0xA9] LDA_Immediate 
        51, // [0xAA] TAX_Implied 
        0 , // [0xAB] No opcodes for this instruction
        32, // [0xAC] LDY_Absolute 
        30, // [0xAD] LDA_Absolute 
        31, // [0xAE] LDX_Absolute 
        0 , // [0xAF] No opcodes for this instruction
        5 , // [0xB0] BCS_Relative 
        30, // [0xB1] LDA_IndirectY 
        0 , // [0xB2] No opcodes for this instruction
        0 , // [0xB3] No opcodes for this instruction
        32, // [0xB4] LDY_ZeroPageX 
        30, // [0xB5] LDA_ZeroPageX 
        31, // [0xB6] LDX_ZeroPageY 
        0 , // [0xB7] No opcodes for this instruction
        17, // [0xB8] CLV_Implied 
        30, // [0xB9] LDA_AbsoluteY 
        53, // [0xBA] TSX_Implied 
        0 , // [0xBB] No opcodes for this instruction
        32, // [0xBC] LDY_AbsoluteX 
        30, // [0xBD] LDA_AbsoluteX 
        31, // [0xBE] LDX_AbsoluteY 
        0 , // [0xBF] No opcodes for this instruction
        20, // [0xC0] CPY_Immediate 
        18, // [0xC1] CMP_IndirectX 
        0 , // [0xC2] No opcodes for this instruction
        0 , // [0xC3] No opcodes for this instruction
        20, // [0xC4] CPY_ZeroPage 
        18, // [0xC5] CMP_ZeroPage 
        21, // [0xC6] DEC_ZeroPage 
        0 , // [0xC7] No opcodes for this instruction
        27, // [0xC8] INY_Implied 
        18, // [0xC9] CMP_Immediate 
        22, // [0xCA] DEX_Implied 
        0 , // [0xCB] No opcodes for this instruction
        20, // [0xCC] CPY_Absolute 
        18, // [0xCD] CMP_Absolute 
        21, // [0xCE] DEC_Absolute 
        0 , // [0xCF] No opcodes for this instruction
        9 , // [0xD0] BNE_Relative 
        18, // [0xD1] CMP_IndirectY 
        0 , // [0xD2] No opcodes for this instruction
        0 , // [0xD3] No opcodes for this instruction
        0 , // [0xD4] No opcodes for this instruction
        18, // [0xD5] CMP_ZeroPageX 
        21, // [0xD6] DEC_ZeroPageX 
        0 , // [0xD7] No opcodes for this instruction
        15, // [0xD8] CLD_Implied 
        18, // [0xD9] CMP_AbsoluteY 
        0 , // [0xDA] No opcodes for this instruction
        0 , // [0xDB] No opcodes for this instruction
        0 , // [0xDC] No opcodes for this instruction
        18, // [0xDD] CMP_AbsoluteX 
        21, // [0xDE] DEC_AbsoluteX 
        0 , // [0xDF] No opcodes for this instruction
        19, // [0xE0] CPX_Immediate 
        44, // [0xE1] SBC_IndirectX 
        0 , // [0xE2] No opcodes for this instruction
        0 , // [0xE3] No opcodes for this instruction
        19, // [0xE4] CPX_ZeroPage 
        44, // [0xE5] SBC_ZeroPage 
        25, // [0xE6] INC_ZeroPage 
        0 , // [0xE7] No opcodes for this instruction
        26, // [0xE8] INX_Implied 
        44, // [0xE9] SBC_Immediate 
        34, // [0xEA] NOP_Implied 
        0 , // [0xEB] No opcodes for this instruction
        19, // [0xEC] CPX_Absolute 
        44, // [0xED] SBC_Absolute 
        25, // [0xEE] INC_Absolute 
        0 , // [0xEF] No opcodes for this instruction
        6 , // [0xF0] BEQ_Relative 
        44, // [0xF1] SBC_IndirectY 
        0 , // [0xF2] No opcodes for this instruction
        0 , // [0xF3] No opcodes for this instruction
        0 , // [0xF4] No opcodes for this instruction
        44, // [0xF5] SBC_ZeroPageX 
        25, // [0xF6] INC_ZeroPageX 
        0 , // [0xF7] No opcodes for this instruction
        46, // [0xF8] SED_Implied 
        44, // [0xF9] SBC_AbsoluteY 
        0 , // [0xFA] No opcodes for this instruction
        0 , // [0xFB] No opcodes for this instruction
        0 , // [0xFC] No opcodes for this instruction
        44, // [0xFD] SBC_AbsoluteX 
        25, // [0xFE] INC_AbsoluteX 
        0 , // [0xFF] No opcodes for this instruction
    };
    
    private static readonly string[] MapMnemonicToTextUppercase = new string[57]
    {
        "???", // Unknown mnemonic
        "ADC", // ADC
        "AND", // AND
        "ASL", // ASL
        "BCC", // BCC
        "BCS", // BCS
        "BEQ", // BEQ
        "BIT", // BIT
        "BMI", // BMI
        "BNE", // BNE
        "BPL", // BPL
        "BRK", // BRK
        "BVC", // BVC
        "BVS", // BVS
        "CLC", // CLC
        "CLD", // CLD
        "CLI", // CLI
        "CLV", // CLV
        "CMP", // CMP
        "CPX", // CPX
        "CPY", // CPY
        "DEC", // DEC
        "DEX", // DEX
        "DEY", // DEY
        "EOR", // EOR
        "INC", // INC
        "INX", // INX
        "INY", // INY
        "JMP", // JMP
        "JSR", // JSR
        "LDA", // LDA
        "LDX", // LDX
        "LDY", // LDY
        "LSR", // LSR
        "NOP", // NOP
        "ORA", // ORA
        "PHA", // PHA
        "PHP", // PHP
        "PLA", // PLA
        "PLP", // PLP
        "ROL", // ROL
        "ROR", // ROR
        "RTI", // RTI
        "RTS", // RTS
        "SBC", // SBC
        "SEC", // SEC
        "SED", // SED
        "SEI", // SEI
        "STA", // STA
        "STX", // STX
        "STY", // STY
        "TAX", // TAX
        "TAY", // TAY
        "TSX", // TSX
        "TXA", // TXA
        "TXS", // TXS
        "TYA", // TYA
    };
    
    private static readonly string[] MapMnemonicToTextLowercase = new string[57]
    {
        "???", // Unknown mnemonic
        "adc", // ADC
        "and", // AND
        "asl", // ASL
        "bcc", // BCC
        "bcs", // BCS
        "beq", // BEQ
        "bit", // BIT
        "bmi", // BMI
        "bne", // BNE
        "bpl", // BPL
        "brk", // BRK
        "bvc", // BVC
        "bvs", // BVS
        "clc", // CLC
        "cld", // CLD
        "cli", // CLI
        "clv", // CLV
        "cmp", // CMP
        "cpx", // CPX
        "cpy", // CPY
        "dec", // DEC
        "dex", // DEX
        "dey", // DEY
        "eor", // EOR
        "inc", // INC
        "inx", // INX
        "iny", // INY
        "jmp", // JMP
        "jsr", // JSR
        "lda", // LDA
        "ldx", // LDX
        "ldy", // LDY
        "lsr", // LSR
        "nop", // NOP
        "ora", // ORA
        "pha", // PHA
        "php", // PHP
        "pla", // PLA
        "plp", // PLP
        "rol", // ROL
        "ror", // ROR
        "rti", // RTI
        "rts", // RTS
        "sbc", // SBC
        "sec", // SEC
        "sed", // SED
        "sei", // SEI
        "sta", // STA
        "stx", // STX
        "sty", // STY
        "tax", // TAX
        "tay", // TAY
        "tsx", // TSX
        "txa", // TXA
        "txs", // TXS
        "tya", // TYA
    };
    
    private static ReadOnlySpan<byte> MapOpCodeToCycles => new byte[256]
    {
        7, 6, 0, 0, 0, 3, 5, 0, 3, 2, 2, 0, 0, 4, 6, 0, 
        2, 5, 0, 0, 0, 4, 6, 0, 2, 4, 0, 0, 0, 4, 7, 0, 
        6, 6, 0, 0, 3, 3, 5, 0, 4, 2, 2, 0, 4, 4, 6, 0, 
        2, 5, 0, 0, 0, 4, 6, 0, 2, 4, 0, 0, 0, 4, 7, 0, 
        6, 6, 0, 0, 0, 3, 5, 0, 3, 2, 2, 0, 3, 4, 6, 0, 
        2, 5, 0, 0, 0, 4, 6, 0, 2, 4, 0, 0, 0, 4, 7, 0, 
        6, 6, 0, 0, 0, 3, 5, 0, 4, 2, 2, 0, 5, 4, 6, 0, 
        2, 5, 0, 0, 0, 4, 6, 0, 2, 4, 0, 0, 0, 4, 7, 0, 
        0, 6, 0, 0, 3, 3, 3, 0, 2, 0, 2, 0, 4, 4, 4, 0, 
        2, 6, 0, 0, 4, 4, 4, 0, 2, 5, 2, 0, 0, 5, 0, 0, 
        2, 6, 2, 0, 3, 3, 3, 0, 2, 2, 2, 0, 4, 4, 4, 0, 
        2, 5, 0, 0, 4, 4, 4, 0, 2, 4, 2, 0, 4, 4, 4, 0, 
        2, 6, 0, 0, 3, 3, 5, 0, 2, 2, 2, 0, 4, 4, 6, 0, 
        2, 5, 0, 0, 0, 4, 6, 0, 2, 4, 0, 0, 0, 4, 7, 0, 
        2, 6, 0, 0, 3, 3, 5, 0, 2, 2, 2, 0, 4, 4, 6, 0, 
        2, 5, 0, 0, 0, 4, 6, 0, 2, 4, 0, 0, 0, 4, 7, 0, 
    };
    
    private static ReadOnlySpan<byte> MapAddressingModeToBytes => new byte[16]
    {
        0, // Undefined
        3, // Absolute
        3, // AbsoluteX
        3, // AbsoluteY
        1, // Accumulator
        2, // Immediate
        1, // Implied
        3, // Indirect
        2, // IndirectX
        2, // IndirectY
        2, // Relative
        2, // ZeroPage
        2, // ZeroPageX
        2, // ZeroPageY
        0, // Undefined
        0, // Undefined
    };
    private static ReadOnlySpan<byte> MapAddressingModeToCycles => new byte[16]
    {
        0, // Undefined
        3, // Absolute
        3, // AbsoluteX
        3, // AbsoluteY
        2, // Accumulator
        2, // Immediate
        2, // Implied
        5, // Indirect
        5, // IndirectX
        4, // IndirectY
        2, // Relative
        2, // ZeroPage
        3, // ZeroPageX
        3, // ZeroPageY
        0, // Undefined
        0, // Undefined
    };
}
