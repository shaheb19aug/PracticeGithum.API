namespace StudentAdminPortal.API.DomainModel
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        //Navigational Property
        public Guid StudentId { get; set; }
    }
}
