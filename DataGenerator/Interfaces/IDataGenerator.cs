﻿using System.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DataGenerator.Interfaces
{
    public interface IDataGenerator
    {
        Task<string> GenerateSQL(string json, CancellationToken cancellationToken);
    }
}
