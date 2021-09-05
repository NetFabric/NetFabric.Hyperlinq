## ToListBenchmarks

### Source
[ToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToListBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.7.21377.19
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta45](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta45)

### Results:
``` ini

BenchmarkDotNet=v0.13.1.1606-nightly, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|                          Linq_Array |                     Array |   100 |    78.12 ns | 0.344 ns | 0.305 ns |      baseline |         | 0.2180 |     456 B |
|                    StructLinq_Array |                     Array |   100 |   105.98 ns | 0.367 ns | 0.307 ns |  1.36x slower |   0.01x | 0.2180 |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    54.08 ns | 0.374 ns | 0.350 ns |  1.44x faster |   0.01x | 0.2180 |     456 B |
|                                     |                           |       |             |          |          |               |         |        |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   472.95 ns | 2.738 ns | 2.561 ns |      baseline |         | 0.5808 |   1,216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   565.69 ns | 2.407 ns | 2.251 ns |  1.20x slower |   0.01x | 0.2327 |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   550.85 ns | 1.197 ns | 0.999 ns |  1.16x slower |   0.01x | 0.2365 |     496 B |
|                                     |                           |       |             |          |          |               |         |        |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    56.91 ns | 0.274 ns | 0.243 ns |      baseline |         | 0.2180 |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   586.92 ns | 2.851 ns | 2.527 ns | 10.31x slower |   0.07x | 0.2327 |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    66.44 ns | 0.648 ns | 0.606 ns |  1.17x slower |   0.01x | 0.2180 |     456 B |
|                                     |                           |       |             |          |          |               |         |        |           |
|                     Linq_List_Value |                List_Value |   100 |    60.17 ns | 0.425 ns | 0.355 ns |      baseline |         | 0.2180 |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   140.00 ns | 1.232 ns | 1.152 ns |  2.33x slower |   0.02x | 0.2179 |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    65.30 ns | 0.520 ns | 0.487 ns |  1.09x slower |   0.01x | 0.2180 |     456 B |
|                                     |                           |       |             |          |          |               |         |        |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,466.73 ns | 4.006 ns | 3.551 ns |      baseline |         | 0.5798 |   1,216 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,472.88 ns | 4.559 ns | 4.265 ns |  1.00x slower |   0.00x | 0.5798 |   1,216 B |
|                                     |                           |       |             |          |          |               |         |        |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   473.62 ns | 2.557 ns | 2.392 ns |      baseline |         | 0.5808 |   1,216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   570.95 ns | 1.489 ns | 1.243 ns |  1.21x slower |   0.01x | 0.2327 |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   653.91 ns | 2.104 ns | 1.969 ns |  1.38x slower |   0.01x | 0.2327 |     488 B |
|                                     |                           |       |             |          |          |               |         |        |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    57.16 ns | 0.823 ns | 0.687 ns |      baseline |         | 0.2180 |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   569.44 ns | 2.948 ns | 2.757 ns |  9.96x slower |   0.13x | 0.2327 |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    61.24 ns | 0.481 ns | 0.376 ns |  1.07x slower |   0.01x | 0.2180 |     456 B |
|                                     |                           |       |             |          |          |               |         |        |           |
|                 Linq_List_Reference |            List_Reference |   100 |    60.14 ns | 0.348 ns | 0.326 ns |      baseline |         | 0.2180 |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   578.80 ns | 8.282 ns | 6.915 ns |  9.63x slower |   0.13x | 0.2327 |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    64.81 ns | 0.398 ns | 0.353 ns |  1.08x slower |   0.01x | 0.2180 |     456 B |
|                                     |                           |       |             |          |          |               |         |        |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,466.21 ns | 3.947 ns | 3.692 ns |      baseline |         | 0.5798 |   1,216 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,616.07 ns | 4.787 ns | 4.478 ns |  1.10x slower |   0.00x | 0.5951 |   1,248 B |
