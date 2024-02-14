## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.28.2](https://www.nuget.org/packages/StructLinq/0.28.2)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3996/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.100-preview.1.24101.2
  [Host]     : .NET 6.0.26 (6.0.2623.60508), X64 RyuJIT AVX2
  Job-THTHEP : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  Job-OQLBIM : .NET 9.0.0 (9.0.24.8009), X64 RyuJIT AVX2


```
| Method                   | Runtime  | Count | Mean      | Error    | StdDev   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  65.41 ns | 0.392 ns | 0.327 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  65.52 ns | 0.358 ns | 0.299 ns | 1.00x slower |   0.01x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 200.25 ns | 3.452 ns | 3.837 ns | 3.08x slower |   0.06x | 0.0229 |      48 B |          NA |
| LinqFaster               | .NET 8.0 | 100   | 197.25 ns | 3.911 ns | 3.841 ns | 3.02x slower |   0.07x | 0.3173 |     664 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 381.73 ns | 3.857 ns | 3.011 ns | 5.84x slower |   0.06x | 0.2141 |     448 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 158.30 ns | 2.752 ns | 2.945 ns | 2.42x slower |   0.05x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 128.81 ns | 2.384 ns | 1.861 ns | 1.97x slower |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  64.79 ns | 0.769 ns | 0.719 ns | 1.01x faster |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 105.84 ns | 2.115 ns | 2.436 ns | 1.62x slower |   0.04x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  75.72 ns | 1.505 ns | 1.792 ns | 1.16x slower |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 240.16 ns | 4.208 ns | 4.321 ns | 3.68x slower |   0.07x | 0.2027 |     424 B |          NA |
|                          |          |       |           |          |          |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  65.87 ns | 0.700 ns | 0.546 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  65.85 ns | 0.383 ns | 0.299 ns | 1.00x faster |   0.01x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 184.70 ns | 3.731 ns | 3.308 ns | 2.79x slower |   0.04x | 0.0229 |      48 B |          NA |
| LinqFaster               | .NET 9.0 | 100   | 169.62 ns | 3.386 ns | 5.841 ns | 2.60x slower |   0.09x | 0.3173 |     664 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 356.17 ns | 2.449 ns | 1.912 ns | 5.41x slower |   0.06x | 0.2141 |     448 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 148.90 ns | 2.573 ns | 2.963 ns | 2.27x slower |   0.06x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 151.40 ns | 1.271 ns | 0.993 ns | 2.30x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  63.31 ns | 0.436 ns | 0.387 ns | 1.04x faster |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 105.09 ns | 1.246 ns | 1.223 ns | 1.60x slower |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  86.77 ns | 1.590 ns | 1.410 ns | 1.32x slower |   0.02x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 238.13 ns | 3.304 ns | 3.673 ns | 3.64x slower |   0.05x | 0.2027 |     424 B |          NA |
