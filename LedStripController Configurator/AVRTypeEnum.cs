﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedStripController_Configurator
{
    public enum AVRTypeEnum:int
    {
        ATtiny11 = 0x1e9004,
        ATtiny12 = 0x1e9005,
        ATtiny13 = 0x1e9007,
        ATtiny15 = 0x1e9006,
        AT90S1200 = 0x1e9001,
        AT90S4414 = 0x1e9201,
        AT90S2313 = 0x1e9101,
        AT90S2333 = 0x1e9105,
        AT90S2343 = 0x1e9103,
        AT90S4433 = 0x1e9203,
        AT90S4434 = 0x1e9202,
        AT90S8515 = 0x1e9301,
        AT90S8535 = 0x1e9303,
        ATMEGA103 = 0x1e9701,
        ATMEGA64 = 0x1e9602,
        ATMEGA128 = 0x1e9702,
        AT90CAN128 = 0x1e9781,
        AT90CAN64 = 0x1e9681,
        AT90CAN32 = 0x1e9581,
        ATMEGA16 = 0x1e9403,
        ATMEGA164P = 0x1e940a,
        ATMEGA324P = 0x1e9508,
        ATMEGA644 = 0x1e9609,
        ATMEGA644P = 0x1e960a,
        ATMEGA162 = 0x1e9404,
        ATMEGA163 = 0x1e9402,
        ATMEGA169 = 0x1e9405,
        ATMEGA329 = 0x1e9503,
        ATMEGA329P = 0x1e950b,
        ATMEGA3290 = 0x1e9504,
        ATMEGA3290P = 0x1e950c,
        ATMEGA649 = 0x1e9603,
        ATMEGA6490 = 0x1e9604,
        ATMEGA32 = 0x1e9502,
        ATMEGA161 = 0x1e9401,
        ATMEGA8 = 0x1e9307,
        ATMEGA8515 = 0x1e9306,
        ATMEGA8535 = 0x1e9308,
        ATTINY26 = 0x1e9109,
        ATTINY261 = 0x1e910c,
        ATTINY461 = 0x1e9208,
        ATTINY861 = 0x1e930d,
        ATMEGA48 = 0x1e9205,
        ATMEGA88 = 0x1e930a,
        ATMEGA168 = 0x1e9406,
        ATtiny2313 = 0x1e910a,
        AT90PWM2 = 0x1e9381,
        AT90PWM3 = 0x1e9381,
        AT90PWM2B = 0x1e9383,
        AT90PWM3B = 0x1e9383,
        ATtiny25 = 0x1e9108,
        ATtiny45 = 0x1e9206,
        ATtiny85 = 0x1e930b,
        ATMEGA640 = 0x1e9608,
        ATMEGA1280 = 0x1e9703,
        ATMEGA1281 = 0x1e9704,
        ATMEGA2560 = 0x1e9801,
        ATMEGA2561 = 0x1e9802,
        ATtiny24 = 0x1e910b,
        ATtiny44 = 0x1e9207,
        ATtiny84 = 0x1e930c,
        AT90USB646 = 0x1e9782,
        AT90USB647 = 0x1e9782,
        AT90USB1286 = 0x1e9782,
        AT90USB1287 = 0x1e9782,
        ATMEGA325 = 0x1e9505,
        ATMEGA645 = 0x1E9605,
        ATMEGA3250 = 0x1E9506,
        ATMEGA6450 = 0x1E9606
    }
}
