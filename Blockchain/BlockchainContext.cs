using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Blockchain
{
    class BlockchainContext : DbContext
    {
        public BlockchainContext()
            : base("Blockchain")
        { }

        public DbSet<Block> Blocks { get; set; }
    }
}
