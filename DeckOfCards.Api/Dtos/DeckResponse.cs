using System;
using System.Collections.Generic;

namespace DeckOfCards.Api.Dtos
{
    public class DeckResponse
    {
        public bool Success { get; set; }
        public string Status { get; set; }
        public Guid Id { get; set; }
        public int Remaining { get; set; }
        public IList<Card> Cards { get; set; }
    }
}
