using PowerRiderDLLWrapper.PowerCom;
using PowerRiderDLLWrapper.PowerPacket;

// define the communication type
// Serial
PowerCom com = new PowerSerialCom("COM4", 19200, 10, 16); // all the argument are user defined and setup-dependant

// Kvaser
//PowerCom com = new PowerKvaserCom(250_000, 0, 10, 16);

// Canalyst-II
//PowerCom com = new PowerCanalystCom(250_000, 0, 10, 16);

// UDP
//PowerCom com = new PowerUDPCom(new byte[] { 192, 168, 1, 50 }, 8060, 10, 16);

// Connect to the unit
if (!com.ConnectCom())
{
    Console.WriteLine("Cannot connect");
    Console.ReadLine();
    return;
}

// Creating Packets:

// create a simple packet (no payload)
PowerPacket simplePacketNoPayload = new PowerPacket(2, PowerPacketHelper.CommandID.ChannelStatus_1, 10, 16);

// create a simple packet (payload included)
PowerPacket simplePacketWithPayload = new PowerPacket(2, PowerPacketHelper.CommandID.Configuration, 10, 16, PowerPacketHelper.EnterConfigModePW.ToArray());

// Sending packets with PowerCom
// With already defined packets
com.SendPacket(simplePacketNoPayload);
com.SendPacket(simplePacketWithPayload);

// Directly through PowerCom
com.SendPacket(2, PowerPacketHelper.CommandID.ChannelStatus_1);
com.SendPacket(2, PowerPacketHelper.CommandID.Configuration, PowerPacketHelper.EnterConfigModePW.ToArray());

// With PowerCom you can also send more complicated packets easily like system parameters and channel parameters
com.SendSysParamPacket(2, PowerPacketHelper.SystemParamNumber.UnitIDAddress); // no payload, getting the unit address
com.SendSysParamPacket(2, PowerPacketHelper.SystemParamNumber.SerialBaudrate, BitConverter.GetBytes(7)); // setting the serial baudrate to 19200
com.SendChannelParamPacket(2, PowerPacketHelper.ChannelParamNumber.NominalCurrentValue, 1); // getting the nominal current of channel 1
com.SendChannelParamPacket(2, PowerPacketHelper.ChannelParamNumber.NominalCurrentValue, 1, BitConverter.GetBytes(50)); // setting the nominal current of channel 1 to 5A


// Receiving packets with PowerCom
PowerPacket receivedPacket;
while (true)
{
    receivedPacket = com.ReceivePacket();
    if (receivedPacket.ErrorFlag) // Error flag indicates that the packet wasn't received correctly. The error code will be in the Payload property at index 0. see PowerComHelpers to see all the error codes. 
    {
        if (receivedPacket.Payload.ElementAt(0) == PowerComHelpers.POWER_COM_TIMEOUT_CODE) // exhausted all the received messages
        {
            Console.WriteLine("No more messages");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"Error Code {receivedPacket.Payload.ElementAt(0)}");
        Console.ReadLine();
        return;
    }

    // converting the payload to a string
    string payloadAsString = string.Empty;
    foreach (byte payloadByte in receivedPacket.Payload)
    {
        payloadAsString += $"{payloadByte:X2} ";
    }

    // Print all the relevant properties
    Console.WriteLine($"{receivedPacket.PowerAddress} -> {receivedPacket.HostAddress}\n" +
        $"\tCommandID = {receivedPacket.CommandID} ({(byte)receivedPacket.CommandID})\n" +
        $"\tPayload = 0x{payloadAsString}\n\n");
}
