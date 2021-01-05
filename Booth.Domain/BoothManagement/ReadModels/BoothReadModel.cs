namespace Booth.Domain.BoothManagement.ReadModels
{
    public class BoothReadModel
    {
        public int Id { get; private set; }

        public int AggregateRootId { get; private set; }

        public string BoothCode { get; private set; }

        public string BoothStreet { get; private set; }

        public string BoothCity { get; private set; }

        public string BoothStaffJson { get; private set; }

        public BoothReadModel(int aggregateRootId,
                              string boothCode,
                              string boothStreet,
                              string boothCity,
                              string boothStaffJson)
        {
            AggregateRootId = aggregateRootId;
            BoothCode = boothCode;
            BoothStreet = boothStreet;
            BoothCity = boothCity;
            BoothStaffJson = boothStaffJson;
        }
    }
}
