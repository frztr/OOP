
    using Microsoft.AspNetCore.Mvc;
    public class ReviewQueryControllerDto
    {
        public int Count { get; set; } = 50;

        public int Offset { get; set; } = 0;
        
    }