﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class Chain
    {
        public List<Block> Blocks { get; private set; }

        public Block Last { get; private set; }

        public Chain()
        {
            Blocks = LoadChainFromDB();
            
            if (Blocks.Count == 0)
            {
                var genesisBlock = new Block();

                Blocks.Add(genesisBlock);
                Last = genesisBlock;
                Save(Last);
            }
            else
            {
                if (Check())
                {
                    Last = Blocks.Last();
                }
                else
                {
                    throw new Exception("Ошибка получения блоков из базы данных.");
                }
            }
        }
        public void Add(string data, string user)
        {
            var block = new Block(data, user, Last);
            Blocks.Add(block);
            Last = block;
            Save(Last);
        }

        /// <summary>
        /// Метод проверки корректности цепочки
        /// </summary>
        /// <returns> true - цепочка корректна, false - цепочка некорректна </returns>
        public bool Check()
        {
            var genesisBlock = new Block();
            var previousHash = genesisBlock.Hash;
            
            foreach(var block in Blocks.Skip(1))
            {
                var hash = block.PreviousHash;

                if(previousHash != hash)
                {
                    return false;
                }
                previousHash = block.Hash;
            }

            return true;
        }
        /// <summary>
        /// Сохранение блока в базу данных 
        /// </summary>
        /// <param name="block"> Сохраняемый блок. </param>
        private void Save(Block block)
        {
            using(var db = new BlockchainContext())
            {
                db.Blocks.Add(block);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Получение данных из базы данных в цепочку.
        /// </summary>
        /// <returns> Список блоков данных </returns>
        private List<Block> LoadChainFromDB()
        {
            List<Block> result;
            using(var db = new BlockchainContext())
            {
                var count = db.Blocks.Count();

                result = new List<Block>(count * 2);
                result.AddRange(db.Blocks);
            }
            return result;
        }
        private void Sync()
        {

        }
        

    }
}