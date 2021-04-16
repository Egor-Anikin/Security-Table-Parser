namespace SecurityTableParser
{
    class Record
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public bool PrivacyViolation { get; set; }
        public bool IntegrityViolation { get; set; }
        public bool AccessViolation { get; set; }

        public override string ToString()
        {
            return $"{Id}@{Name}@{Description}@{Source}@{Destination}@{(PrivacyViolation ? "1" : "0")}@{(IntegrityViolation ? "1" : "0")}@{(AccessViolation ? "1" : "0")}";
        }

    }
}