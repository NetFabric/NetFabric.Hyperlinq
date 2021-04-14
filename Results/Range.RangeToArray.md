## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|          Method |    Job |  Runtime | Start | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------- |--------- |------ |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop | .NET 5 | .NET 5.0 |     0 |  1000 |   872.9 ns | 20.67 ns | 60.62 ns |   843.8 ns |  1.00 |    0.00 | 1.9226 |     - |     - |      4 KB |
|            Linq | .NET 5 | .NET 5.0 |     0 |  1000 |   649.6 ns | 11.93 ns | 11.16 ns |   649.9 ns |  0.71 |    0.05 | 1.9417 |     - |     - |      4 KB |
|      LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 |   654.3 ns |  6.10 ns | 14.25 ns |   653.5 ns |  0.76 |    0.05 | 1.9226 |     - |     - |      4 KB |
| LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   297.9 ns |  7.68 ns | 22.64 ns |   286.2 ns |  0.34 |    0.03 | 1.9226 |     - |     - |      4 KB |
|          LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 2,101.1 ns | 25.96 ns | 24.29 ns | 2,105.0 ns |  2.30 |    0.17 | 1.9226 |     - |     - |      4 KB |
|      StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 |   756.4 ns | 12.41 ns | 11.61 ns |   754.5 ns |  0.83 |    0.06 | 1.9226 |     - |     - |      4 KB |
|       Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 |   311.4 ns |  5.91 ns |  5.52 ns |   311.5 ns |  0.34 |    0.03 | 1.9226 |     - |     - |      4 KB |
|                 |        |          |       |       |            |          |          |            |       |         |        |       |       |           |
|         ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 |   776.1 ns | 15.51 ns | 40.03 ns |   755.5 ns |  1.00 |    0.00 | 1.9226 |     - |     - |      4 KB |
|            Linq | .NET 6 | .NET 6.0 |     0 |  1000 |   654.5 ns | 14.26 ns | 42.05 ns |   635.1 ns |  0.85 |    0.04 | 1.9417 |     - |     - |      4 KB |
|      LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 |   688.7 ns | 15.21 ns | 44.60 ns |   663.6 ns |  0.89 |    0.05 | 1.9226 |     - |     - |      4 KB |
| LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 |   315.7 ns |  8.50 ns | 23.83 ns |   311.0 ns |  0.41 |    0.04 | 1.9226 |     - |     - |      4 KB |
|          LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 1,978.9 ns | 33.64 ns | 29.82 ns | 1,988.5 ns |  2.50 |    0.12 | 1.9226 |     - |     - |      4 KB |
|      StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 |   774.5 ns |  8.51 ns |  7.55 ns |   777.6 ns |  0.98 |    0.05 | 1.9226 |     - |     - |      4 KB |
|       Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 |   323.7 ns |  8.78 ns | 25.89 ns |   318.4 ns |  0.41 |    0.02 | 1.9226 |     - |     - |      4 KB |
