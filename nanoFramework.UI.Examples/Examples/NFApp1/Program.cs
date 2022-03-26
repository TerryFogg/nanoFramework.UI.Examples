using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;
using System.Device.I2c;
using System.Device.Adc;

namespace NFApp1
{
    public class Program
    {
        public static void Main()
        {
            GpioController gp = new GpioController(PinNumberingScheme.Board);
            gp.OpenPin((int)ArduinoPin.D0);
            gp.OpenPin((int)STMOD.ST_11_INT);

            int i2cAddress = 32;
            I2cConnectionSettings settings = new I2cConnectionSettings((int)I2C_Channel.I2C1, i2cAddress);
            I2cDevice i2cDevice = new I2cDevice(settings);

            AdcController adc1 = new AdcController();
            adc1.OpenChannel((int)ArduinoPin.Analog_0);

            Debug.WriteLine("Hello from nanoFramework!");
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
