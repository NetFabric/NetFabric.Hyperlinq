## IndexerBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|               Method | Count |      Mean |     Error |    StdDev | Ratio |
|--------------------- |------ |----------:|----------:|----------:|------:|
| Enumerator_Reference | 10000 | 27.615 ns | 0.2273 ns | 0.2015 ns |  1.00 |
|     Enumerator_Value | 10000 |  9.960 ns | 0.0738 ns | 0.0690 ns |  0.36 |
|    Indexer_Reference | 10000 | 10.470 ns | 0.1033 ns | 0.0916 ns |  0.38 |
|        Indexer_Value | 10000 |  5.313 ns | 0.0344 ns | 0.0322 ns |  0.19 |
|  Hyperlinq_Reference | 10000 | 11.812 ns | 0.0593 ns | 0.0555 ns |  0.43 |
|      Hyperlinq_Value | 10000 | 12.609 ns | 0.0635 ns | 0.0563 ns |  0.46 |
