namespace Gurrt.RaceSimUDPMonitor.PacketReader
{
    public enum PacketType
    {
        eCarPhysics = 0,
        eRaceDefinition = 1,
        eParticipants = 2,
        eTimings = 3,
        eGameState = 4,
        eWeatherState = 5,// not sent at the moment, information can be found in the game state packet
        eVehicleNames = 6, //not sent at the moment
        eTimeStats = 7,
        eParticipantVehicleNames = 8
    };
}