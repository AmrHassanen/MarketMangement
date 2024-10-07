namespace MarketMangement.MVC.DTOs
{
    public class PropertyDto
    {
        // Common properties for different categories
        public int ID {  get; set; }
        public string? IP { get; set; }
        public bool? IsColor { get; set; } // Nullable boolean for printers
        public string? Brand { get; set; }

        // Properties for Laptop
        public string? Processor { get; set; }
        public string? HD { get; set; }
        public string? Ram { get; set; }
        public string? Display { get; set; }
        public string? CurrentUser { get; set; } // Can be a lookup

        // Properties for Switches
        public int? Ports { get; set; }
        public string? Speed { get; set; }  // Speed like 1Gbps, 100Mbps
    }
}
