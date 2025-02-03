namespace PdsCleanAppDomain._Common
{
    public class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool Active { get; set; }
    }
}
