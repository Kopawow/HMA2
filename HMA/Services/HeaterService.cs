
using System;
using System.IO.Ports;
using Modbus.Device;

namespace HMA.Services
{
    public class HeaterService
    {
        public void ChangeHeaterState(bool shouldBeStarted)
        {
            SerialPort port = new SerialPort("COM2");
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            try
            {
                port.Open();

                IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);

                byte slaveId = 1;
                ushort startAddress = 100;
                ushort[] registers = new ushort[] { ((shouldBeStarted)? ushort.Parse("1"): ushort.Parse("0")),21 };
                master.WriteMultipleRegisters(slaveId, startAddress, registers);

            }
            finally
            {
                if (port != null)
                {
                    if (port.IsOpen)
                    {
                        port.Close();
                    }
                    port.Dispose();
                }
            }
                
             

          
          
        }
    }
}