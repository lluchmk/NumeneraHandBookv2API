using System;
using System.Collections.Generic;
using System.Text;

namespace NumeneraCypherBook.Core.Models
{
    public class Cypher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Internal { get; set; }
        public string Wearable { get; set; }
        public string Usable { get; set; }
        public string Description { get; set; }
        public CypherType Type { get; set; }
    }

    public enum CypherType
    {
        Annoetic = 1,
        Occultic = 2
    }
}
