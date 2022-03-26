using System;
using System.Device.Gpio;
using System.Device.Adc;

namespace NFApp1
{
    enum I2C_Channel : int
    {
        I2C1 = 0,
        I2C2 = 1,
        I2C3 = 2,
        I2C4 = 3
    }
    enum LEDS : int
    {
        User_LED_2 = 35,   // PC2  
        User_LED_1 = 36   // PC3  
    }
    enum ArduinoPin : int
    {
        Analog_0 = 33, // PC0
        Analog_1 = 115,// PH2
        Analog_2 = 252,// PA0_C
        Analog_3 = 253,// PA1_C
        Analog_4 = 254,// PC2_C
        Analog_5 = 255,// PC3_C
        D0 = 32,       // PB15
        D1 = 31,       // PB14
        D2 = 100,      // PG3
        D3 = 1,        // PA0
        D4 = 101,      // PG4
        D5 = 79,       // PE14
        D6 = 64,       // PD15
        D7 = 102,      // PG5
        D8 = 68,       // PE3
        D9 = 24,       // PB7
        D10 = 87,      // PF6
        D11 = 90,      // PF9 - SPI5_MOSI
        D12 = 89,      // PF8 - SPI5_MISO
        D13 = 88,      // PF7 - SPI5_SCK
        D14 = 96,      // PF15 - I2C4_SDA
        D15 = 95       // PF14 - I2C4_SCL
    }
    enum STMOD : int
    {
        ST_1_7_RX = 87,            // PF6  
        ST_27_TX = 88,             // PF7  
        ST_35_MISO = 89,           // PF8  
        ST_45_MOSI = 90,           // PF9  
        ST_7_I2C4_SCL = 95,        // PF14 
        ST_8_SPI5_MOSI = 92,       // PF11 
        ST_9_SPI5_MISO = 120,      // PH7  
        ST_10_I2C4_SDA = 96,       // PF15 
        ST_11_INT = 126,           // PH12 
        ST_12_RST = 114,           // PH1  
        ST_13 = 6,                 // PA5  _ADC12_INP19, _DAC1_OUT2,      
        ST_14_PWM_4_CH3 = 63,      // PD14 
        ST_18_DFSDM1_DATIN2 = 72,  // PE7  
        ST_18_DFSDM1_CKOUT = 74,   // PE9  
        ST_19_DFSDM1_DATIN4 = 75,  // PE10 
        ST_20_DFSDM1_DATIN6 = 94   // PF13 
    }
    // UFBGA176+25 ballout
    enum FDCANPin : int
    {
        // PA0_C AND THIS IS A ESCOP
        FDCAN2_RX = 22,   // PB5  
        FDCAN2_TX = 23,   // PB6  
        Audio_Int = 73,   // PE8  
        FDCAN3_RX = 87,   // PF6  
        FDCAN3_TX = 88,   // PF7  
        FDCAN1_TX = 127,   // PH13 
        FDCAN1_RX = 128   // PH14
    }
}













































